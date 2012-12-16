using System;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;

namespace Fireball.Plugin
{
    public class PluginBody : IPlugin
    {
        public string Name
        {
            get { return "hostingkartinok.com"; }
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
            string response = innerUploadFile("http://hostingkartinok.com/process.php", image, "image_1", "image/png", new NameValueCollection
            {
                { "image_2", string.Empty },
                { "the_tags", string.Empty },
                { "jpeg_quality", "70%" },
                { "resize_to", "500px" },
                { "upload_type", "standard" },
            });

            //const string searchPattern = "</label><input class=\"image-link\" type=\"text\" size=\"92\" onclick=\"this.select();\" value=\"";
	        const string searchPattern = "[URL=http://hostingkartinok.com][IMG]";

            int idx = response.IndexOf(searchPattern, StringComparison.Ordinal);
            if (idx != -1)
            {
                int idx2 = response.IndexOf("[/IMG]", idx + searchPattern.Length, StringComparison.Ordinal);

                if (idx2 != -1)
                {
                    string result = response.Substring(idx + searchPattern.Length, idx2 - (idx + searchPattern.Length));
                    return result;
                }
            }

            return string.Empty;
        }

        private string innerUploadFile(string url, Image image, string paramName, string contentType, NameValueCollection nvc)
        {
            ImageConverter converter = new ImageConverter();
            byte[] imageData = (byte[])converter.ConvertTo(image, typeof(byte[]));

            if (imageData == null)
                return string.Empty;

            // Создаем "границу" и получаем её байты.
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            // Создаем веб-запрос
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.ContentType = "multipart/form-data; boundary=" + boundary;
            webRequest.Method = "POST";
            webRequest.KeepAlive = true;
            webRequest.Proxy = null;
            webRequest.Credentials = CredentialCache.DefaultCredentials;

            // Получаем поток нашего запроса, куда мы будем писать данные
            Stream requestStream = webRequest.GetRequestStream();

            // Шаблон шапки параметра формы
            const string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";

            // Записываем в поток все наши параметры
            foreach (string key in nvc.Keys)
            {
                // Записываем "границу"
                requestStream.Write(boundarybytes, 0, boundarybytes.Length);
                // Формируем запись о параметра и переводим в байты
                string formitem = string.Format(formdataTemplate, key, nvc[key]);
                byte[] formitembytes = Encoding.UTF8.GetBytes(formitem);
                // Записываем параметр в поток
                requestStream.Write(formitembytes, 0, formitembytes.Length);
            }

            // Записываем границу параметра, который будет содержать данные файла
            requestStream.Write(boundarybytes, 0, boundarybytes.Length);
            // Шаблон шапки параметра формы с файлом
            const string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            // Формируем шапку и переводим в байты
            string header = string.Format(headerTemplate, paramName, "screen.png", contentType);
            byte[] headerbytes = Encoding.UTF8.GetBytes(header);
            // Записываем полученную шапку в поток
            requestStream.Write(headerbytes, 0, headerbytes.Length);
            // Записываем файл в поток
            requestStream.Write(imageData, 0, imageData.Length);
            // Формируем хвост и переводим в байты
            byte[] trailer = Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            // Записываем хвост в поток и закрываем его.
            requestStream.Write(trailer, 0, trailer.Length);
            requestStream.Close();

            WebResponse webResponse = null;
            try
            {
                // Получаем ответ сервера
                webResponse = webRequest.GetResponse();
                // Получаем поток ответа сервера
                Stream responseStream = webResponse.GetResponseStream();

                if (responseStream == null)
                    return string.Empty;

                // Вычитываем его полностью и возрващаем вычитанные данные
                return new StreamReader(responseStream).ReadToEnd();
            }
            catch (Exception)
            {
                if (webResponse != null)
                {
                    webResponse.Close();
                }
            }

            return string.Empty;
        }
    }
}
