using System;
using System.IO;
using System.Net;
using System.Drawing;
using System.Text;

namespace Fireball.Plugin
{
    public class PluginBody : IPlugin
    {
        public string Name
        {
            get { return "HostingKartinok Plugin"; }
        }

        public float Version
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

            Uri uri = new Uri("http://hostingkartinok.com/process.php");

            string boundary = "----------" + DateTime.Now.Ticks.ToString("x");
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(uri);
            webrequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1) Gecko/20100101 Firefox/9.0.1";
            //webrequest.Timeout = 60000;
            webrequest.Accept = "text/html, */*";
            webrequest.ContentType = "multipart/form-data; boundary=" + boundary;
            webrequest.Method = "POST";

            StringBuilder sb = new StringBuilder();
            sb.Append("--" + boundary);
            sb.Append("\r\n");
            sb.Append("Content-Disposition: form-data; name=\"");
            sb.Append("image_1");
            sb.Append("\"; filename=\"");
            sb.Append("screen.png");
            sb.Append("\"\r\n");
            sb.Append("Content-Type: image/png");
            sb.Append("\r\n\r\n");

            string postHeader = sb.ToString();
            byte[] postHeaderBytes = Encoding.UTF8.GetBytes(postHeader);

            sb = new StringBuilder();

            sb.Append("Content-Disposition: form-data; name=\"image_2\"; filename=\"\"\r\n\r\n\r\n");
            sb.Append("--" + boundary);
            sb.Append("\r\n");

            sb.Append("Content-Disposition: form-data; name=\"the_tags\"\r\n\r\n\r\n");
            sb.Append("--" + boundary);
            sb.Append("\r\n");

            sb.Append("Content-Disposition: form-data; name=\"jpeg_quality\"\r\n\r\n");
            sb.Append("70%\r\n");
            sb.Append("--" + boundary);
            sb.Append("\r\n");

            sb.Append("Content-Disposition: form-data; name=\"resize_to\"\r\n\r\n");
            sb.Append("500px\r\n");
            sb.Append("--" + boundary);
            sb.Append("\r\n");

            sb.Append("Content-Disposition: form-data; name=\"upload_type\"\r\n\r\n");
            sb.Append("standard\r\n");
            sb.Append("--" + boundary);
            sb.Append("--");
            sb.Append("\r\n");

            string postFooter = sb.ToString();
            byte[] postFooterBytes = Encoding.UTF8.GetBytes(postFooter);

            byte[] boundaryBytes = Encoding.ASCII.GetBytes("\r\n" + boundary + "\r\n");

            long length = postHeaderBytes.Length + imageData.Length + boundaryBytes.Length + postFooterBytes.Length;
            webrequest.ContentLength = length;

            Stream requestStream = webrequest.GetRequestStream();

            requestStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);
            requestStream.Write(imageData, 0, imageData.Length);
            requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
            requestStream.Write(postFooterBytes, 0, postFooterBytes.Length);

            WebResponse webResponse = webrequest.GetResponse();
            Stream s = webResponse.GetResponseStream();
            StreamReader sr = new StreamReader(s);

            string response = sr.ReadToEnd();

            const string searchPattern = "</label><input class=\"image-link\" type=\"text\" size=\"92\" onclick=\"this.select();\" value=\"";

            int idx = response.IndexOf(searchPattern, StringComparison.Ordinal);
            if(idx != -1)
            {
                int idx2 = response.IndexOf("\"", idx + searchPattern.Length, StringComparison.Ordinal);

                if (idx2 != -1)
                {
                    string result = response.Substring(idx + searchPattern.Length, idx2 - (idx + searchPattern.Length));
                    return result;
                }
            }

            return string.Empty;
        }
    }
}
