using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
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

        private CaptureMode captureMode;
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

        private SolidBrush selectionFillBrush = new SolidBrush(Color.FromArgb(100, 51, 153, 255));
        private Pen selectionBorderPen = new Pen(new SolidBrush(Color.FromArgb(51, 153, 255)), 1);

        public TakeForm(Image screenImage, CaptureMode mode = CaptureMode.Manual)
        {
            InitializeComponent();

            #if DEBUG
            TopMost = false;
            #endif

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            captureMode = mode;
            action = TakeScreenAction.Selection;
            srcImage = screenImage;

            helpImage = GetHelpImage(srcImage.Width, 65);

            helpRectangle = new Rectangle(
                0,
                srcImage.Height / 2 - helpImage.Height / 2,
                helpImage.Width,
                helpImage.Height);

            helpMatrix = new ColorMatrix { Matrix33 = captureMode == CaptureMode.Manual ? 1f : 0f };
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

            Load += (s, e) => Helper.SetForegroundWindow(Handle);
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

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                DialogResult = DialogResult.OK;
            }

            base.OnKeyDown(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            gfx = e.Graphics;

            gfx.CompositingQuality = CompositingQuality.HighSpeed;
            gfx.SmoothingMode = SmoothingMode.HighSpeed;
            gfx.InterpolationMode = InterpolationMode.Low;
            gfx.PixelOffsetMode = PixelOffsetMode.HighSpeed;
            gfx.CompositingMode = CompositingMode.SourceOver;

            // Draw background
            gfx.DrawImage(srcImage, 0, 0);

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

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            //Point clickLocation = new Point(e.X, e.Y);
            isMouseDown = true;

            /*if (selection.Contains(clickLocation))
            {
                // Перетаскивание выделения
                action = TakeScreenAction.MoveSelection;
                selectionEnd = new Point(e.X, e.Y);
            }
            else
            {*/
                // Создание выделения
                action = TakeScreenAction.Selection;
                selection = Rectangle.Empty;
                selectionStart = new Point(e.X, e.Y);
                Invalidate();
            //}

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            isMouseDown = false;

            if (captureMode == CaptureMode.Automatic)
                DialogResult = DialogResult.OK;

            base.OnMouseUp(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            //Cursor = selection.Contains(e.Location) ? Cursors.SizeAll : Cursors.Cross;

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
            /*else if (action == TakeScreenAction.MoveSelection && isMouseDown)
            {
                prevMousePosition = new Point(selectionEnd.X, selectionEnd.Y);
                selectionEnd = new Point(e.X, e.Y);

                selection.X += (selectionEnd.X - prevMousePosition.X);
                selection.Y += (selectionEnd.Y - prevMousePosition.Y);

                selectionInvalidateRectangle = new Rectangle(selection.X, selection.Y, selection.Width, selection.Height);
                selectionInvalidateRectangle.Inflate(
                    Math.Abs(prevMousePosition.X - selectionEnd.X) + 5,
                    Math.Abs(prevMousePosition.Y - selectionEnd.Y) + 5);

                Invalidate(selectionInvalidateRectangle);
            }*/

            base.OnMouseMove(e);
        }
    }
}
