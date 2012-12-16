using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using Fireball.Core;
using Fireball.Managers;

namespace Fireball
{
    partial class TakeForm : Form
    {
		private readonly List<Rectangle> windowsRects = new List<Rectangle>();
	    private Rectangle selectedWindowRect;

        private TakeScreenAction action;
        private Boolean isMouseDown;

        private readonly Image srcImage;
		private readonly SolidBrush selectionFillBrush = new SolidBrush(Color.FromArgb(100, 51, 153, 255));
		private readonly Pen selectionBorderPen = new Pen(new SolidBrush(Color.FromArgb(51, 153, 255)), 1);
	    private readonly Pen windowSelectionBorderPen = new Pen(Color.FromArgb(200, 51, 153, 255), 3);

        private Graphics gfx;
        private Rectangle selection;
	    private Point selectionStart;
        private Point selectionEnd;
        private Point prevMousePosition;

	    public TakeForm(Image screenImage)
	    {
		    InitializeComponent();

			#if DEBUG
            TopMost = false;
			#endif

		    SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
		    Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

		    action = TakeScreenAction.Selection;
		    srcImage = screenImage;

		    var winEnumDelegate = new Helper.EnumDelegate((h, p) =>
		    {
			    if (!Helper.IsWindowVisible(h))
				    return true;

			    windowsRects.Add(Helper.GetWindowRect(h));
			    return true;
		    });

		    Helper.EnumDesktopWindows(IntPtr.Zero, winEnumDelegate, IntPtr.Zero);
		    Load += (s, e) => Helper.SetForegroundWindow(Handle);
	    }

	    public Image GetSelection()
        {
            if (selection.Width == 0 || selection.Height == 0)
                return null;

            return ScreenManager.CropImage(srcImage, selection);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
	        switch (e.KeyCode)
	        {
		        case Keys.Escape:
			        DialogResult = DialogResult.Cancel;
			        break;
		        case Keys.Enter:
			        DialogResult = DialogResult.OK;
			        break;
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

	        if (selection == Rectangle.Empty)
		        gfx.DrawRectangle(windowSelectionBorderPen, Helper.DecreaseSize(selectedWindowRect, 1, 1));

            // Draw selection
            if (selection != Rectangle.Empty)
            {
                gfx.FillRectangle(selectionFillBrush, selection);
                gfx.DrawRectangle(selectionBorderPen, selection);
            }
        }

	    protected override void OnMouseDown(MouseEventArgs e)
	    {
		    if (e.Button != MouseButtons.Left)
			    return;

		    isMouseDown = true;
		    action = TakeScreenAction.Selection;
		    selection = Rectangle.Empty;
		    selectionStart = new Point(e.X, e.Y);
		    Invalidate();

		    base.OnMouseDown(e);
	    }

	    protected override void OnMouseUp(MouseEventArgs e)
	    {
		    if (e.Button != MouseButtons.Left)
			    return;

		    isMouseDown = false;

		    if (selection.Width == 0 || selection.Height == 0)
		    {
			    if (selectedWindowRect.X < 0)
			    {
				    selectedWindowRect.Width += selectedWindowRect.X;
				    selectedWindowRect.X = 0;
			    }

			    if (selectedWindowRect.Y < 0)
			    {
				    selectedWindowRect.Height += selectedWindowRect.Y;
				    selectedWindowRect.Y = 0;
			    }

			    selection = selectedWindowRect;
		    }

		    DialogResult = DialogResult.OK;
		    base.OnMouseUp(e);
	    }

	    protected override void OnMouseMove(MouseEventArgs e)
        {
	        foreach (var t in windowsRects.Where(t => t.Contains(new Point(e.X, e.Y))))
	        {
		        selectedWindowRect = t;
				Invalidate();
		        break;
	        }

	        if (action == TakeScreenAction.Selection && isMouseDown)
            {
                prevMousePosition = new Point(selectionEnd.X, selectionEnd.Y);
                selectionEnd = new Point(e.X, e.Y);

                selection.X = Math.Min(selectionStart.X, selectionEnd.X);
                selection.Y = Math.Min(selectionStart.Y, selectionEnd.Y);
                selection.Width = Math.Abs(selectionStart.X - selectionEnd.X);
                selection.Height = Math.Abs(selectionStart.Y - selectionEnd.Y);

	            var selectionInvalidateRectangle = new Rectangle(selection.X, selection.Y, selection.Width, selection.Height);
	            selectionInvalidateRectangle.Inflate(
					Math.Abs(prevMousePosition.X - selectionEnd.X) + 1,
					Math.Abs(prevMousePosition.Y - selectionEnd.Y) + 1);

				Invalidate(selectionInvalidateRectangle);
            }

            base.OnMouseMove(e);
        }
    }
}
