using System;
using System.Windows.Forms;
using System.Threading;
using Fireball.Core;

namespace Fireball
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool createdNew;
            using (Mutex mutex = new Mutex(true, "Fireball, The Screenshooter", out createdNew))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                if (createdNew)
                {
                    Application.Run(new SettingsForm());
                }

                Helper.InfoBoxShow("Fireball already running!");
            }
        }
    }
}
