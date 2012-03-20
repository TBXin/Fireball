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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.hkArea = new Fireball.UI.HotkeyControl();
            this.hkScreen = new Fireball.UI.HotkeyControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bPluginSettings = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cPlugins = new System.Windows.Forms.ComboBox();
            this.bApply = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.trayMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tray
            // 
            this.tray.ContextMenuStrip = this.trayMenu;
            this.tray.Text = "Fireball";
            this.tray.Visible = true;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Capture screen:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.hkArea);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.hkScreen);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 74);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hotkeys:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Capture area:";
            // 
            // hkArea
            // 
            this.hkArea.Hotkey = System.Windows.Forms.Keys.None;
            this.hkArea.HotkeyModifiers = System.Windows.Forms.Keys.None;
            this.hkArea.Location = new System.Drawing.Point(108, 44);
            this.hkArea.Name = "hkArea";
            this.hkArea.Size = new System.Drawing.Size(244, 21);
            this.hkArea.TabIndex = 2;
            this.hkArea.Text = "None";
            // 
            // hkScreen
            // 
            this.hkScreen.Hotkey = System.Windows.Forms.Keys.None;
            this.hkScreen.HotkeyModifiers = System.Windows.Forms.Keys.None;
            this.hkScreen.Location = new System.Drawing.Point(108, 17);
            this.hkScreen.Name = "hkScreen";
            this.hkScreen.Size = new System.Drawing.Size(244, 21);
            this.hkScreen.TabIndex = 0;
            this.hkScreen.Text = "None";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.bPluginSettings);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cPlugins);
            this.groupBox2.Location = new System.Drawing.Point(6, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(362, 53);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Plugins:";
            // 
            // bPluginSettings
            // 
            this.bPluginSettings.Image = global::Fireball.Properties.Resources.settings;
            this.bPluginSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bPluginSettings.Location = new System.Drawing.Point(282, 19);
            this.bPluginSettings.Name = "bPluginSettings";
            this.bPluginSettings.Size = new System.Drawing.Size(70, 23);
            this.bPluginSettings.TabIndex = 5;
            this.bPluginSettings.Text = "Settings";
            this.bPluginSettings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bPluginSettings.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(6, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Active plugin:";
            // 
            // cPlugins
            // 
            this.cPlugins.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cPlugins.FormattingEnabled = true;
            this.cPlugins.Location = new System.Drawing.Point(108, 20);
            this.cPlugins.Name = "cPlugins";
            this.cPlugins.Size = new System.Drawing.Size(174, 21);
            this.cPlugins.TabIndex = 0;
            this.cPlugins.SelectedIndexChanged += new System.EventHandler(this.CPluginsSelectedIndexChanged);
            // 
            // bApply
            // 
            this.bApply.Image = global::Fireball.Properties.Resources.apply;
            this.bApply.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bApply.Location = new System.Drawing.Point(188, 145);
            this.bApply.Name = "bApply";
            this.bApply.Size = new System.Drawing.Size(100, 23);
            this.bApply.TabIndex = 5;
            this.bApply.Text = "Apply && Close";
            this.bApply.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bApply.UseVisualStyleBackColor = true;
            this.bApply.Click += new System.EventHandler(this.BApplyClick);
            // 
            // bCancel
            // 
            this.bCancel.Image = global::Fireball.Properties.Resources.cancel;
            this.bCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bCancel.Location = new System.Drawing.Point(288, 145);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(70, 23);
            this.bCancel.TabIndex = 4;
            this.bCancel.Text = "Cancel";
            this.bCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.BCancelClick);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 174);
            this.Controls.Add(this.bApply);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fireball Settings";
            this.trayMenu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon tray;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
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
        private UI.HotkeyControl hkArea;
        private UI.HotkeyControl hkScreen;
    }
}