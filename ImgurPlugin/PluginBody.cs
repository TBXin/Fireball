using System;
using System.Drawing;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Xml;

namespace Fireball.Plugin
{
    public class PluginBody : IPlugin
    {
        public string Name
        {
            get { return  "imgur"; }
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
                    { "key", "4db5be3c4fe50e1daeb05c15b5c92347" },
                    { "image", Convert.ToBase64String(imageData) }
                };

                byte[] response = w.UploadValues("http://imgur.com/api/upload.xml", values);

                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(new MemoryStream(response));

                XmlNode imageNode = xDoc.SelectSingleNode("rsp/original_image");

                if (imageNode != null)
                    return imageNode.InnerText;

                return string.Empty;
            }
        }
    }
}