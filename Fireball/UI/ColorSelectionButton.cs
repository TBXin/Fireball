using System.Drawing;
using System.Windows.Forms;

namespace Fireball.UI
{
    delegate void ColorChangedDelegate(Color color);

    class ColorSelectionButton : Button
    {
        public event ColorChangedDelegate ColorChanged;
        private void OnColorChanged(Color color)
        {
            if (ColorChanged != null)
                ColorChanged(color);
        }

        private int offset = 5;

        private Color selectedColor = Color.Black;
        public Color SelectedColor
        {
            get { return selectedColor; }
            set { selectedColor = value; Invalidate(); }
        }

        protected override bool ShowFocusCues
        {
            get
            {
                return false;
            }
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            Graphics gfx = pevent.Graphics;
            Rectangle clipRect = pevent.ClipRectangle;
            Rectangle drawRect = new Rectangle(clipRect.X + offset, clipRect.Y + offset, clipRect.Width - 1 - offset * 2, clipRect.Height - 1 - offset * 2);

            gfx.FillRectangle(new SolidBrush(selectedColor), drawRect);
            gfx.DrawRectangle(Pens.LightGray, drawRect);
        }

        protected override void OnClick(System.EventArgs e)
        {
            using (ColorDialog cd = new ColorDialog() { FullOpen = true })
            {
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    selectedColor = cd.Color;
                    OnColorChanged(selectedColor);
                }
            }

            base.OnClick(e);
        }
    }
}
