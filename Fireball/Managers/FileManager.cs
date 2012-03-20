using System;
using System.IO;
using System.Windows.Forms;

namespace Fireball.Managers
{
    class FileManager
    {
        public static String ApplicationFolder { get; private set; }
        public static String SettingsFile { get; private set; }

        private const string SettingsFileName = "settings.xml";

        static FileManager()
        {
            // ReSharper disable PossibleNullReferenceException
            ApplicationFolder = new FileInfo(Application.ExecutablePath).Directory.FullName;
            SettingsFile = Path.Combine(ApplicationFolder, SettingsFileName);
            // ReSharper restore PossibleNullReferenceException
        }
    }
}
