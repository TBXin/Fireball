using System;
using System.Drawing;

namespace Fireball.Editor.Painting
{
    class Ellipse : Square
    {
        public Ellipse(Color color, byte size, Point start) : base(color, size, start) { }

        public override void Draw(Graphics gfx, Point offset)
        {
            int startX = Math.Min(Start.X, End.X) + offset.X;
            int startY = Math.Min(Start.Y, End.Y) + offset.Y;
            int width = Math.Abs(Start.X - End.X);
            int height = Math.Abs(Start.Y - End.Y);

            gfx.DrawEllipse(pen, startX, startY, width, height);
        }
    }
}
