namespace Fireball
{
    partial class NotificationForm
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
            this.uploadProgressBar = new System.Windows.Forms.ProgressBar();
            this.tUrl = new System.Windows.Forms.TextBox();
            this.bCopy = new System.Windows.Forms.Button();
            this.bUrl = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uploadProgressBar
            // 
            this.uploadProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uploadProgressBar.Location = new System.Drawing.Point(12, 12);
            this.uploadProgressBar.MarqueeAnimationSpeed = 20;
            this.uploadProgressBar.Name = "uploadProgressBar";
            this.uploadProgressBar.Size = new System.Drawing.Size(320, 23);
            this.uploadProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.uploadProgressBar.TabIndex = 0;
            // 
            // tUrl
            // 
            this.tUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tUrl.BackColor = System.Drawing.SystemColors.Window;
            this.tUrl.Location = new System.Drawing.Point(12, 41);
            this.tUrl.Multiline = true;
            this.tUrl.Name = "tUrl";
            this.tUrl.ReadOnly = true;
            this.tUrl.Size = new System.Drawing.Size(289, 51);
            this.tUrl.TabIndex = 1;
            this.tUrl.Visible = false;
            // 
            // bCopy
            // 
            this.bCopy.Image = global::Fireball.Properties.Resources.copyLink;
            this.bCopy.Location = new System.Drawing.Point(301, 40);
            this.bCopy.Name = "bCopy";
            this.bCopy.Size = new System.Drawing.Size(32, 27);
            this.bCopy.TabIndex = 2;
            this.bCopy.UseVisualStyleBackColor = true;
            this.bCopy.Visible = false;
            this.bCopy.Click += new System.EventHandler(this.BCopyClick);
            // 
            // bUrl
            // 
            this.bUrl.Image = global::Fireball.Properties.Resources.openUrl;
            this.bUrl.Location = new System.Drawing.Point(301, 66);
            this.bUrl.Name = "bUrl";
            this.bUrl.Size = new System.Drawing.Size(32, 27);
            this.bUrl.TabIndex = 3;
            this.bUrl.UseVisualStyleBackColor = true;
            this.bUrl.Visible = false;
            this.bUrl.Click += new System.EventHandler(this.BUrlClick);
            // 
            // NotificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 47);
            this.Controls.Add(this.bUrl);
            this.Controls.Add(this.bCopy);
            this.Controls.Add(this.tUrl);
            this.Controls.Add(this.uploadProgressBar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NotificationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar uploadProgressBar;
        private System.Windows.Forms.Button bCopy;
        private System.Windows.Forms.Button bUrl;
        private System.Windows.Forms.TextBox tUrl;
    }
}