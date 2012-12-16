using System;
using System.Drawing;
using System.Linq;
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

            try
            {
                XDocument xdoc = XDocument.Load(FileManager.SettingsFile);
                XElement root = xdoc.Element("SettingsFile");

                if (root == null)
                    return rtnSettings;

                XElement languageNode = root.Element("Language");
                XElement captureScreenNode = root.Element("CaptureScreenHotkey");
                XElement captureAreaNode = root.Element("CaptureAreaHotkey");

                XElement uploadFromClipboardNode = root.Element("UploadFromClipboardHotkey");
                XElement uploadFromFileNode = root.Element("UploadFromFileHotkey");

                XElement captureModeNode = root.Element("CaptureMode");
                XElement activePluginNode = root.Element("ActivePlugin");
                XElement notificationNode = root.Element("Notification");
                XElement startWithComputerNode = root.Element("StartWithComputer");
                XElement withoutEditorNode = root.Element("WithoutEditor");

                XElement brushWidthNode = root.Element("BrushWidth");
                XElement foreColorNode = root.Element("ForeColor");
                XElement backColorNode = root.Element("BackColor");
                XElement textFontNode = root.Element("TextFont");

                XElement mruNode = root.Element("Recent");

                if (languageNode != null)
                    rtnSettings.Language = languageNode.Value;

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
                    (Keys)Enum.Parse(typeof(Keys), keyAttribute.Value));
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
                    (Keys)Enum.Parse(typeof(Keys), keyAttribute.Value));
                #endregion
                #region :: UploadFromClipboardHotkey ::
                if (uploadFromClipboardNode == null)
                    return rtnSettings;

                winAttribute = uploadFromClipboardNode.Attribute("Win");
                ctrlAttribute = uploadFromClipboardNode.Attribute("Ctrl");
                shiftAttribute = uploadFromClipboardNode.Attribute("Shift");
                altAttribute = uploadFromClipboardNode.Attribute("Alt");
                keyAttribute = uploadFromClipboardNode.Attribute("Key");

                if (winAttribute == null || ctrlAttribute == null || shiftAttribute == null || altAttribute == null || keyAttribute == null)
                    return rtnSettings;

                rtnSettings.UploadFromClipboardHotkey = new Hotkey(
                    Convert.ToBoolean(ctrlAttribute.Value),
                    Convert.ToBoolean(shiftAttribute.Value),
                    Convert.ToBoolean(altAttribute.Value),
                    Convert.ToBoolean(winAttribute.Value),
                    (Keys)Enum.Parse(typeof(Keys), keyAttribute.Value));
                #endregion
                #region :: UploadFromFileHotkey ::
                if (uploadFromFileNode == null)
                    return rtnSettings;

                winAttribute = uploadFromFileNode.Attribute("Win");
                ctrlAttribute = uploadFromFileNode.Attribute("Ctrl");
                shiftAttribute = uploadFromFileNode.Attribute("Shift");
                altAttribute = uploadFromFileNode.Attribute("Alt");
                keyAttribute = uploadFromFileNode.Attribute("Key");

                if (winAttribute == null || ctrlAttribute == null || shiftAttribute == null || altAttribute == null || keyAttribute == null)
                    return rtnSettings;

                rtnSettings.UploadFromFileHotkey = new Hotkey(
                    Convert.ToBoolean(ctrlAttribute.Value),
                    Convert.ToBoolean(shiftAttribute.Value),
                    Convert.ToBoolean(altAttribute.Value),
                    Convert.ToBoolean(winAttribute.Value),
                    (Keys)Enum.Parse(typeof(Keys), keyAttribute.Value));
                #endregion

                if (activePluginNode == null)
                    return rtnSettings;

                rtnSettings.ActivePlugin = activePluginNode.Value;

                if (startWithComputerNode == null)
                    return rtnSettings;

                if (notificationNode == null)
                {
                    rtnSettings.Notification = NotificationType.Tooltip;
                }
                else
                {
                    NotificationType type;

                    if (Enum.TryParse(notificationNode.Value, out type))
                        rtnSettings.Notification = type;
                }

                rtnSettings.StartWithComputer = Convert.ToBoolean(startWithComputerNode.Value);
                rtnSettings.WithoutEditor = Convert.ToBoolean(withoutEditorNode.Value);

                rtnSettings.BrushWidth = Byte.Parse(brushWidthNode.Value);
                rtnSettings.ForeColor = Color.FromArgb(
                    Byte.Parse(foreColorNode.Attribute("R").Value),
                    Byte.Parse(foreColorNode.Attribute("G").Value),
                    Byte.Parse(foreColorNode.Attribute("B").Value));

                rtnSettings.BackColor = Color.FromArgb(
                    Byte.Parse(backColorNode.Attribute("R").Value),
                    Byte.Parse(backColorNode.Attribute("G").Value),
                    Byte.Parse(backColorNode.Attribute("B").Value));

                rtnSettings.TextFont = new Font(
                    textFontNode.Attribute("FontFamily").Value,
                    float.Parse(textFontNode.Attribute("FontSize").Value),
                    (FontStyle)Enum.Parse(typeof(FontStyle), textFontNode.Attribute("Style").Value));

                rtnSettings.MRUList = new MRUList(
                    from link in mruNode.Descendants("Link")
                    select link.Value);
            }
            catch { }

            return rtnSettings;
        }

        public static void Save()
        {
            Settings settings = Settings.Instance;

            XDocument xdoc = new XDocument();
            XDeclaration xdec = new XDeclaration("1.0", string.Empty, string.Empty);
            xdoc.Declaration = xdec;

            XElement recent = new XElement("Recent");
            settings.MRUList.Items.ForEach((item) => recent.Add(new XElement("Link", item)));

            XElement root = new XElement("SettingsFile");
            root.Add(
                new XElement("Language", settings.Language),
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
                new XElement("UploadFromClipboardHotkey",
                    new XAttribute("Key", settings.UploadFromClipboardHotkey.KeyCode.ToString()),
                    new XAttribute("Win", settings.UploadFromClipboardHotkey.Win),
                    new XAttribute("Ctrl", settings.UploadFromClipboardHotkey.Ctrl),
                    new XAttribute("Shift", settings.UploadFromClipboardHotkey.Shift),
                    new XAttribute("Alt", settings.UploadFromClipboardHotkey.Alt)),
                new XElement("UploadFromFileHotkey",
                    new XAttribute("Key", settings.UploadFromFileHotkey.KeyCode.ToString()),
                    new XAttribute("Win", settings.UploadFromFileHotkey.Win),
                    new XAttribute("Ctrl", settings.UploadFromFileHotkey.Ctrl),
                    new XAttribute("Shift", settings.UploadFromFileHotkey.Shift),
                    new XAttribute("Alt", settings.UploadFromFileHotkey.Alt)),
                new XElement("ActivePlugin", settings.ActivePlugin),
                new XElement("Notification", settings.Notification),
                new XElement("StartWithComputer", settings.StartWithComputer),
                new XElement("WithoutEditor", settings.WithoutEditor),
                new XElement("BrushWidth", settings.BrushWidth),
                new XElement("ForeColor",
                    new XAttribute("R", settings.ForeColor.R),
                    new XAttribute("G", settings.ForeColor.G),
                    new XAttribute("B", settings.ForeColor.B)),
                new XElement("BackColor",
                    new XAttribute("R", settings.BackColor.R),
                    new XAttribute("G", settings.BackColor.G),
                    new XAttribute("B", settings.BackColor.B)),
                new XElement("TextFont",
                    new XAttribute("FontFamily", settings.TextFont.FontFamily.Name),
                    new XAttribute("FontSize", settings.TextFont.Size.ToString()),
                    new XAttribute("Style", settings.TextFont.Style)),
                recent);

            xdoc.Add(root);
            xdoc.Save(FileManager.SettingsFile);
        }
    }
}
