using System.Drawing;
using System.Windows.Forms;

namespace Fireball.Managers
{
    static class ScreenManager
    {
        public static Image GetScreenshot(Screen screen)
        {
            Image rtnImage = new Bitmap(screen.Bounds.Width, screen.Bounds.Height);

            Graphics gfx = Graphics.FromImage(rtnImage);
            gfx.CopyFromScreen(
                new Point(screen.Bounds.X, screen.Bounds.Y),
                Point.Empty,
                screen.Bounds.Size);

            return rtnImage;
        }

        public static Image CropImage(Image srcImage, Rectangle cropArea)
        {
            Image rtnImage = new Bitmap(cropArea.Width, cropArea.Height);

            using (Graphics gfx = Graphics.FromImage(rtnImage))
            {
                gfx.DrawImage(srcImage, -cropArea.X, -cropArea.Y);
            }

            return rtnImage;
        }
    }
}
