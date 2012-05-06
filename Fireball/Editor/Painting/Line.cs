using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Fireball.Editor.Painting
{
    class Line : Drawable
    {
        protected Pen pen;
        protected Brush brush;
        public Byte Size { get; private set; }

        public Point Start { get; set; }
        public Point End { get; set; }

        public Line(Color color, byte size, Point start)
        {
            Size = size;

            brush = new SolidBrush(color);
            pen = new Pen(brush, Size)
            {
                StartCap = LineCap.Round,
                EndCap = LineCap.Round,
                LineJoin = LineJoin.Round
            };

            Start = start;
        }

        public override void Draw(Graphics gfx, Point offset)
        {
            gfx.DrawLine(pen, 
                Start.X + offset.X, Start.Y + offset.Y,
                End.X + offset.X, End.Y + offset.Y);
        }
    }
}
