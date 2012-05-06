namespace Fireball.Editor
{
    partial class TextPreview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextPreview));
            this.tText = new System.Windows.Forms.TextBox();
            this.borderedPanel1 = new Fireball.UI.BorderedPanel();
            this.bCancel = new System.Windows.Forms.Button();
            this.bAdd = new System.Windows.Forms.Button();
            this.bFont = new System.Windows.Forms.Button();
            this.borderedPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tText
            // 
            resources.ApplyResources(this.tText, "tText");
            this.tText.Name = "tText";
            // 
            // borderedPanel1
            // 
            resources.ApplyResources(this.borderedPanel1, "borderedPanel1");
            this.borderedPanel1.BackColor = System.Drawing.Color.Transparent;
            this.borderedPanel1.BorderBottom = true;
            this.borderedPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(185)))));
            this.borderedPanel1.BorderLeft = false;
            this.borderedPanel1.BorderRight = false;
            this.borderedPanel1.BorderTop = false;
            this.borderedPanel1.BorderWidth = 1F;
            this.borderedPanel1.Controls.Add(this.bCancel);
            this.borderedPanel1.Controls.Add(this.bAdd);
            this.borderedPanel1.Controls.Add(this.bFont);
            this.borderedPanel1.Name = "borderedPanel1";
            // 
            // bCancel
            // 
            resources.ApplyResources(this.bCancel, "bCancel");
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Image = global::Fireball.Properties.Resources.cancel;
            this.bCancel.Name = "bCancel";
            this.bCancel.UseVisualStyleBackColor = true;
            // 
            // bAdd
            // 
            resources.ApplyResources(this.bAdd, "bAdd");
            this.bAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bAdd.Image = global::Fireball.Properties.Resources.apply;
            this.bAdd.Name = "bAdd";
            this.bAdd.UseVisualStyleBackColor = true;
            // 
            // bFont
            // 
            resources.ApplyResources(this.bFont, "bFont");
            this.bFont.Image = global::Fireball.Properties.Resources.font;
            this.bFont.Name = "bFont";
            this.bFont.UseVisualStyleBackColor = true;
            this.bFont.Click += new System.EventHandler(this.bFont_Click);
            // 
            // TextPreview
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.borderedPanel1);
            this.Controls.Add(this.tText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TextPreview";
            this.borderedPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tText;
        private UI.BorderedPanel borderedPanel1;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.Button bFont;
    }
}