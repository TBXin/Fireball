using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Fireball.UI
{
    sealed class BorderedPanel : ScrollableControl
    {
        private RectangleF clientRect;

        private bool borderLeft,
                     borderTop,
                     borderRight,
                     borderBottom;

        private Color borderColor = Color.FromArgb(185, 185, 185);
        private Single borderWidth = 1.0f;

        [Category("_Border Settings.")]
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; Invalidate(); }
        }
        [Category("_Border Settings.")]
        public Single BorderWidth
        {
            get { return borderWidth; }
            set { borderWidth = value; Invalidate(); }
        }
        [Category("_Borders Show.")]
        public Boolean BorderLeft
        {
            get { return borderLeft; }
            set { borderLeft = value; Invalidate(); }
        }
        [Category("_Borders Show.")]
        public Boolean BorderRight
        {
            get { return borderRight; }
            set { borderRight = value; Invalidate(); }
        }
        [Category("_Borders Show.")]
        public Boolean BorderTop
        {
            get { return borderTop; }
            set { borderTop = value; Invalidate(); }
        }
        [Category("_Borders Show.")]
        public Boolean BorderBottom
        {
            get { return borderBottom; }
            set { borderBottom = value; Invalidate(); }
        }

        public BorderedPanel()
        {
            Size = new Size(150, 150);

            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.Selectable, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);
            BackColor = Color.Transparent;
        }

        private void GetClientRect()
        {
            clientRect = new RectangleF(
                ClientRectangle.X, ClientRectangle.Y,
                ClientRectangle.Width - 1, ClientRectangle.Height - 1);
        }

        private void CalcPadding()
        {
            Padding = borderLeft ?
                new Padding((int)borderWidth, Padding.Top, Padding.Right, Padding.Bottom) :
                new Padding(0, Padding.Top, Padding.Right, Padding.Bottom);
            Padding = borderTop ?
                new Padding(Padding.Left, (int)borderWidth, Padding.Right, Padding.Bottom) :
                new Padding(Padding.Left, 0, Padding.Right, Padding.Bottom);
            Padding = borderRight ?
                new Padding(Padding.Left, Padding.Top, (int)borderWidth, Padding.Bottom) :
                new Padding(Padding.Left, Padding.Top, 0, Padding.Bottom);
            Padding = borderBottom ?
                new Padding(Padding.Left, Padding.Top, Padding.Right, (int)borderWidth) :
                new Padding(Padding.Left, Padding.Top, Padding.Right, 0);
        }

        private void DrawBorders(Graphics g)
        {
            CalcPadding();
            using (var bPen = new Pen(borderColor, borderWidth))
            {
                if (borderLeft)
                    g.DrawLine(bPen,
                        clientRect.X, clientRect.Y,
                        clientRect.X, clientRect.Height);
                if (borderTop)
                    g.DrawLine(bPen,
                        clientRect.X, clientRect.Y,
                        clientRect.Width, clientRect.Y);
                if (borderRight)
                    g.DrawLine(bPen,
                        clientRect.Width, clientRect.Y,
                        clientRect.Width, clientRect.Height);
                if (borderBottom)
                    g.DrawLine(bPen,
                        clientRect.Width, clientRect.Height,
                        clientRect.X, clientRect.Height);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            GetClientRect();
            DrawBorders(e.Graphics);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Invalidate();
        }
    }
}
