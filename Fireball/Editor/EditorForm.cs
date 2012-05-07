using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Fireball.Core;

namespace Fireball.Editor
{
    public partial class EditorForm : Form
    {
        public EditorForm()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        public EditorForm(Image image, CultureInfo locale) : this()
        {
            imageBox1.Image = image;

            Thread.CurrentThread.CurrentUICulture = locale;
            ComponentResourceManager resources = new ComponentResourceManager(this.GetType());

            Localizer.ApplyResourceToControl(resources, this, locale);

            Text = resources.GetString("$this.Text", locale);

            nSize.Value = Settings.Instance.BrushWidth;
            cForeColor.SelectedColor = Settings.Instance.ForeColor;
            cBackColor.SelectedColor = Settings.Instance.BackColor;

            Load += (s, e) => Helper.SetForegroundWindow(Handle);
        }

        public Image GetImage()
        {
            return imageBox1.CreateImage();
        }

        private void bUndo_Click(object sender, EventArgs e)
        {
            imageBox1.Undo();
        }

        private void bRedo_Click(object sender, EventArgs e)
        {
            imageBox1.Redo();
        }

        private void bErase_Click(object sender, EventArgs e)
        {
            imageBox1.Erase();
        }

        private void nSize_ValueChanged(object sender, EventArgs e)
        {
            Settings.Instance.BrushWidth = (byte)nSize.Value;
        }

        private void cForeColor_ColorChanged(Color color)
        {
            Settings.Instance.ForeColor = color;
        }

        private void cBackColor_ColorChanged(Color color)
        {
            Settings.Instance.BackColor = color;
        }

        private void rBrush_CheckedChanged(object sender, EventArgs e)
        {
            imageBox1.Tool = DrawTool.Brush;
        }

        private void rLine_CheckedChanged(object sender, EventArgs e)
        {
            imageBox1.Tool = DrawTool.Line;
        }

        private void rRectangle_CheckedChanged(object sender, EventArgs e)
        {
            imageBox1.Tool = DrawTool.Square;
        }

        private void rFilledRectangle_CheckedChanged(object sender, EventArgs e)
        {
            imageBox1.Tool = DrawTool.FilledSquare;
        }

        private void rArrow_CheckedChanged(object sender, EventArgs e)
        {
            imageBox1.Tool = DrawTool.Arrow;
        }

        private void rEllipse_CheckedChanged(object sender, EventArgs e)
        {
            imageBox1.Tool = DrawTool.Ellipse;
        }

        private void rFilledEllipse_CheckedChanged(object sender, EventArgs e)
        {
            imageBox1.Tool = DrawTool.FilledEllipse;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            imageBox1.Tool = DrawTool.Text;
        }

        private void rHighlighter_CheckedChanged(object sender, EventArgs e)
        {
            imageBox1.Tool = DrawTool.Highlighter;
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    DialogResult = DialogResult.OK;
                    break;
                case Keys.Escape:
                    DialogResult = DialogResult.Cancel;
                    break;
                case Keys.Z:
                    if (e.Modifiers == Keys.Control)
                    {
                        bUndo_Click(this, new EventArgs());
                    }
                    else if (e.Modifiers == (Keys.Shift | Keys.Control))
                    {
                        bRedo_Click(this, new EventArgs());
                    }
                    break;
            }
        }
    }
}
