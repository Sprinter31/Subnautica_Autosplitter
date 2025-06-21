namespace Livesplit.Subnautica
{
    partial class SubnauticaSplitSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubnauticaSplitSettings));
            this.btnAddBelow = new System.Windows.Forms.Button();
            this.btnAddAbove = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.cboName = new System.Windows.Forms.ComboBox();
            this.ToolTips = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btnAddBelow
            // 
            this.btnAddBelow.Location = new System.Drawing.Point(508, 4);
            this.btnAddBelow.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddBelow.Name = "btnAddBelow";
            this.btnAddBelow.Size = new System.Drawing.Size(45, 28);
            this.btnAddBelow.TabIndex = 14;
            this.btnAddBelow.Text = "+↓";
            this.btnAddBelow.UseVisualStyleBackColor = true;
            // 
            // btnAddAbove
            // 
            this.btnAddAbove.Location = new System.Drawing.Point(455, 4);
            this.btnAddAbove.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddAbove.Name = "btnAddAbove";
            this.btnAddAbove.Size = new System.Drawing.Size(45, 28);
            this.btnAddAbove.TabIndex = 13;
            this.btnAddAbove.Text = "+↑";
            this.btnAddAbove.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(412, 4);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(35, 28);
            this.btnEdit.TabIndex = 12;
            this.btnEdit.Text = "✏";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnRemove.Image")));
            this.btnRemove.Location = new System.Drawing.Point(369, 4);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(35, 28);
            this.btnRemove.TabIndex = 10;
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // cboName
            // 
            this.cboName.FormattingEnabled = true;
            this.cboName.Location = new System.Drawing.Point(33, 6);
            this.cboName.Margin = new System.Windows.Forms.Padding(4);
            this.cboName.Name = "cboName";
            this.cboName.Size = new System.Drawing.Size(327, 24);
            this.cboName.TabIndex = 9;
            this.cboName.SelectedIndexChanged += new System.EventHandler(this.cboName_SelectedIndexChanged);
            // 
            // ToolTips
            // 
            this.ToolTips.ShowAlways = true;
            // 
            // SubnauticaSplitSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.btnAddBelow);
            this.Controls.Add(this.btnAddAbove);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.cboName);
            this.Name = "SubnauticaSplitSettings";
            this.Size = new System.Drawing.Size(557, 37);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnAddBelow;
        public System.Windows.Forms.Button btnAddAbove;
        public System.Windows.Forms.Button btnEdit;
        public System.Windows.Forms.Button btnRemove;
        public System.Windows.Forms.ComboBox cboName;
        private System.Windows.Forms.ToolTip ToolTips;
    }
}
