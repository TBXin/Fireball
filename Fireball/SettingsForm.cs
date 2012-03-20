using System;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Fireball.Core;
using Fireball.Managers;
using Fireball.Plugin;

namespace Fireball
{
    public partial class SettingsForm : Form
    {
        private Settings settings;
        private Boolean isVisible;

        #region :: Ctor ::
        public SettingsForm()
        {
            InitializeComponent();

            Icon = tray.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            settings = SettingsManager.Load();

            StringBuilder hotkeyRegisterErrorBuilder = new StringBuilder();

            if (settings.CaptureScreenHotey.GetCanRegister(this))
            {
                settings.CaptureScreenHotey.Register(this);
                settings.CaptureScreenHotey.Pressed += CaptureScreenHoteyPressed;
            }
            else
            {
                hotkeyRegisterErrorBuilder.AppendFormat(" - Can't register capture screen hotkey ({0})\n", settings.CaptureScreenHotey);
            }

            if (settings.CaptureAreaHotkey.GetCanRegister(this))
            {
                settings.CaptureAreaHotkey.Register(this);
                settings.CaptureAreaHotkey.Pressed += CaptureAreaHotkeyPressed;
            }
            else
            {
                hotkeyRegisterErrorBuilder.AppendFormat(" - Can't register capture area hotkey ({0})\n", settings.CaptureAreaHotkey);
            }

            if (hotkeyRegisterErrorBuilder.Length > 0)
            {
                MessageBox.Show(
                    String.Format(
                        "Failed to register hotkeys!\n{0}", 
                        hotkeyRegisterErrorBuilder), 
                    "Information", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
            }

            PluginManager.Load();

            foreach (IPlugin plugin in PluginManager.Plugins)
            {
                PluginItem item = new PluginItem(plugin);
                cPlugins.Items.Add(item);

                if (settings.ActivePlugin.Equals(plugin.Name))
                    cPlugins.SelectedItem = item;
            }
        }
        #endregion

        #region :: Overrides ::
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
        #endregion

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

        private Boolean SaveSettings()
        {
            try
            {
                if (hkScreen.Hotkey == Keys.None && settings.CaptureScreenHotey.Registered)
                {
                    settings.CaptureScreenHotey.Unregister();
                }
                else
                {
                    settings.CaptureScreenHotey.KeyCode = (Keys)Enum.Parse(typeof(Keys), hkScreen.Hotkey.ToString());
                    settings.CaptureScreenHotey.Control = (hkScreen.HotkeyModifiers & Keys.Control) == Keys.Control;
                    settings.CaptureScreenHotey.Shift = (hkScreen.HotkeyModifiers & Keys.Shift) == Keys.Shift;
                    settings.CaptureScreenHotey.Alt = (hkScreen.HotkeyModifiers & Keys.Alt) == Keys.Alt;

                    if (!settings.CaptureScreenHotey.Registered && settings.CaptureScreenHotey.KeyCode != Keys.None)
                        settings.CaptureScreenHotey.Register(this);
                }
            }
            catch (Exception)
            {
                Helper.InfoBoxShow("Failed to register capture screen hotkey!");
                return false;
            }

            try
            {
                if (hkScreen.Hotkey == Keys.None && settings.CaptureAreaHotkey.Registered)
                {
                    settings.CaptureAreaHotkey.Unregister();
                }
                else
                {
                    settings.CaptureAreaHotkey.KeyCode = (Keys)Enum.Parse(typeof(Keys), hkArea.Hotkey.ToString());
                    settings.CaptureAreaHotkey.Control = (hkArea.HotkeyModifiers & Keys.Control) == Keys.Control;
                    settings.CaptureAreaHotkey.Shift = (hkArea.HotkeyModifiers & Keys.Shift) == Keys.Shift;
                    settings.CaptureAreaHotkey.Alt = (hkArea.HotkeyModifiers & Keys.Alt) == Keys.Alt;

                    if (!settings.CaptureAreaHotkey.Registered && settings.CaptureScreenHotey.KeyCode != Keys.None)
                        settings.CaptureAreaHotkey.Register(this);
                }
            }
            catch (Exception)
            {
                Helper.InfoBoxShow("Failed to register capture area hotkey!");
                return false;
            }

            PluginItem selectedPlugin = cPlugins.SelectedItem as PluginItem;

            if (selectedPlugin != null) 
                settings.ActivePlugin = selectedPlugin.Plugin.Name;

            SettingsManager.Save(settings);
            return true;
        }

        private void CaptureArea()
        {
            MessageBox.Show("Area");
        }

        private void CaptureScreen()
        {
            MessageBox.Show("Screen");
        }

        #region :: Buttons & Combo Events ::
        private void BApplyClick(object sender, EventArgs e)
        {
            if (SaveSettings())
                Close();
        }

        private void BCancelClick(object sender, EventArgs e)
        {
            Close();
        }

        private void CPluginsSelectedIndexChanged(object sender, EventArgs e)
        {
            PluginItem item = cPlugins.SelectedItem as PluginItem;

            if (item == null) 
                return;

            bPluginSettings.Enabled = item.Plugin.HasSettings;
        }
        #endregion

        #region :: Hotkeys Events ::
        private void CaptureAreaHotkeyPressed(object sender, System.ComponentModel.HandledEventArgs e)
        {
            CaptureArea();
        }

        private void CaptureScreenHoteyPressed(object sender, System.ComponentModel.HandledEventArgs e)
        {
            CaptureScreen();
        }
        #endregion

        #region :: Tray Menu Events ::
        private void TraySubCaptureAreaClick(object sender, EventArgs e)
        {
            CaptureArea();
        }

        private void TraySubCaptureScreenClick(object sender, EventArgs e)
        {
            CaptureScreen();
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
        #endregion
    }
}
