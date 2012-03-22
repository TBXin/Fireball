using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using Fireball.Core;

namespace Fireball.Managers
{
    static class SettingsManager
    {
        public static Settings Load()
        {
            Settings rtnSettings = new Settings();

            if (!File.Exists(FileManager.SettingsFile))
                return rtnSettings;

            XDocument xdoc = XDocument.Load(FileManager.SettingsFile);
            XElement root = xdoc.Element("SettingsFile");

            if (root == null)
                return rtnSettings;

            XElement captureScreenNode = root.Element("CaptureScreenHotkey");
            XElement captureAreaNode = root.Element("CaptureAreaHotkey");
            XElement activePlugin = root.Element("ActivePlugin");
            XElement notification = root.Element("Notification");
            XElement startWithComputer = root.Element("StartWithComputer");

            #region :: CaptureScreenHotkey ::
            if (captureScreenNode == null)
                return rtnSettings;

            XAttribute winAttribute = captureScreenNode.Attribute("Win");
            XAttribute ctrlAttribute = captureScreenNode.Attribute("Ctrl");
            XAttribute shiftAttribute = captureScreenNode.Attribute("Shift");
            XAttribute altAttribute = captureScreenNode.Attribute("Alt");
            XAttribute keyAttribute = captureScreenNode.Attribute("Key");

            if (winAttribute == null || ctrlAttribute == null || shiftAttribute == null || altAttribute == null || keyAttribute == null)
                return rtnSettings;

            rtnSettings.CaptureScreenHotey = new Hotkey(
                Convert.ToBoolean(ctrlAttribute.Value),
                Convert.ToBoolean(shiftAttribute.Value),
                Convert.ToBoolean(altAttribute.Value),
                Convert.ToBoolean(winAttribute.Value),
                (Keys) Enum.Parse(typeof (Keys), keyAttribute.Value));
            #endregion
            #region :: CaptureAreaHotkey ::
            if (captureAreaNode == null)
                return rtnSettings;

            winAttribute = captureAreaNode.Attribute("Win");
            ctrlAttribute = captureAreaNode.Attribute("Ctrl");
            shiftAttribute = captureAreaNode.Attribute("Shift");
            altAttribute = captureAreaNode.Attribute("Alt");
            keyAttribute = captureAreaNode.Attribute("Key");

            if (winAttribute == null || ctrlAttribute == null || shiftAttribute == null || altAttribute == null || keyAttribute == null)
                return rtnSettings;

            rtnSettings.CaptureAreaHotkey = new Hotkey(
                Convert.ToBoolean(ctrlAttribute.Value),
                Convert.ToBoolean(shiftAttribute.Value),
                Convert.ToBoolean(altAttribute.Value),
                Convert.ToBoolean(winAttribute.Value),
                (Keys) Enum.Parse(typeof (Keys), keyAttribute.Value));
            #endregion

            if (activePlugin == null)
                return rtnSettings;

            rtnSettings.ActivePlugin = activePlugin.Value;

            if (startWithComputer == null)
                return rtnSettings;

            if (notification == null)
            {
                rtnSettings.Notification = NotificationType.Tooltip;
            }
            else
            {
                NotificationType type;

                if (Enum.TryParse(notification.Value, out type))
                    rtnSettings.Notification = type;
            }

            rtnSettings.StartWithComputer = Convert.ToBoolean(startWithComputer.Value);
            return rtnSettings;
        }

        public static void Save(Settings settings)
        {
            XDocument xdoc = new XDocument();
            XDeclaration xdec = new XDeclaration("1.0", string.Empty, string.Empty);
            xdoc.Declaration = xdec;

            XElement root = new XElement("SettingsFile");
            root.Add(
                new XElement("CaptureScreenHotkey",
                    new XAttribute("Key", settings.CaptureScreenHotey.KeyCode.ToString()),
                    new XAttribute("Win", settings.CaptureScreenHotey.Win),
                    new XAttribute("Ctrl", settings.CaptureScreenHotey.Ctrl),
                    new XAttribute("Shift", settings.CaptureScreenHotey.Shift),
                    new XAttribute("Alt", settings.CaptureScreenHotey.Alt)),
                new XElement("CaptureAreaHotkey",
                    new XAttribute("Key", settings.CaptureAreaHotkey.KeyCode.ToString()),
                    new XAttribute("Win", settings.CaptureAreaHotkey.Win),
                    new XAttribute("Ctrl", settings.CaptureAreaHotkey.Ctrl),
                    new XAttribute("Shift", settings.CaptureAreaHotkey.Shift),
                    new XAttribute("Alt", settings.CaptureAreaHotkey.Alt)),
                new XElement("ActivePlugin", settings.ActivePlugin),
                new XElement("Notification", settings.Notification),
                new XElement("StartWithComputer", settings.StartWithComputer));

            xdoc.Add(root);
            xdoc.Save(FileManager.SettingsFile);
        }
    }
}
