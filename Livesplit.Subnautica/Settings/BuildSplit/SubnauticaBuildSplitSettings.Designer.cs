namespace LiveSplit.Subnautica
{
    partial class SubnauticaBuildSplitSettings
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
            this.BuildSplitOptions_GroupBox = new System.Windows.Forms.GroupBox();
            this.Other_GroupBox = new System.Windows.Forms.GroupBox();
            this.ChkSplitOnce = new System.Windows.Forms.CheckBox();
            this.BtnAddCondition = new System.Windows.Forms.Button();
            this.BuildSplit_GroupBox = new System.Windows.Forms.GroupBox();
            this.SortBy_GroupBox = new System.Windows.Forms.GroupBox();
            this.RdAlpha = new System.Windows.Forms.RadioButton();
            this.RdType = new System.Windows.Forms.RadioButton();
            this.flowMain = new System.Windows.Forms.FlowLayoutPanel();
            this.flowOptions = new System.Windows.Forms.FlowLayoutPanel();
            this.BuildSplitOptions_GroupBox.SuspendLayout();
            this.Other_GroupBox.SuspendLayout();
            this.SortBy_GroupBox.SuspendLayout();
            this.flowMain.SuspendLayout();
            this.flowOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // BuildSplitOptions_GroupBox
            // 
            this.BuildSplitOptions_GroupBox.Controls.Add(this.Other_GroupBox);
            this.BuildSplitOptions_GroupBox.Controls.Add(this.BtnAddCondition);
            this.BuildSplitOptions_GroupBox.Controls.Add(this.BuildSplit_GroupBox);
            this.BuildSplitOptions_GroupBox.Controls.Add(this.SortBy_GroupBox);
            this.BuildSplitOptions_GroupBox.Location = new System.Drawing.Point(3, 3);
            this.BuildSplitOptions_GroupBox.Name = "BuildSplitOptions_GroupBox";
            this.BuildSplitOptions_GroupBox.Padding = new System.Windows.Forms.Padding(0);
            this.BuildSplitOptions_GroupBox.Size = new System.Drawing.Size(466, 135);
            this.BuildSplitOptions_GroupBox.TabIndex = 6;
            this.BuildSplitOptions_GroupBox.TabStop = false;
            this.BuildSplitOptions_GroupBox.Text = "Build Split";
            // 
            // Other_GroupBox
            // 
            this.Other_GroupBox.Controls.Add(this.ChkSplitOnce);
            this.Other_GroupBox.Location = new System.Drawing.Point(296, 15);
            this.Other_GroupBox.Name = "Other_GroupBox";
            this.Other_GroupBox.Size = new System.Drawing.Size(164, 81);
            this.Other_GroupBox.TabIndex = 8;
            this.Other_GroupBox.TabStop = false;
            this.Other_GroupBox.Text = "Others";
            // 
            // ChkSplitOnce
            // 
            this.ChkSplitOnce.AutoSize = true;
            this.ChkSplitOnce.Location = new System.Drawing.Point(6, 23);
            this.ChkSplitOnce.Name = "ChkSplitOnce";
            this.ChkSplitOnce.Size = new System.Drawing.Size(99, 17);
            this.ChkSplitOnce.TabIndex = 0;
            this.ChkSplitOnce.Text = "Only Split Once";
            this.ChkSplitOnce.UseVisualStyleBackColor = true;
            this.ChkSplitOnce.CheckedChanged += new System.EventHandler(this.ControlChanged);
            // 
            // BtnAddCondition
            // 
            this.BtnAddCondition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddCondition.Location = new System.Drawing.Point(6, 102);
            this.BtnAddCondition.Name = "BtnAddCondition";
            this.BtnAddCondition.Size = new System.Drawing.Size(116, 23);
            this.BtnAddCondition.TabIndex = 0;
            this.BtnAddCondition.Text = "Add Condion";
            this.BtnAddCondition.UseVisualStyleBackColor = true;
            this.BtnAddCondition.Click += new System.EventHandler(this.BtnAddCondition_Click);
            // 
            // BuildSplit_GroupBox
            // 
            this.BuildSplit_GroupBox.Location = new System.Drawing.Point(128, 15);
            this.BuildSplit_GroupBox.Name = "BuildSplit_GroupBox";
            this.BuildSplit_GroupBox.Size = new System.Drawing.Size(162, 81);
            this.BuildSplit_GroupBox.TabIndex = 7;
            this.BuildSplit_GroupBox.TabStop = false;
            this.BuildSplit_GroupBox.Text = "Build Split";
            // 
            // SortBy_GroupBox
            // 
            this.SortBy_GroupBox.Controls.Add(this.RdAlpha);
            this.SortBy_GroupBox.Controls.Add(this.RdType);
            this.SortBy_GroupBox.Location = new System.Drawing.Point(6, 15);
            this.SortBy_GroupBox.Name = "SortBy_GroupBox";
            this.SortBy_GroupBox.Size = new System.Drawing.Size(116, 81);
            this.SortBy_GroupBox.TabIndex = 6;
            this.SortBy_GroupBox.TabStop = false;
            this.SortBy_GroupBox.Text = "Sort Split Selects By";
            // 
            // RdAlpha
            // 
            this.RdAlpha.AutoSize = true;
            this.RdAlpha.Checked = true;
            this.RdAlpha.Location = new System.Drawing.Point(6, 42);
            this.RdAlpha.Name = "RdAlpha";
            this.RdAlpha.Size = new System.Drawing.Size(83, 17);
            this.RdAlpha.TabIndex = 3;
            this.RdAlpha.TabStop = true;
            this.RdAlpha.Text = "Alphabetical";
            this.RdAlpha.UseVisualStyleBackColor = true;
            this.RdAlpha.CheckedChanged += new System.EventHandler(this.RdSort_CheckedChanged);
            // 
            // RdType
            // 
            this.RdType.AutoSize = true;
            this.RdType.Location = new System.Drawing.Point(6, 19);
            this.RdType.Name = "RdType";
            this.RdType.Size = new System.Drawing.Size(49, 17);
            this.RdType.TabIndex = 2;
            this.RdType.Text = "Type";
            this.RdType.UseVisualStyleBackColor = true;
            this.RdType.CheckedChanged += new System.EventHandler(this.RdSort_CheckedChanged);
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
            this.flowMain.Size = new System.Drawing.Size(472, 141);
            this.flowMain.TabIndex = 0;
            this.flowMain.WrapContents = false;
            this.flowMain.DragDrop += new System.Windows.Forms.DragEventHandler(this.flowMain_DragDrop);
            this.flowMain.DragEnter += new System.Windows.Forms.DragEventHandler(this.flowMain_DragEnter);
            this.flowMain.DragOver += new System.Windows.Forms.DragEventHandler(this.flowMain_DragOver);
            this.flowMain.DragLeave += new System.EventHandler(this.flowMain_DragLeave);
            this.flowMain.Paint += new System.Windows.Forms.PaintEventHandler(this.flowMain_Paint);
            // 
            // flowOptions
            // 
            this.flowOptions.AutoSize = true;
            this.flowOptions.Controls.Add(this.BuildSplitOptions_GroupBox);
            this.flowOptions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowOptions.Location = new System.Drawing.Point(0, 0);
            this.flowOptions.Margin = new System.Windows.Forms.Padding(0);
            this.flowOptions.Name = "flowOptions";
            this.flowOptions.Size = new System.Drawing.Size(472, 141);
            this.flowOptions.TabIndex = 2;
            // 
            // SubnauticaBuildSplitSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flowMain);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SubnauticaBuildSplitSettings";
            this.Size = new System.Drawing.Size(472, 141);
            this.BuildSplitOptions_GroupBox.ResumeLayout(false);
            this.Other_GroupBox.ResumeLayout(false);
            this.Other_GroupBox.PerformLayout();
            this.SortBy_GroupBox.ResumeLayout(false);
            this.SortBy_GroupBox.PerformLayout();
            this.flowMain.ResumeLayout(false);
            this.flowMain.PerformLayout();
            this.flowOptions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox BuildSplitOptions_GroupBox;
        private System.Windows.Forms.GroupBox Other_GroupBox;
        private System.Windows.Forms.CheckBox ChkSplitOnce;
        private System.Windows.Forms.Button BtnAddCondition;
        private System.Windows.Forms.GroupBox BuildSplit_GroupBox;
        private System.Windows.Forms.GroupBox SortBy_GroupBox;
        private System.Windows.Forms.RadioButton RdAlpha;
        private System.Windows.Forms.RadioButton RdType;
        private System.Windows.Forms.FlowLayoutPanel flowMain;
        private System.Windows.Forms.FlowLayoutPanel flowOptions;
    }
}


