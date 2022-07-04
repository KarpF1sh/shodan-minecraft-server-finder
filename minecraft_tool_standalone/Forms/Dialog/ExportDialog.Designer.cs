namespace minecraft_tool_standalone.Forms.Dialog
{
    partial class ExportDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportDialog));
            this.ipCheck = new System.Windows.Forms.CheckBox();
            this.portCheck = new System.Windows.Forms.CheckBox();
            this.descCheck = new System.Windows.Forms.CheckBox();
            this.onlineCheck = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lineNumberCheck = new System.Windows.Forms.CheckBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.previewText = new System.Windows.Forms.TextBox();
            this.PreviewLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ipCheck
            // 
            resources.ApplyResources(this.ipCheck, "ipCheck");
            this.ipCheck.Name = "ipCheck";
            this.ipCheck.UseVisualStyleBackColor = true;
            this.ipCheck.CheckedChanged += new System.EventHandler(this.ipCheck_CheckedChanged);
            // 
            // portCheck
            // 
            resources.ApplyResources(this.portCheck, "portCheck");
            this.portCheck.Name = "portCheck";
            this.portCheck.UseVisualStyleBackColor = true;
            this.portCheck.CheckedChanged += new System.EventHandler(this.portCheck_CheckedChanged);
            // 
            // descCheck
            // 
            resources.ApplyResources(this.descCheck, "descCheck");
            this.descCheck.Name = "descCheck";
            this.descCheck.UseVisualStyleBackColor = true;
            this.descCheck.CheckedChanged += new System.EventHandler(this.descCheck_CheckedChanged);
            // 
            // onlineCheck
            // 
            resources.ApplyResources(this.onlineCheck, "onlineCheck");
            this.onlineCheck.Name = "onlineCheck";
            this.onlineCheck.UseVisualStyleBackColor = true;
            this.onlineCheck.CheckedChanged += new System.EventHandler(this.onlineCheck_CheckedChanged);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lineNumberCheck
            // 
            resources.ApplyResources(this.lineNumberCheck, "lineNumberCheck");
            this.lineNumberCheck.Name = "lineNumberCheck";
            this.lineNumberCheck.UseVisualStyleBackColor = true;
            this.lineNumberCheck.CheckedChanged += new System.EventHandler(this.lineNumberCheck_CheckedChanged);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // previewText
            // 
            this.previewText.BackColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.previewText, "previewText");
            this.previewText.Name = "previewText";
            this.previewText.ReadOnly = true;
            // 
            // PreviewLabel
            // 
            resources.ApplyResources(this.PreviewLabel, "PreviewLabel");
            this.PreviewLabel.Name = "PreviewLabel";
            // 
            // ExportDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PreviewLabel);
            this.Controls.Add(this.previewText);
            this.Controls.Add(this.lineNumberCheck);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.onlineCheck);
            this.Controls.Add(this.descCheck);
            this.Controls.Add(this.portCheck);
            this.Controls.Add(this.ipCheck);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ExportDialog";
            this.Load += new System.EventHandler(this.ExportDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ipCheck;
        private System.Windows.Forms.CheckBox portCheck;
        private System.Windows.Forms.CheckBox descCheck;
        private System.Windows.Forms.CheckBox onlineCheck;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox lineNumberCheck;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox previewText;
        private System.Windows.Forms.Label PreviewLabel;
    }
}