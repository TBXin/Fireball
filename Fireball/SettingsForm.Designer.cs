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
            this.Tray = new System.Windows.Forms.NotifyIcon(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CPlugins = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.areaHotkeyControl = new Fireball.UI.HotkeyControl();
            this.screenHotkeyControl = new Fireball.UI.HotkeyControl();
            this.button1 = new System.Windows.Forms.Button();
            this.BCancel = new System.Windows.Forms.Button();
            this.BPluginSettings = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tray
            // 
            this.Tray.Text = "Fireball";
            this.Tray.Visible = true;
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
            this.groupBox1.Controls.Add(this.areaHotkeyControl);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.screenHotkeyControl);
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
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.BPluginSettings);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.CPlugins);
            this.groupBox2.Location = new System.Drawing.Point(6, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(362, 53);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Plugins:";
            // 
            // CPlugins
            // 
            this.CPlugins.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CPlugins.FormattingEnabled = true;
            this.CPlugins.Location = new System.Drawing.Point(108, 20);
            this.CPlugins.Name = "CPlugins";
            this.CPlugins.Size = new System.Drawing.Size(174, 21);
            this.CPlugins.TabIndex = 0;
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
            // areaHotkeyControl
            // 
            this.areaHotkeyControl.Hotkey = System.Windows.Forms.Keys.None;
            this.areaHotkeyControl.HotkeyModifiers = System.Windows.Forms.Keys.None;
            this.areaHotkeyControl.Location = new System.Drawing.Point(108, 44);
            this.areaHotkeyControl.Name = "areaHotkeyControl";
            this.areaHotkeyControl.Size = new System.Drawing.Size(244, 21);
            this.areaHotkeyControl.TabIndex = 2;
            this.areaHotkeyControl.Text = "None";
            // 
            // screenHotkeyControl
            // 
            this.screenHotkeyControl.Hotkey = System.Windows.Forms.Keys.None;
            this.screenHotkeyControl.HotkeyModifiers = System.Windows.Forms.Keys.None;
            this.screenHotkeyControl.Location = new System.Drawing.Point(108, 17);
            this.screenHotkeyControl.Name = "screenHotkeyControl";
            this.screenHotkeyControl.Size = new System.Drawing.Size(244, 21);
            this.screenHotkeyControl.TabIndex = 0;
            this.screenHotkeyControl.Text = "None";
            // 
            // button1
            // 
            this.button1.Image = global::Fireball.Properties.Resources.apply;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(188, 145);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Apply && Close";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // BCancel
            // 
            this.BCancel.Image = global::Fireball.Properties.Resources.cancel;
            this.BCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCancel.Location = new System.Drawing.Point(288, 145);
            this.BCancel.Name = "BCancel";
            this.BCancel.Size = new System.Drawing.Size(70, 23);
            this.BCancel.TabIndex = 4;
            this.BCancel.Text = "Cancel";
            this.BCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCancel.UseVisualStyleBackColor = true;
            // 
            // BPluginSettings
            // 
            this.BPluginSettings.Image = global::Fireball.Properties.Resources.settings;
            this.BPluginSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BPluginSettings.Location = new System.Drawing.Point(282, 19);
            this.BPluginSettings.Name = "BPluginSettings";
            this.BPluginSettings.Size = new System.Drawing.Size(70, 23);
            this.BPluginSettings.TabIndex = 5;
            this.BPluginSettings.Text = "Settings";
            this.BPluginSettings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BPluginSettings.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 174);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fireball Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon Tray;
        private UI.HotkeyControl screenHotkeyControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private UI.HotkeyControl areaHotkeyControl;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CPlugins;
        private System.Windows.Forms.Button BPluginSettings;
        private System.Windows.Forms.Button BCancel;
        private System.Windows.Forms.Button button1;
    }
}