using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Fireball.Core;
using Fireball.Managers;

namespace Fireball
{
    partial class TakeForm : Form
    {
        private TakeScreenAction action;
        private Boolean isMouseDown;
        private Image srcImage;

        private Image helpImage;
        private Rectangle helpRectangle;
        private ColorMatrix helpMatrix;
        private ImageAttributes helpAttributes;

        private Graphics gfx;
        private Rectangle selection;
        private Rectangle selectionInvalidateRectangle;
        private Point selectionStart;
        private Point selectionEnd;
        private Point prevMousePosition;

        //private SolidBrush fadeBrush = new SolidBrush(Color.FromArgb(100, Color.Black));
        private SolidBrush selectionFillBrush = new SolidBrush(Color.FromArgb(100, 51, 153, 255));
        private Pen selectionBorderPen = new Pen(new SolidBrush(Color.FromArgb(51, 153, 255)), 1);

        public TakeForm()
        {
            InitializeComponent();
            TopMost = true;

            #if DEBUG
            TopMost = false;
            #endif

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            action = TakeScreenAction.Selection;
            srcImage = ScreenManager.GetScreenshot(Screen.PrimaryScreen);

            helpImage = GetHelpImage(srcImage.Width, 65);

            helpRectangle = new Rectangle(
                0,
                srcImage.Height / 2 - helpImage.Height / 2,
                helpImage.Width,
                helpImage.Height);

            helpMatrix = new ColorMatrix { Matrix33 = 1f };
            helpAttributes = new ImageAttributes();
            helpAttributes.SetColorMatrix(helpMatrix);

            new System.Threading.Timer(o => 
            {
                try
                {
                    helpMatrix.Matrix33 -= 0.2f;
                    helpAttributes.SetColorMatrix(helpMatrix);
                    Invalidate();
                }
                catch { }
            }, 
            null, 1500, 50);

            MouseDown += TakeFormMouseDown;
            MouseUp += TakeFormMouseUp;
            MouseMove += TakeFormMouseMove;

            Paint += TakeFormPaint;

            KeyDown += TakeFormKeyDown;
        }

        public Image GetSelection()
        {
            if (selection.Width == 0 || selection.Height == 0)
                return null;

            return ScreenManager.CropImage(srcImage, selection);
        }

        private Image GetHelpImage(int width, int height)
        {
            Image rtnImage = new Bitmap(width, height);

            using (Graphics localGfx = Graphics.FromImage(rtnImage))
            {
                localGfx.Clear(Color.LightGray);
                localGfx.DrawString(
                    "Выделите область и нажмите 'Enter' для подтверждения или 'Esc' для отмены",
                    new Font("Tahoma", 18f, FontStyle.Regular),
                    Brushes.White,
                    new RectangleF(0, 0, width, height), 
                    new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            }

            return rtnImage;
        }

        private void TakeFormKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void TakeFormPaint(object sender, PaintEventArgs e)
        {
            gfx = e.Graphics;

            gfx.CompositingQuality = CompositingQuality.HighSpeed;
            gfx.SmoothingMode = SmoothingMode.HighSpeed;
            gfx.InterpolationMode = InterpolationMode.Low;
            gfx.PixelOffsetMode = PixelOffsetMode.HighSpeed;
            gfx.CompositingMode = CompositingMode.SourceOver;

            // Draw background
            gfx.DrawImage(srcImage, 0, 0);

            /*Region fillRegion = new Region();
            fillRegion.Exclude(selection);
            gfx.FillRegion(fadeBrush, fillRegion);*/

            // Draw selection
            if (selection != Rectangle.Empty)
            {
                gfx.FillRectangle(selectionFillBrush, selection);
                gfx.DrawRectangle(selectionBorderPen, selection);
            }

            if (helpMatrix.Matrix33 <= 0f)
                return;

            gfx.DrawImage(
                helpImage,
                helpRectangle,
                0, 0,
                helpImage.Width,
                helpImage.Height,
                GraphicsUnit.Pixel,
                helpAttributes);
        }

        private void TakeFormMouseDown(object sender, MouseEventArgs e)
        {
            if (action == TakeScreenAction.Selection && e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                selection = Rectangle.Empty;
                Invalidate();
                selectionStart = new Point(e.X, e.Y);
            }
        }

        private void TakeFormMouseUp(object sender, MouseEventArgs e)
        {
            if (action == TakeScreenAction.Selection)
            {
                isMouseDown = false;
            }
        }

        private void TakeFormMouseMove(object sender, MouseEventArgs e)
        {
            if (action == TakeScreenAction.Selection && isMouseDown)
            {
                prevMousePosition = new Point(selectionEnd.X, selectionEnd.Y);
                selectionEnd = new Point(e.X, e.Y);

                selection.X = Math.Min(selectionStart.X, selectionEnd.X);
                selection.Y = Math.Min(selectionStart.Y, selectionEnd.Y);
                selection.Width = Math.Abs(selectionStart.X - selectionEnd.X);
                selection.Height = Math.Abs(selectionStart.Y - selectionEnd.Y);

                selectionInvalidateRectangle = new Rectangle(selection.X, selection.Y, selection.Width, selection.Height);
                selectionInvalidateRectangle.Inflate(
                    Math.Abs(prevMousePosition.X - selectionEnd.X) + 1,
                    Math.Abs(prevMousePosition.Y - selectionEnd.Y) + 1);

                Invalidate(selectionInvalidateRectangle);
            }
        }
    }
}
