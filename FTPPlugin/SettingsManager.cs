using System.IO;
using System.Xml.Serialization;

namespace FTPPlugin
{
    static class SettingsManager
    {
        private static string fileName = "ftpsettings.xml";

        public static void Save(FTPSettings settings)
        {
            using (FileStream stream = File.Open(fileName, FileMode.Create))
            {
                XmlSerializer s = new XmlSerializer(typeof(FTPSettings));
                s.Serialize(stream, settings);
            }
        }

        public static FTPSettings Load()
        {
            using (FileStream stream = File.Open(fileName, FileMode.Open))
            {
                XmlSerializer s = new XmlSerializer(typeof(FTPSettings));
                return (FTPSettings)s.Deserialize(stream);
            }
        }
    }
}
