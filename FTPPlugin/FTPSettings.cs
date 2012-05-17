using System;

namespace FTPPlugin
{
    public class FTPSettings
    {
        public String Server { get; set; }
        public String Url { get; set; }
        public String Directory { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }

        public FTPSettings()
        {
            Server = "ftp://";
            Url = "http://";
            Directory = string.Empty;
            Username = "user";
            Password = "password";
        }
    }
}
