using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Fireball.Core;
using Fireball.Editor.Painting;

namespace Fireball.Editor
{
    enum DrawTool
    {
        Brush,
        Highlighter,
        Line,
        Square,
        FilledSquare,
        Ellipse,
        FilledEllipse,
        Arrow,
        Text
    }

    class ImageBox : ScrollableControl
    {
        private Image image;

        public Image Image
        {
            get { return image; }
            set
            {
                image = value;
                base.AutoScrollMinSize = value.Size;
                Invalidate();
            }
        }

        public DrawTool Tool { get; set; }

        private Stack<Drawable> drawabels = new Stack<Drawable>();
        private Stack<Drawable> redo = new Stack<Drawable>();
        private bool mouseDown;
        private Drawable lastDrawable;

        private Point start;

        public ImageBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            drawabels = new Stack<Drawable>();
            redo = new Stack<Drawable>();

            Tool = DrawTool.Brush;
        }

        public void AddDrawable(Drawable item)
        {
            drawabels.Push(item);
        }

        public void Erase()
        {
            drawabels.Clear();
            redo.Clear();
            Invalidate();
        }

        public void Undo()
        {
            if (drawabels.Count > 0)
            {
                redo.Push(drawabels.Pop());
                Invalidate();
            }
        }

        public void Redo()
        {
            if (redo.Count > 0)
            {
                drawabels.Push(redo.Pop());
                Invalidate();
            }
        }

        public Image CreateImage()
        {
            Image rtnImage = new Bitmap(image.Width, image.Height);

            using (Graphics gfx = Graphics.FromImage(rtnImage))
            {
                gfx.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height));
                gfx.SmoothingMode = SmoothingMode.AntiAlias;
                drawabels.Reverse().ToList().ForEach(d => d.Draw(gfx, Point.Empty));
            }

            return rtnImage;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (image == null)
            {
                base.OnPaint(e);
            }
            else
            {
                Point offset = new Point(-HorizontalScroll.Value, -VerticalScroll.Value);
                Rectangle imageRect = new Rectangle(offset.X, offset.Y, image.Width, image.Height);

                e.Graphics.Clip = new System.Drawing.Region(imageRect);
                e.Graphics.DrawImage(image, imageRect);
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                drawabels.Reverse().ToList().ForEach(d => d.Draw(e.Graphics, offset));
            }
        }

        protected override void OnScroll(ScrollEventArgs se)
        {
            Invalidate();
            base.OnScroll(se);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            mouseDown = true;
            Point mousePosition = new Point(e.Location.X + HorizontalScroll.Value, e.Location.Y + VerticalScroll.Value);
            start = mousePosition;

            switch (Tool)
            {
                case DrawTool.Brush:
                    lastDrawable = new BrushStroke(Settings.Instance.ForeColor, Settings.Instance.BrushWidth);
                    break;
                case DrawTool.Highlighter:
                    lastDrawable = new Highlighter(Settings.Instance.ForeColor, Settings.Instance.BrushWidth);
                    break;
                case DrawTool.Line:
                    lastDrawable = new Line(Settings.Instance.ForeColor, Settings.Instance.BrushWidth, mousePosition);
                    break;
                case DrawTool.Arrow:
                    lastDrawable = new Arrow(Settings.Instance.ForeColor, Settings.Instance.BrushWidth, mousePosition);
                    break;
                case DrawTool.Square:
                    lastDrawable = new Square(Settings.Instance.ForeColor, Settings.Instance.BrushWidth, mousePosition);
                    break;
                case DrawTool.FilledSquare:
                    lastDrawable = new FilledSquare(Settings.Instance.ForeColor, Settings.Instance.BackColor, Settings.Instance.BrushWidth, mousePosition);
                    break;
                case DrawTool.Ellipse:
                    lastDrawable = new Ellipse(Settings.Instance.ForeColor, Settings.Instance.BrushWidth, mousePosition);
                    break;
                case DrawTool.FilledEllipse:
                    lastDrawable = new FilledEllipse(Settings.Instance.ForeColor, Settings.Instance.BackColor, Settings.Instance.BrushWidth, mousePosition);
                    break;
                case DrawTool.Text:
                    using (TextPreview tp = new TextPreview(Settings.Instance.TextFont, Thread.CurrentThread.CurrentUICulture))
                    {
                        if (tp.ShowDialog() == DialogResult.OK)
                        {
                            if (!String.IsNullOrEmpty(tp.Content))
                            {
                                lastDrawable = new Text(tp.Content, Settings.Instance.TextFont, Settings.Instance.ForeColor, mousePosition);
                            }
                        }
                    }
                    break;
            }

            drawabels.Push(lastDrawable);

            if(lastDrawable is Text)
                Invalidate();

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            mouseDown = false;

            base.OnMouseUp(e);
        }

        /*private bool directionDetermined;
        private bool horizontal;
        private bool vertical;*/

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            if (!mouseDown)
                return;

            Point mousePosition = new Point(e.Location.X + HorizontalScroll.Value, e.Location.Y + VerticalScroll.Value);

            /*if (Control.ModifierKeys == Keys.Shift)
            {
                if (!directionDetermined)
                {
                    int dx = mousePosition.X - start.X;
                    int dy = mousePosition.Y - start.Y;

                    if (Math.Abs(dx) > Math.Abs(dy))
                        horizontal = true;
                    else
                        vertical = true;

                    directionDetermined = true;
                }

                if (vertical)
                    mousePosition.X = start.X;

                if (horizontal)
                    mousePosition.Y = start.Y;
            }*/

            switch (Tool)
            {
                case DrawTool.Brush:
                    ((BrushStroke)lastDrawable).Points.Add(mousePosition);
                    break;
                case DrawTool.Highlighter:
                    ((Highlighter)lastDrawable).Points.Add(mousePosition);
                    break;
                case DrawTool.Line:
                    ((Line)lastDrawable).End = mousePosition;
                    break;
                case DrawTool.Arrow:
                    ((Arrow)lastDrawable).End = mousePosition;
                    break;
                case DrawTool.Square:
                    ((Square)lastDrawable).End = mousePosition;
                    break;
                case DrawTool.FilledSquare:
                    ((FilledSquare)lastDrawable).End = mousePosition;
                    break;
                case DrawTool.Ellipse:
                    ((Ellipse)lastDrawable).End = mousePosition;
                    break;
                case DrawTool.FilledEllipse:
                    ((FilledEllipse)lastDrawable).End = mousePosition;
                    break;
            }

            Invalidate();

            base.OnMouseMove(e);
        }
    }
}
