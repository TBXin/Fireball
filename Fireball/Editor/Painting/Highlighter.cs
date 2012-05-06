using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Fireball.Editor.Painting
{
    class Highlighter : Drawable
    {
        private Pen pen;
        private Brush brush;

        public Byte Size { get; private set; }
        public List<Point> Points { get; private set; }

        public Highlighter(Color color, byte size)
        {
            Size = size;
            Size += 5;

            brush = new SolidBrush(Color.FromArgb(110, color));
            pen = new Pen(brush, Size)
            {
                StartCap = LineCap.Square,
                EndCap = LineCap.Square,
                LineJoin = LineJoin.Round
            };

            Points = new List<Point>();
        }

        public override void Draw(Graphics gfx, Point offset)
        {
            if (Points.Count > 1)
                gfx.DrawCurve(pen, Points.ToArray());

            /*for (int i = 0; i < Points.Count - 1; i++)
            {
                gfx.DrawLine(pen,
                    Points[i].X + offset.X, Points[i].Y + offset.Y,
                    Points[i + 1].X + offset.X, Points[i + 1].Y + offset.Y);
            }*/
        }
    }
}
