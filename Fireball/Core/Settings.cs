using System;

namespace Fireball.Core
{
    class Settings
    {
        public String Language { get; set; }
        public Hotkey CaptureScreenHotey { get; set; }
        public Hotkey CaptureAreaHotkey { get; set; }
        public CaptureMode CaptureMode { get; set; }
        public String ActivePlugin { get; set; }
        public NotificationType Notification { get; set; }
        public Boolean StartWithComputer { get; set; }

        public Settings()
        {
            Language = "Eng";
            CaptureScreenHotey = new Hotkey();
            CaptureAreaHotkey = new Hotkey();
            CaptureMode = CaptureMode.Manual;
            ActivePlugin = String.Empty;
            Notification = NotificationType.Tooltip;
        }
    }
}
