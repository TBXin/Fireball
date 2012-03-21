namespace Fireball.UI
{
    partial class HotkeySelectControl
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
            this.bWin = new System.Windows.Forms.CheckBox();
            this.bCtrl = new System.Windows.Forms.CheckBox();
            this.bShift = new System.Windows.Forms.CheckBox();
            this.bAlt = new System.Windows.Forms.CheckBox();
            this.cKey = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // bWin
            // 
            this.bWin.Appearance = System.Windows.Forms.Appearance.Button;
            this.bWin.Location = new System.Drawing.Point(0, 0);
            this.bWin.Name = "bWin";
            this.bWin.Size = new System.Drawing.Size(40, 23);
            this.bWin.TabIndex = 0;
            this.bWin.TabStop = false;
            this.bWin.Text = "Win";
            this.bWin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bWin.UseVisualStyleBackColor = true;
            // 
            // bCtrl
            // 
            this.bCtrl.Appearance = System.Windows.Forms.Appearance.Button;
            this.bCtrl.Location = new System.Drawing.Point(39, 0);
            this.bCtrl.Name = "bCtrl";
            this.bCtrl.Size = new System.Drawing.Size(40, 23);
            this.bCtrl.TabIndex = 1;
            this.bCtrl.TabStop = false;
            this.bCtrl.Text = "Ctrl";
            this.bCtrl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bCtrl.UseVisualStyleBackColor = true;
            // 
            // bShift
            // 
            this.bShift.Appearance = System.Windows.Forms.Appearance.Button;
            this.bShift.Location = new System.Drawing.Point(78, 0);
            this.bShift.Name = "bShift";
            this.bShift.Size = new System.Drawing.Size(40, 23);
            this.bShift.TabIndex = 2;
            this.bShift.TabStop = false;
            this.bShift.Text = "Shift";
            this.bShift.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bShift.UseVisualStyleBackColor = true;
            // 
            // bAlt
            // 
            this.bAlt.Appearance = System.Windows.Forms.Appearance.Button;
            this.bAlt.Location = new System.Drawing.Point(117, 0);
            this.bAlt.Name = "bAlt";
            this.bAlt.Size = new System.Drawing.Size(40, 23);
            this.bAlt.TabIndex = 3;
            this.bAlt.TabStop = false;
            this.bAlt.Text = "Alt";
            this.bAlt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bAlt.UseVisualStyleBackColor = true;
            // 
            // cKey
            // 
            this.cKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cKey.FormattingEnabled = true;
            this.cKey.Location = new System.Drawing.Point(157, 1);
            this.cKey.Name = "cKey";
            this.cKey.Size = new System.Drawing.Size(100, 21);
            this.cKey.TabIndex = 4;
            this.cKey.TabStop = false;
            // 
            // HotkeySelectControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cKey);
            this.Controls.Add(this.bAlt);
            this.Controls.Add(this.bShift);
            this.Controls.Add(this.bCtrl);
            this.Controls.Add(this.bWin);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MinimumSize = new System.Drawing.Size(258, 23);
            this.Name = "HotkeySelectControl";
            this.Size = new System.Drawing.Size(258, 23);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox bWin;
        private System.Windows.Forms.CheckBox bCtrl;
        private System.Windows.Forms.CheckBox bShift;
        private System.Windows.Forms.CheckBox bAlt;
        private System.Windows.Forms.ComboBox cKey;
    }
}
