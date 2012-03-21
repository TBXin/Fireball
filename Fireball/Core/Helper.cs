using System.Windows.Forms;
using Microsoft.Win32;

namespace Fireball.Core
{
    static class Helper
    {
        public static void InfoBoxShow(string text)
        {
            MessageBox.Show(text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (startupKey.GetValue(AppName) == null)
                {
                    startupKey.Close();
                    startupKey = Registry.CurrentUser.OpenSubKey(RunKey, true);

                    if (startupKey != null)
                    {
                        startupKey.SetValue(AppName, Application.ExecutablePath);
                        startupKey.Close();
                    }
                }
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
