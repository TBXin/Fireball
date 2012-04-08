using System;
using System.Net;
using System.Threading;
using System.Windows.Forms;
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
            using (new Mutex(true, "Fireball, The Screenshooter", out createdNew))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                ServicePointManager.Expect100Continue = true;

                if (createdNew)
                {
                    Application.Run(new SettingsForm());
                }
                else
                    Helper.InfoBoxShow("Fireball already running!");
            }
        }
    }
}
