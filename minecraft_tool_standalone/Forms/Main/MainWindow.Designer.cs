using System.Windows.Forms;

namespace minecraft_tool_standalone
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.FindButton = new System.Windows.Forms.Button();
            this.serverListView = new System.Windows.Forms.ListView();
            this.index = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Port = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Version = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Players = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.countryBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.onlineButton = new System.Windows.Forms.CheckBox();
            this.versionBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.noOnlineButton = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.advancedBox = new System.Windows.Forms.TextBox();
            this.advancedToggle = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setGamePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.importToMcButton = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // FindButton
            // 
            this.FindButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FindButton.Location = new System.Drawing.Point(15, 189);
            this.FindButton.Name = "FindButton";
            this.FindButton.Size = new System.Drawing.Size(142, 81);
            this.FindButton.TabIndex = 0;
            this.FindButton.Text = "Find";
            this.FindButton.UseVisualStyleBackColor = true;
            this.FindButton.Click += new System.EventHandler(this.FindButton_Click);
            // 
            // serverListView
            // 
            this.serverListView.AllowColumnReorder = true;
            this.serverListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serverListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.index,
            this.Ip,
            this.Port,
            this.Version,
            this.Description,
            this.Players});
            this.serverListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverListView.FullRowSelect = true;
            this.serverListView.GridLines = true;
            this.serverListView.HideSelection = false;
            this.serverListView.Location = new System.Drawing.Point(165, 49);
            this.serverListView.Name = "serverListView";
            this.serverListView.Size = new System.Drawing.Size(565, 341);
            this.serverListView.TabIndex = 6;
            this.serverListView.UseCompatibleStateImageBehavior = false;
            this.serverListView.View = System.Windows.Forms.View.Details;
            // 
            // index
            // 
            this.index.Text = "#";
            this.index.Width = 30;
            // 
            // Ip
            // 
            this.Ip.Text = "Ip";
            this.Ip.Width = 109;
            // 
            // Port
            // 
            this.Port.Text = "Port";
            // 
            // Version
            // 
            this.Version.Text = "Version";
            this.Version.Width = 110;
            // 
            // Description
            // 
            this.Description.Text = "Description";
            this.Description.Width = 180;
            // 
            // Players
            // 
            this.Players.Text = "Players";
            // 
            // countryBox
            // 
            this.countryBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.countryBox.FormattingEnabled = true;
            this.countryBox.Location = new System.Drawing.Point(15, 49);
            this.countryBox.Name = "countryBox";
            this.countryBox.Size = new System.Drawing.Size(142, 21);
            this.countryBox.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Country:";
            // 
            // onlineButton
            // 
            this.onlineButton.AutoSize = true;
            this.onlineButton.Location = new System.Drawing.Point(15, 125);
            this.onlineButton.Name = "onlineButton";
            this.onlineButton.Size = new System.Drawing.Size(114, 17);
            this.onlineButton.TabIndex = 11;
            this.onlineButton.Text = "Only players online";
            this.onlineButton.UseVisualStyleBackColor = true;
            this.onlineButton.CheckedChanged += new System.EventHandler(this.onlineButton_CheckedChanged);
            // 
            // versionBox
            // 
            this.versionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.versionBox.FormattingEnabled = true;
            this.versionBox.Items.AddRange(new object[] {
            "",
            "1.18.2",
            "1.18.1",
            "1.18",
            "1.17.1",
            "1.17",
            "1.16.5",
            "1.16.4",
            "1.16.3",
            "1.16.2",
            "1.16.1",
            "1.16.0",
            "1.15.2",
            "1.15.1",
            "1.15",
            "1.14.4",
            "1.14.3",
            "1.14.2",
            "1.14.1",
            "1.14",
            "1.13.2",
            "1.13.1",
            "1.13",
            "1.12.2",
            "1.12.1",
            "1.12",
            "1.11.2",
            "1.11.1",
            "1.11",
            "1.10.2",
            "1.10.1",
            "1.10",
            "1.9.4",
            "1.9.3",
            "1.9.1",
            "1.9",
            "1.8.9",
            "1.8.8",
            "1.8.7",
            "1.8.6",
            "1.8.5",
            "1.8.4",
            "1.8.3",
            "1.8.2",
            "1.8.1",
            "1.8",
            "1.7.10",
            "1.7.9",
            "1.7.8",
            "1.7.7",
            "1.7.6",
            "1.7.5",
            "1.7.4",
            "1.7.3",
            "1.7.2",
            "1.7.1",
            "1.7",
            "1.6.4",
            "1.6.3",
            "1.6.2",
            "1.6.1",
            "1.6",
            "1.5.2",
            "1.5.1",
            "1.5",
            "1.4.7",
            "1.4.6",
            "1.4.5",
            "1.4.4",
            "1.4.3",
            "1.4.2",
            "1.4.1",
            "1.4",
            "1.3.2",
            "1.3.1",
            "1.3",
            "1.2.5",
            "1.2.4",
            "1.2.3",
            "1.2.2",
            "1.2.1",
            "1.2",
            "1.1",
            "1.0.1",
            "1.0.0"});
            this.versionBox.Location = new System.Drawing.Point(15, 98);
            this.versionBox.Name = "versionBox";
            this.versionBox.Size = new System.Drawing.Size(142, 21);
            this.versionBox.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Version:";
            // 
            // noOnlineButton
            // 
            this.noOnlineButton.AutoSize = true;
            this.noOnlineButton.Location = new System.Drawing.Point(15, 148);
            this.noOnlineButton.Name = "noOnlineButton";
            this.noOnlineButton.Size = new System.Drawing.Size(107, 17);
            this.noOnlineButton.TabIndex = 12;
            this.noOnlineButton.Text = "No players online";
            this.noOnlineButton.UseVisualStyleBackColor = true;
            this.noOnlineButton.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 400);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(742, 26);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(160, 20);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(94, 21);
            this.toolStripStatusLabel3.Text = "DO NOT SHARE";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(202, 21);
            this.toolStripStatusLabel2.Text = "Prototype/Beta software, might break!";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.IsLink = true;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(94, 21);
            this.toolStripStatusLabel1.Text = "https://lohiv.com";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(15, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 2);
            this.label3.TabIndex = 14;
            // 
            // advancedBox
            // 
            this.advancedBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.advancedBox.Enabled = false;
            this.advancedBox.Location = new System.Drawing.Point(15, 370);
            this.advancedBox.Name = "advancedBox";
            this.advancedBox.Size = new System.Drawing.Size(142, 20);
            this.advancedBox.TabIndex = 15;
            // 
            // advancedToggle
            // 
            this.advancedToggle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.advancedToggle.AutoSize = true;
            this.advancedToggle.Location = new System.Drawing.Point(15, 347);
            this.advancedToggle.Name = "advancedToggle";
            this.advancedToggle.Size = new System.Drawing.Size(109, 17);
            this.advancedToggle.TabIndex = 16;
            this.advancedToggle.Text = "Additional queries";
            this.advancedToggle.UseVisualStyleBackColor = true;
            this.advancedToggle.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label4.Location = new System.Drawing.Point(162, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Double click an item to copy the IP";
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(742, 24);
            this.mainMenuStrip.TabIndex = 18;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToolStripMenuItem,
            this.setKeyToolStripMenuItem,
            this.setGamePathToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Enabled = false;
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // setKeyToolStripMenuItem
            // 
            this.setKeyToolStripMenuItem.Name = "setKeyToolStripMenuItem";
            this.setKeyToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.setKeyToolStripMenuItem.Text = "Set Key";
            this.setKeyToolStripMenuItem.Click += new System.EventHandler(this.setKeyToolStripMenuItem_Click);
            // 
            // setGamePathToolStripMenuItem
            // 
            this.setGamePathToolStripMenuItem.Name = "setGamePathToolStripMenuItem";
            this.setGamePathToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.setGamePathToolStripMenuItem.Text = "Game Path";
            this.setGamePathToolStripMenuItem.Click += new System.EventHandler(this.setGamePathToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(17, 333);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 2);
            this.label5.TabIndex = 19;
            // 
            // importToMcButton
            // 
            this.importToMcButton.Enabled = false;
            this.importToMcButton.Location = new System.Drawing.Point(16, 281);
            this.importToMcButton.Name = "importToMcButton";
            this.importToMcButton.Size = new System.Drawing.Size(142, 44);
            this.importToMcButton.TabIndex = 20;
            this.importToMcButton.Text = "Add to Minecraft";
            this.importToMcButton.UseVisualStyleBackColor = true;
            this.importToMcButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 426);
            this.Controls.Add(this.importToMcButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.advancedToggle);
            this.Controls.Add(this.advancedBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mainMenuStrip);
            this.Controls.Add(this.noOnlineButton);
            this.Controls.Add(this.onlineButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.versionBox);
            this.Controls.Add(this.countryBox);
            this.Controls.Add(this.serverListView);
            this.Controls.Add(this.FindButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.MinimumSize = new System.Drawing.Size(758, 465);
            this.Name = "MainForm";
            this.Text = "Minecraft tool";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button FindButton;
        private System.Windows.Forms.ListView serverListView;
        private System.Windows.Forms.ColumnHeader Ip;
        private System.Windows.Forms.ColumnHeader Version;
        private System.Windows.Forms.ColumnHeader Players;
        private System.Windows.Forms.ColumnHeader Port;
        private System.Windows.Forms.ColumnHeader Description;
        private System.Windows.Forms.ComboBox countryBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox onlineButton;
        private System.Windows.Forms.ComboBox versionBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox noOnlineButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox advancedBox;
        private System.Windows.Forms.CheckBox advancedToggle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.Button importToMcButton;
        private System.Windows.Forms.ToolStripMenuItem setGamePathToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader index;
    }
}

