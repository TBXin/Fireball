using System;
using System.Drawing;

namespace Fireball.Editor.Painting
{
    class Text : Drawable
    {
        private SolidBrush brush;

        public String Content { get; set; }
        public Font Font {get;set;}
        public Point Location { get; set; }

        public Text(string text, Font font, Color color, Point location)
        {
            Content = text;
            Font = font;
            Location = location;

            brush = new SolidBrush(color);
        }

        public override void Draw(Graphics gfx, Point offset)
        {
            gfx.TranslateTransform(offset.X, offset.Y);
            gfx.DrawString(Content, Font, brush, Location);
            gfx.ResetTransform();
        }
    }
}
