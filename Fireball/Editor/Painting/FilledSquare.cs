using System;
using System.Drawing;

namespace Fireball.Editor.Painting
{
    class FilledSquare : Square
    {
        protected Brush backBrush;

        public FilledSquare(Color foreColor, Color backColor, byte size, Point start)
            : base(foreColor, size, start)
        {
            backBrush = new SolidBrush(backColor);
        }

        public override void Draw(Graphics gfx, Point offset)
        {
            int startX = Math.Min(Start.X, End.X) + offset.X;
            int startY = Math.Min(Start.Y, End.Y) + offset.Y;
            int width = Math.Abs(Start.X - End.X);
            int height = Math.Abs(Start.Y - End.Y);

            gfx.FillRectangle(backBrush, startX, startY, width, height);
            gfx.DrawRectangle(pen, startX, startY, width, height);
        }
    }
}
