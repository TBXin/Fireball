using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Fireball.Core
{
    static class Helper
    {
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        public static void InfoBoxShow(string text)
        {
            MessageBox.Show(text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult InfoBoxYesNoShow(string text, string caption)
        {
            return MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        }

        private const string RunKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        private const string AppName = "Fireball";

        public static void SetStartup(bool enable)
        {
            RegistryKey startupKey = Registry.CurrentUser.OpenSubKey(RunKey);

            if (startupKey == null)
            {
                InfoBoxShow("Can't get registry startup key!");
                return;
            }

            if (enable)
            {
                string runPath = String.Format("\"{0}\"", Application.ExecutablePath);
                object value = startupKey.GetValue(AppName);

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
