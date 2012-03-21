namespace Fireball
{
    partial class SettingsForm
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
            this.components = new System.ComponentModel.Container();
            this.tray = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.traySubCaptureArea = new System.Windows.Forms.ToolStripMenuItem();
            this.traySubCaptureScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.traySubSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.traySubExit = new System.Windows.Forms.ToolStripMenuItem();
            this.lCaptureScreen = new System.Windows.Forms.Label();
            this.gHotkeys = new System.Windows.Forms.GroupBox();
            this.hkArea = new Fireball.UI.HotkeySelectControl();
            this.hkScreen = new Fireball.UI.HotkeySelectControl();
            this.lCaptureArea = new System.Windows.Forms.Label();
            this.gPlugins = new System.Windows.Forms.GroupBox();
            this.bPluginSettings = new System.Windows.Forms.Button();
            this.lActive = new System.Windows.Forms.Label();
            this.cPlugins = new System.Windows.Forms.ComboBox();
            this.cAutoStart = new System.Windows.Forms.CheckBox();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lAuthor = new System.Windows.Forms.Label();
            this.lVersion = new System.Windows.Forms.Label();
            this.lName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bCancel = new System.Windows.Forms.Button();
            this.bApply = new System.Windows.Forms.Button();
            this.trayMenu.SuspendLayout();
            this.gHotkeys.SuspendLayout();
            this.gPlugins.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tray
            // 
            this.tray.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.tray.ContextMenuStrip = this.trayMenu;
            this.tray.Text = "Fireball";
            this.tray.Visible = true;
            this.tray.BalloonTipClicked += new System.EventHandler(this.TrayBalloonTipClicked);
            this.tray.DoubleClick += new System.EventHandler(this.TrayDoubleClick);
            // 
            // trayMenu
            // 
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.traySubCaptureArea,
            this.traySubCaptureScreen,
            this.toolStripMenuItem1,
            this.traySubSettings,
            this.traySubExit});
            this.trayMenu.Name = "contextMenuStrip1";
            this.trayMenu.Size = new System.Drawing.Size(154, 98);
            // 
            // traySubCaptureArea
            // 
            this.traySubCaptureArea.Image = global::Fireball.Properties.Resources.captureArea;
            this.traySubCaptureArea.Name = "traySubCaptureArea";
            this.traySubCaptureArea.Size = new System.Drawing.Size(153, 22);
            this.traySubCaptureArea.Text = "Capture area";
            this.traySubCaptureArea.Click += new System.EventHandler(this.TraySubCaptureAreaClick);
            // 
            // traySubCaptureScreen
            // 
            this.traySubCaptureScreen.Image = global::Fireball.Properties.Resources.captureScreen;
            this.traySubCaptureScreen.Name = "traySubCaptureScreen";
            this.traySubCaptureScreen.Size = new System.Drawing.Size(153, 22);
            this.traySubCaptureScreen.Text = "Capture screen";
            this.traySubCaptureScreen.Click += new System.EventHandler(this.TraySubCaptureScreenClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(150, 6);
            // 
            // traySubSettings
            // 
            this.traySubSettings.Image = global::Fireball.Properties.Resources.settings;
            this.traySubSettings.Name = "traySubSettings";
            this.traySubSettings.Size = new System.Drawing.Size(153, 22);
            this.traySubSettings.Text = "Settings";
            this.traySubSettings.Click += new System.EventHandler(this.TraySubSettingsClick);
            // 
            // traySubExit
            // 
            this.traySubExit.Image = global::Fireball.Properties.Resources.exit;
            this.traySubExit.Name = "traySubExit";
            this.traySubExit.Size = new System.Drawing.Size(153, 22);
            this.traySubExit.Text = "Exit";
            this.traySubExit.Click += new System.EventHandler(this.TraySubExitClick);
            // 
            // lCaptureScreen
            // 
            this.lCaptureScreen.AutoSize = true;
            this.lCaptureScreen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lCaptureScreen.Location = new System.Drawing.Point(9, 20);
            this.lCaptureScreen.Name = "lCaptureScreen";
            this.lCaptureScreen.Size = new System.Drawing.Size(96, 13);
            this.lCaptureScreen.TabIndex = 1;
            this.lCaptureScreen.Text = "Capture screen:";
            // 
            // gHotkeys
            // 
            this.gHotkeys.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gHotkeys.Controls.Add(this.hkArea);
            this.gHotkeys.Controls.Add(this.hkScreen);
            this.gHotkeys.Controls.Add(this.lCaptureArea);
            this.gHotkeys.Controls.Add(this.lCaptureScreen);
            this.gHotkeys.Location = new System.Drawing.Point(6, 6);
            this.gHotkeys.Name = "gHotkeys";
            this.gHotkeys.Size = new System.Drawing.Size(330, 110);
            this.gHotkeys.TabIndex = 2;
            this.gHotkeys.TabStop = false;
            this.gHotkeys.Text = "Hotkeys:";
            // 
            // hkArea
            // 
            this.hkArea.Alt = false;
            this.hkArea.Ctrl = false;
            this.hkArea.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hkArea.Hotkey = System.Windows.Forms.Keys.None;
            this.hkArea.Location = new System.Drawing.Point(9, 78);
            this.hkArea.MinimumSize = new System.Drawing.Size(258, 23);
            this.hkArea.Name = "hkArea";
            this.hkArea.Shift = false;
            this.hkArea.Size = new System.Drawing.Size(311, 23);
            this.hkArea.TabIndex = 5;
            this.hkArea.Win = false;
            // 
            // hkScreen
            // 
            this.hkScreen.Alt = false;
            this.hkScreen.Ctrl = false;
            this.hkScreen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hkScreen.Hotkey = System.Windows.Forms.Keys.None;
            this.hkScreen.Location = new System.Drawing.Point(9, 36);
            this.hkScreen.MinimumSize = new System.Drawing.Size(258, 23);
            this.hkScreen.Name = "hkScreen";
            this.hkScreen.Shift = false;
            this.hkScreen.Size = new System.Drawing.Size(311, 23);
            this.hkScreen.TabIndex = 4;
            this.hkScreen.Win = false;
            // 
            // lCaptureArea
            // 
            this.lCaptureArea.AutoSize = true;
            this.lCaptureArea.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lCaptureArea.Location = new System.Drawing.Point(9, 62);
            this.lCaptureArea.Name = "lCaptureArea";
            this.lCaptureArea.Size = new System.Drawing.Size(84, 13);
            this.lCaptureArea.TabIndex = 3;
            this.lCaptureArea.Text = "Capture area:";
            // 
            // gPlugins
            // 
            this.gPlugins.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gPlugins.Controls.Add(this.bPluginSettings);
            this.gPlugins.Controls.Add(this.lActive);
            this.gPlugins.Controls.Add(this.cPlugins);
            this.gPlugins.Location = new System.Drawing.Point(6, 122);
            this.gPlugins.Name = "gPlugins";
            this.gPlugins.Size = new System.Drawing.Size(330, 53);
            this.gPlugins.TabIndex = 3;
            this.gPlugins.TabStop = false;
            this.gPlugins.Text = "Plugins:";
            // 
            // bPluginSettings
            // 
            this.bPluginSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bPluginSettings.Image = global::Fireball.Properties.Resources.settings;
            this.bPluginSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bPluginSettings.Location = new System.Drawing.Point(250, 19);
            this.bPluginSettings.Name = "bPluginSettings";
            this.bPluginSettings.Size = new System.Drawing.Size(70, 23);
            this.bPluginSettings.TabIndex = 5;
            this.bPluginSettings.TabStop = false;
            this.bPluginSettings.Text = "Settings";
            this.bPluginSettings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bPluginSettings.UseVisualStyleBackColor = true;
            // 
            // lActive
            // 
            this.lActive.AutoSize = true;
            this.lActive.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lActive.Location = new System.Drawing.Point(6, 23);
            this.lActive.Name = "lActive";
            this.lActive.Size = new System.Drawing.Size(83, 13);
            this.lActive.TabIndex = 4;
            this.lActive.Text = "Active plugin:";
            // 
            // cPlugins
            // 
            this.cPlugins.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cPlugins.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cPlugins.FormattingEnabled = true;
            this.cPlugins.Location = new System.Drawing.Point(108, 20);
            this.cPlugins.Name = "cPlugins";
            this.cPlugins.Size = new System.Drawing.Size(142, 21);
            this.cPlugins.TabIndex = 0;
            this.cPlugins.TabStop = false;
            this.cPlugins.SelectedIndexChanged += new System.EventHandler(this.CPluginsSelectedIndexChanged);
            // 
            // cAutoStart
            // 
            this.cAutoStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cAutoStart.AutoSize = true;
            this.cAutoStart.Location = new System.Drawing.Point(15, 183);
            this.cAutoStart.Name = "cAutoStart";
            this.cAutoStart.Size = new System.Drawing.Size(195, 17);
            this.cAutoStart.TabIndex = 6;
            this.cAutoStart.TabStop = false;
            this.cAutoStart.Text = "Start Fireball when computer starts";
            this.cAutoStart.UseVisualStyleBackColor = true;
            this.cAutoStart.CheckedChanged += new System.EventHandler(this.CAutoStartCheckedChanged);
            // 
            // mainTabControl
            // 
            this.mainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTabControl.Controls.Add(this.tabPage1);
            this.mainTabControl.Controls.Add(this.tabPage2);
            this.mainTabControl.Location = new System.Drawing.Point(12, 12);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(350, 233);
            this.mainTabControl.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gHotkeys);
            this.tabPage1.Controls.Add(this.gPlugins);
            this.tabPage1.Controls.Add(this.cAutoStart);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(342, 207);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lAuthor);
            this.tabPage2.Controls.Add(this.lVersion);
            this.tabPage2.Controls.Add(this.lName);
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(342, 207);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "About";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lAuthor
            // 
            this.lAuthor.AutoSize = true;
            this.lAuthor.Location = new System.Drawing.Point(140, 155);
            this.lAuthor.Name = "lAuthor";
            this.lAuthor.Size = new System.Drawing.Size(90, 13);
            this.lAuthor.TabIndex = 3;
            this.lAuthor.Text = "Created by TBXin";
            // 
            // lVersion
            // 
            this.lVersion.AutoSize = true;
            this.lVersion.Location = new System.Drawing.Point(141, 59);
            this.lVersion.Name = "lVersion";
            this.lVersion.Size = new System.Drawing.Size(46, 13);
            this.lVersion.TabIndex = 2;
            this.lVersion.Text = "Version:";
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lName.Location = new System.Drawing.Point(140, 40);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(70, 19);
            this.lName.TabIndex = 1;
            this.lName.Text = "Fireball";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Fireball.Properties.Resources.fireball_logo;
            this.pictureBox1.Location = new System.Drawing.Point(6, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.Image = global::Fireball.Properties.Resources.cancel;
            this.bCancel.Location = new System.Drawing.Point(262, 247);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(100, 30);
            this.bCancel.TabIndex = 4;
            this.bCancel.TabStop = false;
            this.bCancel.Text = "Cancel";
            this.bCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.BCancelClick);
            // 
            // bApply
            // 
            this.bApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bApply.Image = global::Fireball.Properties.Resources.apply;
            this.bApply.Location = new System.Drawing.Point(143, 247);
            this.bApply.Name = "bApply";
            this.bApply.Size = new System.Drawing.Size(120, 30);
            this.bApply.TabIndex = 5;
            this.bApply.TabStop = false;
            this.bApply.Text = "Apply && Close";
            this.bApply.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bApply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bApply.UseVisualStyleBackColor = true;
            this.bApply.Click += new System.EventHandler(this.BApplyClick);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 280);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bApply);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fireball Settings";
            this.trayMenu.ResumeLayout(false);
            this.gHotkeys.ResumeLayout(false);
            this.gHotkeys.PerformLayout();
            this.gPlugins.ResumeLayout(false);
            this.gPlugins.PerformLayout();
            this.mainTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon tray;
        private System.Windows.Forms.Label lCaptureScreen;
        private System.Windows.Forms.GroupBox gHotkeys;
        private System.Windows.Forms.Label lCaptureArea;
        private System.Windows.Forms.GroupBox gPlugins;
        private System.Windows.Forms.Label lActive;
        private System.Windows.Forms.ComboBox cPlugins;
        private System.Windows.Forms.Button bPluginSettings;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bApply;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem traySubSettings;
        private System.Windows.Forms.ToolStripMenuItem traySubExit;
        private System.Windows.Forms.ToolStripMenuItem traySubCaptureArea;
        private System.Windows.Forms.ToolStripMenuItem traySubCaptureScreen;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.CheckBox cAutoStart;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lVersion;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Label lAuthor;
        private UI.HotkeySelectControl hkScreen;
        private UI.HotkeySelectControl hkArea;
    }
}