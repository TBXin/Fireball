using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Fireball.Editor.Painting
{
    class BrushStroke : Drawable
    {
        private Pen pen;
        private Brush brush;

        public Byte Size { get; private set; }
        public List<Point> Points { get; private set; }

        public BrushStroke(Color color, byte size)
        {
            Size = size;

            brush = new SolidBrush(color);
            pen = new Pen(brush, Size)
            {
                StartCap = LineCap.Round,
                EndCap = LineCap.Round,
                LineJoin = LineJoin.Round
            };

            Points = new List<Point>();
        }
            
        public override void Draw(Graphics gfx, Point offset)
        {
            for (int i = 0; i < Points.Count - 1; i++)
            {
                gfx.DrawLine(pen,
                    Points[i].X + offset.X, Points[i].Y + offset.Y,
                    Points[i + 1].X + offset.X, Points[i + 1].Y + offset.Y);
            }
        }
    }
}
