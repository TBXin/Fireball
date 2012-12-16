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
            var resources = new ComponentResourceManager(GetType());

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

        private void BUndoClick(object sender, EventArgs e)
        {
            imageBox1.Undo();
        }

        private void BRedoClick(object sender, EventArgs e)
        {
            imageBox1.Redo();
        }

        private void BEraseClick(object sender, EventArgs e)
        {
            imageBox1.Erase();
        }

        private void NSizeValueChanged(object sender, EventArgs e)
        {
            Settings.Instance.BrushWidth = (byte)nSize.Value;
        }

        private void CForeColorColorChanged(Color color)
        {
            Settings.Instance.ForeColor = color;
        }

        private void CBackColorColorChanged(Color color)
        {
            Settings.Instance.BackColor = color;
        }

        private void RBrushCheckedChanged(object sender, EventArgs e)
        {
            imageBox1.Tool = DrawTool.Brush;
        }

        private void RLineCheckedChanged(object sender, EventArgs e)
        {
            imageBox1.Tool = DrawTool.Line;
        }

        private void RRectangleCheckedChanged(object sender, EventArgs e)
        {
            imageBox1.Tool = DrawTool.Square;
        }

        private void RFilledRectangleCheckedChanged(object sender, EventArgs e)
        {
            imageBox1.Tool = DrawTool.FilledSquare;
        }

        private void RArrowCheckedChanged(object sender, EventArgs e)
        {
            imageBox1.Tool = DrawTool.Arrow;
        }

        private void REllipseCheckedChanged(object sender, EventArgs e)
        {
            imageBox1.Tool = DrawTool.Ellipse;
        }

        private void RFilledEllipseCheckedChanged(object sender, EventArgs e)
        {
            imageBox1.Tool = DrawTool.FilledEllipse;
        }

        private void RadioButton1CheckedChanged(object sender, EventArgs e)
        {
            imageBox1.Tool = DrawTool.Text;
        }

        private void RHighlighterCheckedChanged(object sender, EventArgs e)
        {
            imageBox1.Tool = DrawTool.Highlighter;
        }

        private void MainKeyDown(object sender, KeyEventArgs e)
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
                    switch (e.Modifiers)
                    {
	                    case Keys.Control:
		                    BUndoClick(this, new EventArgs());
		                    break;
	                    case (Keys.Shift | Keys.Control):
		                    BRedoClick(this, new EventArgs());
		                    break;
                    }
                    break;
            }
        }
    }
}
