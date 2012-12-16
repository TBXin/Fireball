using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Fireball.Core
{
    static class Helper
    {
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

	    [DllImport("user32.dll")]
	    [return: MarshalAs(UnmanagedType.Bool)]
	    private static extern bool GetWindowRect(IntPtr hwnd, out Rect lpRect);

	    [DllImport("user32.dll", EntryPoint = "EnumDesktopWindows", ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
	    public static extern bool EnumDesktopWindows(IntPtr hDesktop, EnumDelegate lpEnumCallbackFunction, IntPtr lParam);

	    [DllImport("user32.dll")]
	    [return: MarshalAs(UnmanagedType.Bool)]
	    public static extern bool IsWindowVisible(IntPtr hWnd);

		public delegate bool EnumDelegate(IntPtr hWnd, int lParam);

	    [StructLayout(LayoutKind.Sequential)]
	    public struct Rect
	    {
		    public int Left;        // x position of upper-left corner
		    public int Top;         // y position of upper-left corner
		    public int Right;       // x position of lower-right corner
		    public int Bottom;      // y position of lower-right corner
	    }

	    public static void InfoBoxShow(string text)
        {
            MessageBox.Show(text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult InfoBoxYesNoShow(string text, string caption)
        {
            return MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        }

	    public static Rectangle DecreaseSize(Rectangle rect, int width, int height)
	    {
		    var copyOfRect = rect;
		    copyOfRect.Inflate(-width, -height);
		    return copyOfRect;
	    }

	    public static Rectangle GetWindowRect(IntPtr hwnd)
	    {
			Rect winRect;
			GetWindowRect(hwnd, out winRect);

		    if (winRect.Left < 0 && winRect.Top < 0)
		    {
			    winRect.Right += winRect.Left;
			    winRect.Bottom += winRect.Top;

			    winRect.Left = 0;
				winRect.Top = 0;
		    }

		    return new Rectangle(winRect.Left, winRect.Top, winRect.Right - winRect.Left, winRect.Bottom - winRect.Top);
	    }

	    private const string RunKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        private const string AppName = "Fireball";

        public static void SetStartup(bool enable)
        {
            var startupKey = Registry.CurrentUser.OpenSubKey(RunKey);

            if (startupKey == null)
            {
                InfoBoxShow("Can't get registry startup key!");
                return;
            }

            if (enable)
            {
                var runPath = String.Format("\"{0}\"", Application.ExecutablePath);
                var value = startupKey.GetValue(AppName);

                // ReSharper disable ConditionIsAlwaysTrueOrFalse
                if (value == null || ( value != null && !value.Equals(runPath)))
                {
                    startupKey.Close();
                    startupKey = Registry.CurrentUser.OpenSubKey(RunKey, true);

                    if (startupKey != null)
                    {
                        startupKey.SetValue(AppName, runPath);
                        startupKey.Close();
                    }
                }
                // ReSharper restore ConditionIsAlwaysTrueOrFalse
            }
            else
            {
                // remove startup
                startupKey = Registry.CurrentUser.OpenSubKey(RunKey, true);

                if (startupKey != null)
                {
                    startupKey.DeleteValue(AppName, false);
                    startupKey.Close();
                }
            }
        }
    }
}
