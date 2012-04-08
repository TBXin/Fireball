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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.tray = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.traySubCaptureArea = new System.Windows.Forms.ToolStripMenuItem();
            this.traySubCaptureScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.traySubSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.traySubCheckForUpdates = new System.Windows.Forms.ToolStripMenuItem();
            this.traySubAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.traySubExit = new System.Windows.Forms.ToolStripMenuItem();
            this.lCaptureScreen = new System.Windows.Forms.Label();
            this.lCaptureArea = new System.Windows.Forms.Label();
            this.cAutoStart = new System.Windows.Forms.CheckBox();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.generalTab = new System.Windows.Forms.TabPage();
            this.bCaptureModeHelp = new System.Windows.Forms.Button();
            this.cCaptureMode = new System.Windows.Forms.ComboBox();
            this.lCaptureMode = new System.Windows.Forms.Label();
            this.hkArea = new Fireball.UI.HotkeySelectControl();
            this.cNotification = new System.Windows.Forms.ComboBox();
            this.hkScreen = new Fireball.UI.HotkeySelectControl();
            this.bPluginSettings = new System.Windows.Forms.Button();
            this.lNotification = new System.Windows.Forms.Label();
            this.lActive = new System.Windows.Forms.Label();
            this.cPlugins = new System.Windows.Forms.ComboBox();
            this.aboutTab = new System.Windows.Forms.TabPage();
            this.lAuthor = new System.Windows.Forms.Label();
            this.lVersion = new System.Windows.Forms.Label();
            this.lName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cLanguage = new System.Windows.Forms.ComboBox();
            this.mainToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.updaterControl = new wyDay.Controls.AutomaticUpdater();
            this.bCancel = new System.Windows.Forms.Button();
            this.bApply = new System.Windows.Forms.Button();
            this.trayMenu.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.generalTab.SuspendLayout();
            this.aboutTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updaterControl)).BeginInit();
            this.SuspendLayout();
            // 
            // tray
            // 
            this.tray.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.tray.ContextMenuStrip = this.trayMenu;
            resources.ApplyResources(this.tray, "tray");
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
            this.traySubCheckForUpdates,
            this.traySubAbout,
            this.toolStripMenuItem2,
            this.traySubExit});
            this.trayMenu.Name = "contextMenuStrip1";
            resources.ApplyResources(this.trayMenu, "trayMenu");
            // 
            // traySubCaptureArea
            // 
            this.traySubCaptureArea.Image = global::Fireball.Properties.Resources.captureArea;
            this.traySubCaptureArea.Name = "traySubCaptureArea";
            resources.ApplyResources(this.traySubCaptureArea, "traySubCaptureArea");
            this.traySubCaptureArea.Click += new System.EventHandler(this.TraySubCaptureAreaClick);
            // 
            // traySubCaptureScreen
            // 
            this.traySubCaptureScreen.Image = global::Fireball.Properties.Resources.captureScreen;
            this.traySubCaptureScreen.Name = "traySubCaptureScreen";
            resources.ApplyResources(this.traySubCaptureScreen, "traySubCaptureScreen");
            this.traySubCaptureScreen.Click += new System.EventHandler(this.TraySubCaptureScreenClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // traySubSettings
            // 
            this.traySubSettings.Image = global::Fireball.Properties.Resources.settings;
            this.traySubSettings.Name = "traySubSettings";
            resources.ApplyResources(this.traySubSettings, "traySubSettings");
            this.traySubSettings.Click += new System.EventHandler(this.TraySubSettingsClick);
            // 
            // traySubCheckForUpdates
            // 
            this.traySubCheckForUpdates.Image = global::Fireball.Properties.Resources.checkForUpdates;
            this.traySubCheckForUpdates.Name = "traySubCheckForUpdates";
            resources.ApplyResources(this.traySubCheckForUpdates, "traySubCheckForUpdates");
            this.traySubCheckForUpdates.Click += new System.EventHandler(this.TraySubCheckForUpdatesClick);
            // 
            // traySubAbout
            // 
            this.traySubAbout.Image = global::Fireball.Properties.Resources.about;
            this.traySubAbout.Name = "traySubAbout";
            resources.ApplyResources(this.traySubAbout, "traySubAbout");
            this.traySubAbout.Click += new System.EventHandler(this.TraySubAboutClick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // traySubExit
            // 
            this.traySubExit.Image = global::Fireball.Properties.Resources.exit;
            this.traySubExit.Name = "traySubExit";
            resources.ApplyResources(this.traySubExit, "traySubExit");
            this.traySubExit.Click += new System.EventHandler(this.TraySubExitClick);
            // 
            // lCaptureScreen
            // 
            resources.ApplyResources(this.lCaptureScreen, "lCaptureScreen");
            this.lCaptureScreen.Name = "lCaptureScreen";
            // 
            // lCaptureArea
            // 
            resources.ApplyResources(this.lCaptureArea, "lCaptureArea");
            this.lCaptureArea.Name = "lCaptureArea";
            // 
            // cAutoStart
            // 
            resources.ApplyResources(this.cAutoStart, "cAutoStart");
            this.cAutoStart.Name = "cAutoStart";
            this.cAutoStart.TabStop = false;
            this.cAutoStart.UseVisualStyleBackColor = true;
            // 
            // mainTabControl
            // 
            resources.ApplyResources(this.mainTabControl, "mainTabControl");
            this.mainTabControl.Controls.Add(this.generalTab);
            this.mainTabControl.Controls.Add(this.aboutTab);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            // 
            // generalTab
            // 
            this.generalTab.Controls.Add(this.bCaptureModeHelp);
            this.generalTab.Controls.Add(this.cCaptureMode);
            this.generalTab.Controls.Add(this.lCaptureMode);
            this.generalTab.Controls.Add(this.hkArea);
            this.generalTab.Controls.Add(this.cNotification);
            this.generalTab.Controls.Add(this.hkScreen);
            this.generalTab.Controls.Add(this.bPluginSettings);
            this.generalTab.Controls.Add(this.lCaptureArea);
            this.generalTab.Controls.Add(this.lNotification);
            this.generalTab.Controls.Add(this.lCaptureScreen);
            this.generalTab.Controls.Add(this.lActive);
            this.generalTab.Controls.Add(this.cPlugins);
            this.generalTab.Controls.Add(this.cAutoStart);
            resources.ApplyResources(this.generalTab, "generalTab");
            this.generalTab.Name = "generalTab";
            this.generalTab.UseVisualStyleBackColor = true;
            // 
            // bCaptureModeHelp
            // 
            this.bCaptureModeHelp.Image = global::Fireball.Properties.Resources.about;
            resources.ApplyResources(this.bCaptureModeHelp, "bCaptureModeHelp");
            this.bCaptureModeHelp.Name = "bCaptureModeHelp";
            this.bCaptureModeHelp.UseVisualStyleBackColor = true;
            this.bCaptureModeHelp.Click += new System.EventHandler(this.BCaptureModeHelpPressed);
            // 
            // cCaptureMode
            // 
            this.cCaptureMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cCaptureMode.FormattingEnabled = true;
            resources.ApplyResources(this.cCaptureMode, "cCaptureMode");
            this.cCaptureMode.Name = "cCaptureMode";
            this.cCaptureMode.TabStop = false;
            // 
            // lCaptureMode
            // 
            resources.ApplyResources(this.lCaptureMode, "lCaptureMode");
            this.lCaptureMode.Name = "lCaptureMode";
            // 
            // hkArea
            // 
            this.hkArea.Alt = false;
            this.hkArea.Ctrl = false;
            resources.ApplyResources(this.hkArea, "hkArea");
            this.hkArea.Hotkey = System.Windows.Forms.Keys.None;
            this.hkArea.MinimumSize = new System.Drawing.Size(258, 23);
            this.hkArea.Name = "hkArea";
            this.hkArea.Shift = false;
            this.hkArea.Win = false;
            // 
            // cNotification
            // 
            this.cNotification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cNotification.FormattingEnabled = true;
            resources.ApplyResources(this.cNotification, "cNotification");
            this.cNotification.Name = "cNotification";
            this.cNotification.TabStop = false;
            // 
            // hkScreen
            // 
            this.hkScreen.Alt = false;
            this.hkScreen.Ctrl = false;
            resources.ApplyResources(this.hkScreen, "hkScreen");
            this.hkScreen.Hotkey = System.Windows.Forms.Keys.None;
            this.hkScreen.MinimumSize = new System.Drawing.Size(258, 23);
            this.hkScreen.Name = "hkScreen";
            this.hkScreen.Shift = false;
            this.hkScreen.Win = false;
            // 
            // bPluginSettings
            // 
            this.bPluginSettings.Image = global::Fireball.Properties.Resources.settings;
            resources.ApplyResources(this.bPluginSettings, "bPluginSettings");
            this.bPluginSettings.Name = "bPluginSettings";
            this.bPluginSettings.TabStop = false;
            this.bPluginSettings.UseVisualStyleBackColor = true;
            // 
            // lNotification
            // 
            resources.ApplyResources(this.lNotification, "lNotification");
            this.lNotification.Name = "lNotification";
            // 
            // lActive
            // 
            resources.ApplyResources(this.lActive, "lActive");
            this.lActive.Name = "lActive";
            // 
            // cPlugins
            // 
            this.cPlugins.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cPlugins.FormattingEnabled = true;
            resources.ApplyResources(this.cPlugins, "cPlugins");
            this.cPlugins.Name = "cPlugins";
            this.cPlugins.TabStop = false;
            this.cPlugins.SelectedIndexChanged += new System.EventHandler(this.CPluginsSelectedIndexChanged);
            // 
            // aboutTab
            // 
            this.aboutTab.Controls.Add(this.lAuthor);
            this.aboutTab.Controls.Add(this.lVersion);
            this.aboutTab.Controls.Add(this.lName);
            this.aboutTab.Controls.Add(this.pictureBox1);
            resources.ApplyResources(this.aboutTab, "aboutTab");
            this.aboutTab.Name = "aboutTab";
            this.aboutTab.UseVisualStyleBackColor = true;
            // 
            // lAuthor
            // 
            resources.ApplyResources(this.lAuthor, "lAuthor");
            this.lAuthor.Name = "lAuthor";
            // 
            // lVersion
            // 
            resources.ApplyResources(this.lVersion, "lVersion");
            this.lVersion.Name = "lVersion";
            // 
            // lName
            // 
            resources.ApplyResources(this.lName, "lName");
            this.lName.Name = "lName";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Fireball.Properties.Resources.fireball_logo;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // cLanguage
            // 
            resources.ApplyResources(this.cLanguage, "cLanguage");
            this.cLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cLanguage.FormattingEnabled = true;
            this.cLanguage.Name = "cLanguage";
            this.cLanguage.SelectedIndexChanged += new System.EventHandler(this.CLanguageSelectedIndexChanged);
            // 
            // updaterControl
            // 
            resources.ApplyResources(this.updaterControl, "updaterControl");
            this.updaterControl.ContainerForm = this;
            this.updaterControl.DaysBetweenChecks = 1;
            this.updaterControl.GUID = "08ecc737-7f91-49cc-85cf-063d56d3a8cb";
            this.updaterControl.Name = "updaterControl";
            this.updaterControl.wyUpdateCommandline = null;
            // 
            // bCancel
            // 
            resources.ApplyResources(this.bCancel, "bCancel");
            this.bCancel.Image = global::Fireball.Properties.Resources.cancel;
            this.bCancel.Name = "bCancel";
            this.bCancel.TabStop = false;
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.BCancelClick);
            // 
            // bApply
            // 
            resources.ApplyResources(this.bApply, "bApply");
            this.bApply.Image = global::Fireball.Properties.Resources.apply;
            this.bApply.Name = "bApply";
            this.bApply.TabStop = false;
            this.bApply.UseVisualStyleBackColor = true;
            this.bApply.Click += new System.EventHandler(this.BApplyClick);
            // 
            // SettingsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.updaterControl);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bApply);
            this.Controls.Add(this.cLanguage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.trayMenu.ResumeLayout(false);
            this.mainTabControl.ResumeLayout(false);
            this.generalTab.ResumeLayout(false);
            this.generalTab.PerformLayout();
            this.aboutTab.ResumeLayout(false);
            this.aboutTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updaterControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon tray;
        private System.Windows.Forms.Label lCaptureScreen;
        private System.Windows.Forms.Label lCaptureArea;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bApply;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem traySubSettings;
        private System.Windows.Forms.ToolStripMenuItem traySubExit;
        private System.Windows.Forms.ToolStripMenuItem traySubCaptureArea;
        private System.Windows.Forms.ToolStripMenuItem traySubCaptureScreen;
        private System.Windows.Forms.CheckBox cAutoStart;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage generalTab;
        private System.Windows.Forms.TabPage aboutTab;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lVersion;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Label lAuthor;
        private UI.HotkeySelectControl hkScreen;
        private UI.HotkeySelectControl hkArea;
        private System.Windows.Forms.ToolStripMenuItem traySubAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ComboBox cNotification;
        private System.Windows.Forms.Label lNotification;
        private System.Windows.Forms.ComboBox cLanguage;
        private System.Windows.Forms.Button bPluginSettings;
        private System.Windows.Forms.Label lActive;
        private System.Windows.Forms.ComboBox cPlugins;
        private System.Windows.Forms.ComboBox cCaptureMode;
        private System.Windows.Forms.Label lCaptureMode;
        private System.Windows.Forms.Button bCaptureModeHelp;
        private System.Windows.Forms.ToolTip mainToolTip;
        private wyDay.Controls.AutomaticUpdater updaterControl;
        private System.Windows.Forms.ToolStripMenuItem traySubCheckForUpdates;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    }
}