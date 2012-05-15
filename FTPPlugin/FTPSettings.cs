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

        public bool IsEmpty
        {
            get
            {
                return
                    String.IsNullOrEmpty(Server) &&
                    String.IsNullOrEmpty(Url) &&
                    String.IsNullOrEmpty(Directory) &&
                    String.IsNullOrEmpty(Username) &&
                    String.IsNullOrEmpty(Password);
            }
        }

        public FTPSettings() { }
    }
}
