using System;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Net;
using System.Xml;

namespace Fireball.Plugin
{
    public class PluginBody : IPlugin
    {
        public string Name
        {
            get { return "i.zhyk.ru"; }
        }

        public Single Version
        {
            get { return 1.0f; }
        }

        public bool HasSettings
        {
            get { return false; }
        }

        public void ShowSettings()
        {
            throw new NotImplementedException();
        }

        public string Upload(Image image)
        {
            ImageConverter converter = new ImageConverter();
            byte[] imageData = (byte[])converter.ConvertTo(image, typeof(byte[]));

            if (imageData == null)
                return string.Empty;

            using (WebClient w = new WebClient { Proxy = null })
            {
                NameValueCollection values = new NameValueCollection
                {
                    { "key", "Jk8hh9L" },
                    { "upload", Convert.ToBase64String(imageData) },
                    { "format", "xml" }
                };

                XmlDocument xDoc = new XmlDocument();

                try
                {
                    byte[] response = w.UploadValues("http://i.zhyk.ru/api", values);
                    xDoc.Load(new MemoryStream(response));
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

                XmlNode statusNode = xDoc.SelectSingleNode("response/status_code");

                if (statusNode == null)
                    return string.Empty;

                if (statusNode.InnerText.Equals("200"))
                {
                    XmlNode imageNode = xDoc.SelectSingleNode("response/data/img_url");

                    if (imageNode != null)
                        return imageNode.InnerText;
                }
                else if (statusNode.InnerText.Equals("403"))
                {
                    XmlNode statusTextNode = xDoc.SelectSingleNode("response/status_txt");

                    if (statusTextNode != null)
                        return "HostingError: " + statusTextNode.InnerText;
                }

                return string.Empty;
            }
        }
    }
}
