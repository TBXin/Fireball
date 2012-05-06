using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Fireball.Editor.Painting
{
    class Square : Drawable
    {
        protected Pen pen;
        protected Brush brush;
        public Byte Size { get; private set; }

        public Point Start { get; set; }
        public Point End { get; set; }

        public Square(Color color, byte size, Point start)
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
            int startX = Math.Min(Start.X, End.X) + offset.X;
            int startY = Math.Min(Start.Y, End.Y) + offset.Y;
            int width = Math.Abs(Start.X - End.X);
            int height = Math.Abs(Start.Y - End.Y);

            gfx.DrawRectangle(pen, startX, startY, width, height);
        }
    }
}
