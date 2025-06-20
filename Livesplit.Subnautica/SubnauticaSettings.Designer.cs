namespace Livesplit.Subnautica
{
    partial class SubnauticaSettings
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cb_StartIntro = new System.Windows.Forms.CheckBox();
            this.cb_Rocket = new System.Windows.Forms.CheckBox();
            this.flowMain = new System.Windows.Forms.FlowLayoutPanel();
            this.flowOptions = new System.Windows.Forms.FlowLayoutPanel();
            this.Options_GroupBox = new System.Windows.Forms.GroupBox();
            this.btnAddSplit = new System.Windows.Forms.Button();
            this.RunBehaviour_GroupBox = new System.Windows.Forms.GroupBox();
            this.chkCreativeStart = new System.Windows.Forms.CheckBox();
            this.chkIntroStart = new System.Windows.Forms.CheckBox();
            this.SortBy_GroupBox = new System.Windows.Forms.GroupBox();
            this.rdAlpha = new System.Windows.Forms.RadioButton();
            this.rdType = new System.Windows.Forms.RadioButton();
            this.ToolTips = new System.Windows.Forms.ToolTip(this.components);
            this.flowMain.SuspendLayout();
            this.flowOptions.SuspendLayout();
            this.Options_GroupBox.SuspendLayout();
            this.RunBehaviour_GroupBox.SuspendLayout();
            this.SortBy_GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_StartIntro
            // 
            this.cb_StartIntro.AutoSize = true;
            this.cb_StartIntro.Location = new System.Drawing.Point(3, 3);
            this.cb_StartIntro.Name = "cb_StartIntro";
            this.cb_StartIntro.Size = new System.Drawing.Size(113, 20);
            this.cb_StartIntro.TabIndex = 0;
            this.cb_StartIntro.Text = "Start after intro";
            this.cb_StartIntro.UseVisualStyleBackColor = true;
            // 
            // cb_Rocket
            // 
            this.cb_Rocket.AutoSize = true;
            this.cb_Rocket.Location = new System.Drawing.Point(3, 29);
            this.cb_Rocket.Name = "cb_Rocket";
            this.cb_Rocket.Size = new System.Drawing.Size(161, 20);
            this.cb_Rocket.TabIndex = 1;
            this.cb_Rocket.Text = "Split on Rocket launch";
            this.cb_Rocket.UseVisualStyleBackColor = true;
            // 
            // flowMain
            // 
            this.flowMain.AllowDrop = true;
            this.flowMain.AutoSize = true;
            this.flowMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowMain.Controls.Add(this.flowOptions);
            this.flowMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowMain.Location = new System.Drawing.Point(0, 0);
            this.flowMain.Margin = new System.Windows.Forms.Padding(0);
            this.flowMain.Name = "flowMain";
            this.flowMain.Size = new System.Drawing.Size(608, 159);
            this.flowMain.TabIndex = 0;
            this.flowMain.WrapContents = false;
            // 
            // flowOptions
            // 
            this.flowOptions.AutoSize = true;
            this.flowOptions.Controls.Add(this.Options_GroupBox);
            this.flowOptions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowOptions.Location = new System.Drawing.Point(0, 0);
            this.flowOptions.Margin = new System.Windows.Forms.Padding(0);
            this.flowOptions.Name = "flowOptions";
            this.flowOptions.Size = new System.Drawing.Size(608, 159);
            this.flowOptions.TabIndex = 2;
            // 
            // Options_GroupBox
            // 
            this.Options_GroupBox.Controls.Add(this.btnAddSplit);
            this.Options_GroupBox.Controls.Add(this.RunBehaviour_GroupBox);
            this.Options_GroupBox.Controls.Add(this.SortBy_GroupBox);
            this.Options_GroupBox.Location = new System.Drawing.Point(4, 4);
            this.Options_GroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.Options_GroupBox.Name = "Options_GroupBox";
            this.Options_GroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.Options_GroupBox.Size = new System.Drawing.Size(600, 151);
            this.Options_GroupBox.TabIndex = 6;
            this.Options_GroupBox.TabStop = false;
            this.Options_GroupBox.Text = "Options";
            // 
            // btnAddSplit
            // 
            this.btnAddSplit.Location = new System.Drawing.Point(8, 113);
            this.btnAddSplit.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddSplit.Name = "btnAddSplit";
            this.btnAddSplit.Size = new System.Drawing.Size(76, 26);
            this.btnAddSplit.TabIndex = 0;
            this.btnAddSplit.Text = "Add Split";
            this.btnAddSplit.UseVisualStyleBackColor = true;
            this.btnAddSplit.Click += new System.EventHandler(this.btnAddSplit_Click);
            // 
            // RunBehaviour_GroupBox
            // 
            this.RunBehaviour_GroupBox.Controls.Add(this.chkCreativeStart);
            this.RunBehaviour_GroupBox.Controls.Add(this.chkIntroStart);
            this.RunBehaviour_GroupBox.Location = new System.Drawing.Point(191, 18);
            this.RunBehaviour_GroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.RunBehaviour_GroupBox.Name = "RunBehaviour_GroupBox";
            this.RunBehaviour_GroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.RunBehaviour_GroupBox.Size = new System.Drawing.Size(401, 87);
            this.RunBehaviour_GroupBox.TabIndex = 7;
            this.RunBehaviour_GroupBox.TabStop = false;
            this.RunBehaviour_GroupBox.Text = "Starts";
            // 
            // chkCreativeStart
            // 
            this.chkCreativeStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkCreativeStart.AutoSize = true;
            this.chkCreativeStart.Location = new System.Drawing.Point(214, 38);
            this.chkCreativeStart.Name = "chkCreativeStart";
            this.chkCreativeStart.Size = new System.Drawing.Size(109, 20);
            this.chkCreativeStart.TabIndex = 1;
            this.chkCreativeStart.Text = "Creative Start";
            this.chkCreativeStart.UseVisualStyleBackColor = true;
            this.chkCreativeStart.CheckedChanged += new System.EventHandler(this.ControlChanged);
            // 
            // chkIntroStart
            // 
            this.chkIntroStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkIntroStart.AutoSize = true;
            this.chkIntroStart.Location = new System.Drawing.Point(74, 38);
            this.chkIntroStart.Name = "chkIntroStart";
            this.chkIntroStart.Size = new System.Drawing.Size(113, 20);
            this.chkIntroStart.TabIndex = 0;
            this.chkIntroStart.Text = "Start after Intro";
            this.chkIntroStart.UseVisualStyleBackColor = true;
            this.chkIntroStart.CheckedChanged += new System.EventHandler(this.ControlChanged);
            // 
            // SortBy_GroupBox
            // 
            this.SortBy_GroupBox.Controls.Add(this.rdAlpha);
            this.SortBy_GroupBox.Controls.Add(this.rdType);
            this.SortBy_GroupBox.Location = new System.Drawing.Point(8, 18);
            this.SortBy_GroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.SortBy_GroupBox.Name = "SortBy_GroupBox";
            this.SortBy_GroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.SortBy_GroupBox.Size = new System.Drawing.Size(175, 87);
            this.SortBy_GroupBox.TabIndex = 6;
            this.SortBy_GroupBox.TabStop = false;
            this.SortBy_GroupBox.Text = "Sort Split Selects By";
            // 
            // rdAlpha
            // 
            this.rdAlpha.AutoSize = true;
            this.rdAlpha.Location = new System.Drawing.Point(8, 52);
            this.rdAlpha.Margin = new System.Windows.Forms.Padding(4);
            this.rdAlpha.Name = "rdAlpha";
            this.rdAlpha.Size = new System.Drawing.Size(103, 20);
            this.rdAlpha.TabIndex = 3;
            this.rdAlpha.Text = "Alphabetical";
            this.rdAlpha.UseVisualStyleBackColor = true;
            this.rdAlpha.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // rdType
            // 
            this.rdType.AutoSize = true;
            this.rdType.Checked = true;
            this.rdType.Location = new System.Drawing.Point(8, 23);
            this.rdType.Margin = new System.Windows.Forms.Padding(4);
            this.rdType.Name = "rdType";
            this.rdType.Size = new System.Drawing.Size(60, 20);
            this.rdType.TabIndex = 2;
            this.rdType.TabStop = true;
            this.rdType.Text = "Type";
            this.rdType.UseVisualStyleBackColor = true;
            this.rdType.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // ToolTips
            // 
            this.ToolTips.ShowAlways = true;
            // 
            // SubnauticaSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flowMain);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SubnauticaSettings";
            this.Size = new System.Drawing.Size(608, 159);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.flowMain.ResumeLayout(false);
            this.flowMain.PerformLayout();
            this.flowOptions.ResumeLayout(false);
            this.Options_GroupBox.ResumeLayout(false);
            this.RunBehaviour_GroupBox.ResumeLayout(false);
            this.RunBehaviour_GroupBox.PerformLayout();
            this.SortBy_GroupBox.ResumeLayout(false);
            this.SortBy_GroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cb_StartIntro;
        private System.Windows.Forms.CheckBox cb_Rocket;
        private System.Windows.Forms.FlowLayoutPanel flowMain;
        private System.Windows.Forms.FlowLayoutPanel flowOptions;
        private System.Windows.Forms.GroupBox Options_GroupBox;
        private System.Windows.Forms.Button btnAddSplit;
        private System.Windows.Forms.GroupBox RunBehaviour_GroupBox;
        private System.Windows.Forms.GroupBox SortBy_GroupBox;
        private System.Windows.Forms.RadioButton rdAlpha;
        private System.Windows.Forms.RadioButton rdType;
        private System.Windows.Forms.CheckBox chkCreativeStart;
        private System.Windows.Forms.CheckBox chkIntroStart;
        private System.Windows.Forms.ToolTip ToolTips;
    }
}
