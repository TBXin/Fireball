using System;
using System.Drawing;

namespace Fireball.Editor.Painting
{
    class FilledEllipse : FilledSquare  
    {
        public FilledEllipse(Color foreColor, Color backColor, byte size, Point start) : base(foreColor, backColor, size, start) { }

        public override void Draw(Graphics gfx, Point offset)
        {
            int startX = Math.Min(Start.X, End.X) + offset.X;
            int startY = Math.Min(Start.Y, End.Y) + offset.Y;
            int width = Math.Abs(Start.X - End.X);
            int height = Math.Abs(Start.Y - End.Y);

            gfx.FillEllipse(backBrush, startX, startY, width, height);
            gfx.DrawEllipse(pen, startX, startY, width, height);
        }
    }
}
