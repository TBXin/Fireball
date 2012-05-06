using System;
using System.Drawing;

namespace Fireball.Core
{
    class Settings
    {
        private static object syncLock = new object();
        private static Settings instance;

        public static Settings Instance
        {
            get
            {
                lock (syncLock)
                {
                    if (instance == null)
                        instance = new Settings();

                    return instance;
                }
            }
            set
            {
                lock (syncLock)
                {
                    instance = value;
                }
            }
        }

        public String Language { get; set; }
        public Hotkey CaptureScreenHotey { get; set; }
        public Hotkey CaptureAreaHotkey { get; set; }
        public CaptureMode CaptureMode { get; set; }
        public String ActivePlugin { get; set; }
        public NotificationType Notification { get; set; }
        public Boolean StartWithComputer { get; set; }
        public Boolean WithoutEditor { get; set; }
        public Byte BrushWidth { get; set; }
        public Color ForeColor { get; set; }
        public Color BackColor { get; set; }
        public Font TextFont { get; set; }
        public MRUList MRUList { get; set; }

        public Settings()
        {
            Language = "Eng";
            CaptureScreenHotey = new Hotkey();
            CaptureAreaHotkey = new Hotkey();
            CaptureMode = CaptureMode.Manual;
            ActivePlugin = String.Empty;
            Notification = NotificationType.Tooltip;

            BrushWidth = 3;
            ForeColor = Color.Red;
            BackColor = Color.White;
            TextFont = new Font("Tahoma", 10f, FontStyle.Regular);

            MRUList = new MRUList();
        }
    }
}
