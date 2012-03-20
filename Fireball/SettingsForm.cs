using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Fireball.Core;
using Fireball.Managers;

namespace Fireball
{
    public partial class SettingsForm : Form
    {
        private Settings settings;
        private Boolean isVisible;

        public SettingsForm()
        {
            InitializeComponent();

            Icon = tray.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            settings = SettingsManager.Load();

            /*Keys modifiers = Keys.Alt | Keys.Control | Keys.Shift;

            bool alt = (modifiers & Keys.Alt) == Keys.Alt;
            bool shift = (modifiers & Keys.Shift) == Keys.Shift;
            bool control = (modifiers & Keys.Control) == Keys.Control;

            alt = alt;*/
        }

        private void PopulateSettings()
        {
            hkScreen.Hotkey = settings.CaptureScreenHotey.KeyCode;
            hkScreen.HotkeyModifiers = Keys.None;

            if (settings.CaptureScreenHotey.Control)
                hkScreen.HotkeyModifiers |= Keys.Control;

            if (settings.CaptureScreenHotey.Shift)
                hkScreen.HotkeyModifiers |= Keys.Shift;

            if (settings.CaptureScreenHotey.Alt)
                hkScreen.HotkeyModifiers |= Keys.Alt;

            hkArea.Hotkey = settings.CaptureAreaHotkey.KeyCode;
            hkArea.HotkeyModifiers = Keys.None;

            if (settings.CaptureAreaHotkey.Control)
                hkArea.HotkeyModifiers |= Keys.Control;

            if (settings.CaptureAreaHotkey.Shift)
                hkArea.HotkeyModifiers |= Keys.Shift;

            if (settings.CaptureAreaHotkey.Alt)
                hkArea.HotkeyModifiers |= Keys.Alt;
        }

        private void SaveSettings()
        {
            settings.CaptureScreenHotey.KeyCode = hkScreen.Hotkey;
            settings.CaptureScreenHotey.Control = (hkScreen.HotkeyModifiers & Keys.Control) == Keys.Control;
            settings.CaptureScreenHotey.Shift = (hkScreen.HotkeyModifiers & Keys.Shift) == Keys.Shift;
            settings.CaptureScreenHotey.Alt = (hkScreen.HotkeyModifiers & Keys.Alt) == Keys.Alt;

            settings.CaptureAreaHotkey.KeyCode = hkArea.Hotkey;
            settings.CaptureAreaHotkey.Control = (hkArea.HotkeyModifiers & Keys.Control) == Keys.Control;
            settings.CaptureAreaHotkey.Shift = (hkArea.HotkeyModifiers & Keys.Shift) == Keys.Shift;
            settings.CaptureAreaHotkey.Alt = (hkArea.HotkeyModifiers & Keys.Alt) == Keys.Alt;

            SettingsManager.Save(settings);
        }

        protected override void SetVisibleCore(bool value)
        {
            if (!isVisible)
                value = false;

            base.SetVisibleCore(value);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (isVisible)
            {
                Hide();
                isVisible = false;
                e.Cancel = true;
            }

            base.OnFormClosing(e);
        }

        private void TraySubCaptureAreaClick(object sender, EventArgs e)
        {

        }

        private void TraySubCaptureScreenClick(object sender, EventArgs e)
        {

        }

        private void TraySubSettingsClick(object sender, EventArgs e)
        {
            if (!isVisible)
            {
                isVisible = true;
                PopulateSettings();
                Show();
            }
        }

        private void TraySubExitClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BApplyClick(object sender, EventArgs e)
        {
            SaveSettings();
            //Close();
        }

        private void BCancelClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
