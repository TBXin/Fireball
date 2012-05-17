namespace FTPPlugin
{
    partial class FTPSettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tServer = new System.Windows.Forms.TextBox();
            this.tDirectory = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tUrl = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tUser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bApply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server:";
            // 
            // tServer
            // 
            this.tServer.Location = new System.Drawing.Point(12, 25);
            this.tServer.Name = "tServer";
            this.tServer.Size = new System.Drawing.Size(278, 21);
            this.tServer.TabIndex = 1;
            this.tServer.Text = "ftp://";
            // 
            // tDirectory
            // 
            this.tDirectory.Location = new System.Drawing.Point(12, 65);
            this.tDirectory.Name = "tDirectory";
            this.tDirectory.Size = new System.Drawing.Size(278, 21);
            this.tDirectory.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Directory:";
            // 
            // tUrl
            // 
            this.tUrl.Location = new System.Drawing.Point(12, 105);
            this.tUrl.Name = "tUrl";
            this.tUrl.Size = new System.Drawing.Size(278, 21);
            this.tUrl.TabIndex = 5;
            this.tUrl.Text = "http://";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "HTTP Url:";
            // 
            // tUser
            // 
            this.tUser.Location = new System.Drawing.Point(12, 145);
            this.tUser.Name = "tUser";
            this.tUser.Size = new System.Drawing.Size(278, 21);
            this.tUser.TabIndex = 7;
            this.tUser.Text = "user";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Username:";
            // 
            // tPassword
            // 
            this.tPassword.Location = new System.Drawing.Point(12, 185);
            this.tPassword.Name = "tPassword";
            this.tPassword.Size = new System.Drawing.Size(278, 21);
            this.tPassword.TabIndex = 9;
            this.tPassword.Text = "password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Password:";
            // 
            // bApply
            // 
            this.bApply.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bApply.Location = new System.Drawing.Point(12, 212);
            this.bApply.Name = "bApply";
            this.bApply.Size = new System.Drawing.Size(278, 25);
            this.bApply.TabIndex = 10;
            this.bApply.Text = "Apply";
            this.bApply.UseVisualStyleBackColor = true;
            // 
            // FTPSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 246);
            this.Controls.Add(this.bApply);
            this.Controls.Add(this.tPassword);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tUser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tUrl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tDirectory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tServer);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "FTPSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FTP Settings";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FTPSettingsForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tServer;
        private System.Windows.Forms.TextBox tDirectory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tUrl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bApply;
    }
}