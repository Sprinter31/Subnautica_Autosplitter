using LiveSplit.Model;
using LiveSplit.Options;
using LiveSplit.Subnautica;
using LiveSplit.UI.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Voxif.AutoSplitter;
using Voxif.IO;

namespace LiveSplit.Subnautica
{
    public class SubnauticaComponent : Voxif.AutoSplitter.Component
    {
        private readonly SubnauticaMemory memory;
        private readonly LiveSplitState _state;
        private readonly TimerModel timerModel;
        public readonly HashSet<SubnauticaSplit> alreadySplit = new HashSet<SubnauticaSplit>();

        public SubnauticaComponent(LiveSplitState state) : base(state)
        {
#if DEBUG
            logger = new ConsoleLogger();
#else
            logger = new  FileLogger("_" + Factory.ExAssembly.GetName().Name.Substring(10) + ".log");
#endif
            logger.StartLogger();

            Localization.Load();
            _state = state;
            settings = new SubnauticaSettings(state);
            memory = new SubnauticaMemory(state, this, logger, settings);
            timerModel = new TimerModel() { CurrentState = state };
        }

        public override bool Update()
        {
            UpdateExploTime();

            bool ok;

            try
            {
                ok = memory.Update();
            }
            catch (Win32Exception ex)
            {
                logger.Log($"Win32Exception in memory.Update: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                logger.Log($"Unexpected exception in memory.Update: {ex}");
                return false;
            }

            if (!ok || !memory.pointersInitialized)
                return false;

            TryResetOnMainMenu();

            return true;
        }

        public override bool Start()
        {
            if (memory.startedTimerBefore || !memory.pointersInitialized)
                return false;

            // options: 100 -> 80 health
            if (settings.IntroStart && (GameModeOption)memory.GameMode.New != GameModeOption.Creative)
            {
                if (memory.DamageEffectsShowing.New && !memory.DamageEffectsShowing.Old) { logger.Log("Start of damageEffectsShowing"); memory.startedTimerBefore = true; return true; }
            }
            if (settings.CreativeStart && !memory.IsLoadingScreenShowing.New && !memory.IsIntroCinematicActive.New && !memory.isInMainMenu)
            {
                // Start of Move
                if ((memory.walkDir.Current != 0 && memory.walkDir.Old == 0) || (memory.strafeDir.Current != 0 && memory.strafeDir.Old == 0)) { logger.Log("Start of Move"); memory.startedTimerBefore = true; return true; }

                // Start of Jump
                if (memory.IsPlayerJumping.New && memory.IsPlayerJumping.Changed) { logger.Log("Start of Jump"); memory.startedTimerBefore = true; return true; }

                // Start of Crafting Menu
                if (memory.CraftingMenu.New != IntPtr.Zero && memory.CraftingMenu.Old == IntPtr.Zero) { logger.Log("Start of Crafting Menu"); memory.startedTimerBefore = true; return true; }

                // Start of PDA
                if ((PDATab)memory.PDATab.New != PDATab.None && memory.PDATab.Changed) { logger.Log("Start of PDA"); memory.startedTimerBefore = true; return true; }
            }
            
            // Not Blocked by Loading Screen
            if (settings.CreativeStart && !memory.isInMainMenu)
            {
                // Start of Dev Console                                     // Allow it to Always Start the Timer after Resetting
                if (memory.DevConsoleOpen.New && !memory.DevConsoleOpen.Old) { logger.Log("Start of Dev Console"); return true; }
            }

            return false;
        }

        public override bool Split()
        {
            // TODO: fix only split once shit
            if (!memory.pointersInitialized)
                return false;

            var splits = settings.Splits;
            
            for (int i = 0; i < splits.Count; i++)
            {
                if ((SubnauticaSettings.OrderedAutoSplits && i != alreadySplit.Count) || (SubnauticaSettings.OrderedLiveSplit && i != _state.CurrentSplitIndex))
                    continue;

                var split = splits[i];

                IEnumerable<SubnauticaSplit> conditionsSplits = GetAllConditions(split);
                bool allConditionsMet = true;

                foreach (var conditionSplit in conditionsSplits)
                {
                    memory.CurrentSplitToCheck = conditionSplit;
                    if (memory.subConditions.TryGetValue(conditionSplit.SplitName, out var subCondition) && !subCondition())
                    {
                        allConditionsMet = false;
                        break;
                    }
                }

                memory.CurrentSplitToCheck = split;
                if (allConditionsMet 
                    && memory.splitConditions.TryGetValue(split.SplitName, out var condition) 
                    && condition()
                    && !(split.OnlySplitOnce && !SubnauticaSettings.OrderedAutoSplits && !SubnauticaSettings.OrderedLiveSplit && alreadySplit.Contains(split)))
                {
                    alreadySplit.Add(split);
                    logger.Log($"{split.GetDescription()} triggered");
                    return true;
                }
            }
            return false;
        }

        public static IEnumerable<SubnauticaSplit> GetAllConditions(SubnauticaSplit split)
        {
            if (split?.Conditions == null)
                yield break;

            foreach (var c in split.Conditions.Where(c => c.IsSubCondition))
            {
                yield return c;

                foreach (var nested in GetAllConditions(c))
                    yield return nested;
            }
        }

        public override bool Loading() => memory.ShouldPause();

        private void TryResetOnMainMenu()
        {
            if (!settings.Reset)
                return;
            if (memory.MainMenu?.New == memory.MainMenu?.Old && memory.MainMenu?.New != IntPtr.Zero)
                return;
            if (_state.CurrentPhase == TimerPhase.NotRunning)
                return;

            Form ui = _state.Form;
            Action doReset = () =>
            {
                bool GoldSegment = false;
                for (int index = 0; index < _state.Run.Count; index++)
                {
                    if (LiveSplitStateHelper.CheckBestSegment(_state, index, _state.CurrentTimingMethod))
                    {
                        GoldSegment = true;
                        break;
                    }
                }

                bool save = true;
                if (settings.AskForGoldSave && GoldSegment)
                {
                    DialogResult r = MessageBox.Show(
                        ui,
                        "Save splits before resetting?",
                        "Reset",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Question);

                    if (r == DialogResult.Cancel)
                        return;

                    save = (r == DialogResult.Yes);
                }

                timerModel.Reset(save);
            };

            if (ui.InvokeRequired)
                ui.BeginInvoke(doReset);
            else
                doReset();
        }

        public override void OnReset()
        {
            alreadySplit.Clear();
        }

        private void UpdateExploTime()
        {
            string text = TimeSpan.FromSeconds(0).ToString(@"h\:mm\:ss");

            if (memory.pointersInitialized)
            {
                float explosionTimeFloat = memory.TimeToStartCountdown.New - memory.TimeToStartWarning.New;
                TimeSpan explosionTime = TimeSpan.FromSeconds(explosionTimeFloat);
                text = explosionTime.ToString(@"h\:mm\:ss");
            }

            settings.UpdateTextComponent("Explosion Time", text);
            settings.UpdateExploBtnContent();
        }
    }
}
