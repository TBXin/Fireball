namespace Fireball.Editor
{
    partial class EditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorForm));
            this.imageBox1 = new Fireball.Editor.ImageBox();
            this.borderedPanel4 = new Fireball.UI.BorderedPanel();
            this.rHighlighter = new System.Windows.Forms.RadioButton();
            this.rText = new System.Windows.Forms.RadioButton();
            this.rFilledEllipse = new System.Windows.Forms.RadioButton();
            this.rBrush = new System.Windows.Forms.RadioButton();
            this.rEllipse = new System.Windows.Forms.RadioButton();
            this.rLine = new System.Windows.Forms.RadioButton();
            this.rArrow = new System.Windows.Forms.RadioButton();
            this.rRectangle = new System.Windows.Forms.RadioButton();
            this.rFilledRectangle = new System.Windows.Forms.RadioButton();
            this.borderedPanel1 = new Fireball.UI.BorderedPanel();
            this.nSize = new System.Windows.Forms.NumericUpDown();
            this.cForeColor = new Fireball.UI.ColorSelectionButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cBackColor = new Fireball.UI.ColorSelectionButton();
            this.borderedPanel2 = new Fireball.UI.BorderedPanel();
            this.bErase = new System.Windows.Forms.Button();
            this.bUpload = new System.Windows.Forms.Button();
            this.bRedo = new System.Windows.Forms.Button();
            this.bClose = new System.Windows.Forms.Button();
            this.bUndo = new System.Windows.Forms.Button();
            this.borderedPanel4.SuspendLayout();
            this.borderedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nSize)).BeginInit();
            this.borderedPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageBox1
            // 
            resources.ApplyResources(this.imageBox1, "imageBox1");
            this.imageBox1.BackColor = System.Drawing.Color.White;
            this.imageBox1.BackgroundImage = global::Fireball.Properties.Resources.transparent;
            this.imageBox1.Image = global::Fireball.Properties.Resources.about;
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Tool = Fireball.Editor.DrawTool.Brush;
            // 
            // borderedPanel4
            // 
            this.borderedPanel4.BackColor = System.Drawing.SystemColors.Control;
            this.borderedPanel4.BorderBottom = false;
            this.borderedPanel4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(185)))));
            this.borderedPanel4.BorderLeft = false;
            this.borderedPanel4.BorderRight = true;
            this.borderedPanel4.BorderTop = false;
            this.borderedPanel4.BorderWidth = 1F;
            this.borderedPanel4.Controls.Add(this.rHighlighter);
            this.borderedPanel4.Controls.Add(this.rText);
            this.borderedPanel4.Controls.Add(this.rFilledEllipse);
            this.borderedPanel4.Controls.Add(this.rBrush);
            this.borderedPanel4.Controls.Add(this.rEllipse);
            this.borderedPanel4.Controls.Add(this.rLine);
            this.borderedPanel4.Controls.Add(this.rArrow);
            this.borderedPanel4.Controls.Add(this.rRectangle);
            this.borderedPanel4.Controls.Add(this.rFilledRectangle);
            resources.ApplyResources(this.borderedPanel4, "borderedPanel4");
            this.borderedPanel4.Name = "borderedPanel4";
            // 
            // rHighlighter
            // 
            resources.ApplyResources(this.rHighlighter, "rHighlighter");
            this.rHighlighter.Image = global::Fireball.Properties.Resources.highlighter;
            this.rHighlighter.Name = "rHighlighter";
            this.rHighlighter.UseVisualStyleBackColor = true;
            this.rHighlighter.CheckedChanged += new System.EventHandler(this.rHighlighter_CheckedChanged);
            // 
            // rText
            // 
            resources.ApplyResources(this.rText, "rText");
            this.rText.Image = global::Fireball.Properties.Resources.text;
            this.rText.Name = "rText";
            this.rText.UseVisualStyleBackColor = true;
            this.rText.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rFilledEllipse
            // 
            resources.ApplyResources(this.rFilledEllipse, "rFilledEllipse");
            this.rFilledEllipse.Image = global::Fireball.Properties.Resources.ellipse;
            this.rFilledEllipse.Name = "rFilledEllipse";
            this.rFilledEllipse.UseVisualStyleBackColor = true;
            this.rFilledEllipse.CheckedChanged += new System.EventHandler(this.rFilledEllipse_CheckedChanged);
            // 
            // rBrush
            // 
            resources.ApplyResources(this.rBrush, "rBrush");
            this.rBrush.Checked = true;
            this.rBrush.Image = global::Fireball.Properties.Resources.brush;
            this.rBrush.Name = "rBrush";
            this.rBrush.TabStop = true;
            this.rBrush.UseVisualStyleBackColor = true;
            this.rBrush.CheckedChanged += new System.EventHandler(this.rBrush_CheckedChanged);
            // 
            // rEllipse
            // 
            resources.ApplyResources(this.rEllipse, "rEllipse");
            this.rEllipse.Image = global::Fireball.Properties.Resources.unfilled_ellipse_;
            this.rEllipse.Name = "rEllipse";
            this.rEllipse.UseVisualStyleBackColor = true;
            this.rEllipse.CheckedChanged += new System.EventHandler(this.rEllipse_CheckedChanged);
            // 
            // rLine
            // 
            resources.ApplyResources(this.rLine, "rLine");
            this.rLine.Image = global::Fireball.Properties.Resources.line;
            this.rLine.Name = "rLine";
            this.rLine.UseVisualStyleBackColor = true;
            this.rLine.CheckedChanged += new System.EventHandler(this.rLine_CheckedChanged);
            // 
            // rArrow
            // 
            resources.ApplyResources(this.rArrow, "rArrow");
            this.rArrow.Image = global::Fireball.Properties.Resources.arrow;
            this.rArrow.Name = "rArrow";
            this.rArrow.UseVisualStyleBackColor = true;
            this.rArrow.CheckedChanged += new System.EventHandler(this.rArrow_CheckedChanged);
            // 
            // rRectangle
            // 
            resources.ApplyResources(this.rRectangle, "rRectangle");
            this.rRectangle.Image = global::Fireball.Properties.Resources.unfilled_rectangle;
            this.rRectangle.Name = "rRectangle";
            this.rRectangle.UseVisualStyleBackColor = true;
            this.rRectangle.CheckedChanged += new System.EventHandler(this.rRectangle_CheckedChanged);
            // 
            // rFilledRectangle
            // 
            resources.ApplyResources(this.rFilledRectangle, "rFilledRectangle");
            this.rFilledRectangle.Image = global::Fireball.Properties.Resources.rectangle;
            this.rFilledRectangle.Name = "rFilledRectangle";
            this.rFilledRectangle.UseVisualStyleBackColor = true;
            this.rFilledRectangle.CheckedChanged += new System.EventHandler(this.rFilledRectangle_CheckedChanged);
            // 
            // borderedPanel1
            // 
            this.borderedPanel1.BackColor = System.Drawing.Color.Transparent;
            this.borderedPanel1.BorderBottom = true;
            this.borderedPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(185)))));
            this.borderedPanel1.BorderLeft = false;
            this.borderedPanel1.BorderRight = false;
            this.borderedPanel1.BorderTop = true;
            this.borderedPanel1.BorderWidth = 1F;
            this.borderedPanel1.Controls.Add(this.nSize);
            this.borderedPanel1.Controls.Add(this.cForeColor);
            this.borderedPanel1.Controls.Add(this.label1);
            this.borderedPanel1.Controls.Add(this.cBackColor);
            this.borderedPanel1.Controls.Add(this.borderedPanel2);
            resources.ApplyResources(this.borderedPanel1, "borderedPanel1");
            this.borderedPanel1.Name = "borderedPanel1";
            // 
            // nSize
            // 
            resources.ApplyResources(this.nSize, "nSize");
            this.nSize.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nSize.Name = "nSize";
            this.nSize.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nSize.ValueChanged += new System.EventHandler(this.nSize_ValueChanged);
            // 
            // cForeColor
            // 
            resources.ApplyResources(this.cForeColor, "cForeColor");
            this.cForeColor.Name = "cForeColor";
            this.cForeColor.SelectedColor = System.Drawing.Color.Red;
            this.cForeColor.UseVisualStyleBackColor = true;
            this.cForeColor.ColorChanged += new Fireball.UI.ColorChangedDelegate(this.cForeColor_ColorChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cBackColor
            // 
            resources.ApplyResources(this.cBackColor, "cBackColor");
            this.cBackColor.Name = "cBackColor";
            this.cBackColor.SelectedColor = System.Drawing.Color.White;
            this.cBackColor.UseVisualStyleBackColor = true;
            this.cBackColor.ColorChanged += new Fireball.UI.ColorChangedDelegate(this.cBackColor_ColorChanged);
            // 
            // borderedPanel2
            // 
            this.borderedPanel2.BackColor = System.Drawing.Color.Transparent;
            this.borderedPanel2.BorderBottom = false;
            this.borderedPanel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(185)))));
            this.borderedPanel2.BorderLeft = false;
            this.borderedPanel2.BorderRight = true;
            this.borderedPanel2.BorderTop = false;
            this.borderedPanel2.BorderWidth = 1F;
            this.borderedPanel2.Controls.Add(this.bErase);
            this.borderedPanel2.Controls.Add(this.bUpload);
            this.borderedPanel2.Controls.Add(this.bRedo);
            this.borderedPanel2.Controls.Add(this.bClose);
            this.borderedPanel2.Controls.Add(this.bUndo);
            resources.ApplyResources(this.borderedPanel2, "borderedPanel2");
            this.borderedPanel2.Name = "borderedPanel2";
            // 
            // bErase
            // 
            this.bErase.Image = global::Fireball.Properties.Resources.eraser;
            resources.ApplyResources(this.bErase, "bErase");
            this.bErase.Name = "bErase";
            this.bErase.UseVisualStyleBackColor = true;
            this.bErase.Click += new System.EventHandler(this.bErase_Click);
            // 
            // bUpload
            // 
            this.bUpload.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bUpload.Image = global::Fireball.Properties.Resources.apply;
            resources.ApplyResources(this.bUpload, "bUpload");
            this.bUpload.Name = "bUpload";
            this.bUpload.UseVisualStyleBackColor = true;
            // 
            // bRedo
            // 
            this.bRedo.Image = global::Fireball.Properties.Resources.arrow_redo;
            resources.ApplyResources(this.bRedo, "bRedo");
            this.bRedo.Name = "bRedo";
            this.bRedo.UseVisualStyleBackColor = true;
            this.bRedo.Click += new System.EventHandler(this.bRedo_Click);
            // 
            // bClose
            // 
            this.bClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bClose.Image = global::Fireball.Properties.Resources.cancel;
            resources.ApplyResources(this.bClose, "bClose");
            this.bClose.Name = "bClose";
            this.bClose.UseVisualStyleBackColor = true;
            // 
            // bUndo
            // 
            this.bUndo.Image = global::Fireball.Properties.Resources.arrow_undo;
            resources.ApplyResources(this.bUndo, "bUndo");
            this.bUndo.Name = "bUndo";
            this.bUndo.UseVisualStyleBackColor = true;
            this.bUndo.Click += new System.EventHandler(this.bUndo_Click);
            // 
            // EditorForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.imageBox1);
            this.Controls.Add(this.borderedPanel4);
            this.Controls.Add(this.borderedPanel1);
            this.KeyPreview = true;
            this.Name = "EditorForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.borderedPanel4.ResumeLayout(false);
            this.borderedPanel1.ResumeLayout(false);
            this.borderedPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nSize)).EndInit();
            this.borderedPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ImageBox imageBox1;
        private System.Windows.Forms.RadioButton rRectangle;
        private System.Windows.Forms.RadioButton rLine;
        private System.Windows.Forms.RadioButton rBrush;
        private UI.BorderedPanel borderedPanel1;
        private System.Windows.Forms.Button bRedo;
        private System.Windows.Forms.Button bUndo;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.Button bUpload;
        private UI.BorderedPanel borderedPanel2;
        private UI.ColorSelectionButton cForeColor;
        private UI.ColorSelectionButton cBackColor;
        private System.Windows.Forms.NumericUpDown nSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rFilledRectangle;
        private System.Windows.Forms.RadioButton rArrow;
        private System.Windows.Forms.RadioButton rEllipse;
        private System.Windows.Forms.RadioButton rFilledEllipse;
        private UI.BorderedPanel borderedPanel4;
        private System.Windows.Forms.RadioButton rText;
        private System.Windows.Forms.Button bErase;
        private System.Windows.Forms.RadioButton rHighlighter;
    }
}

