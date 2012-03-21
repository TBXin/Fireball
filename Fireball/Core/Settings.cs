using System;

namespace Fireball.Core
{
    class Settings
    {
        public Hotkey CaptureScreenHotey { get; set; }
        public Hotkey CaptureAreaHotkey { get; set; }
        public String ActivePlugin { get; set; }
        public Boolean StartWithComputer { get; set; }

        public Settings()
        {
            CaptureScreenHotey = new Hotkey();
            CaptureAreaHotkey = new Hotkey();
            ActivePlugin = String.Empty;
        }
    }
}
