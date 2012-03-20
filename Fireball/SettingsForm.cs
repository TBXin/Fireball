using System;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
        private IPlugin activePlugin;

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
                if (settings.CaptureScreenHotey.KeyCode != Keys.None)
                    hotkeyRegisterErrorBuilder.AppendFormat(" - Can't register capture screen hotkey ({0})\n", settings.CaptureScreenHotey);
            }

            if (settings.CaptureAreaHotkey.GetCanRegister(this))
            {
                settings.CaptureAreaHotkey.Register(this);
                settings.CaptureAreaHotkey.Pressed += CaptureAreaHotkeyPressed;
            }
            else
            {
                if (settings.CaptureScreenHotey.KeyCode != Keys.None)
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
                    settings.CaptureScreenHotey.KeyCode = Keys.None;
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
                if (hkArea.Hotkey == Keys.None && settings.CaptureAreaHotkey.Registered)
                {
                    settings.CaptureAreaHotkey.Unregister();
                    settings.CaptureAreaHotkey.KeyCode = Keys.None;
                }
                else
                {
                    settings.CaptureAreaHotkey.KeyCode = (Keys)Enum.Parse(typeof(Keys), hkArea.Hotkey.ToString());
                    settings.CaptureAreaHotkey.Control = (hkArea.HotkeyModifiers & Keys.Control) == Keys.Control;
                    settings.CaptureAreaHotkey.Shift = (hkArea.HotkeyModifiers & Keys.Shift) == Keys.Shift;
                    settings.CaptureAreaHotkey.Alt = (hkArea.HotkeyModifiers & Keys.Alt) == Keys.Alt;

                    if (!settings.CaptureAreaHotkey.Registered && settings.CaptureAreaHotkey.KeyCode != Keys.None)
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

        private void ForwardImageToPlugin(Image image)
        {
            if (image == null)
                return;

            tray.BalloonTipIcon = ToolTipIcon.Info;
            tray.BalloonTipTitle = String.Format("Fireball: {0}", activePlugin.Name);
            tray.BalloonTipText = "Uploading...";
            tray.ShowBalloonTip(1000);

            string url = string.Empty;

            Task uploadTask = new Task(() => { url = activePlugin.Upload(image); });
            uploadTask.ContinueWith(arg =>
            {
                Clipboard.SetDataObject(url, true, 5, 500);

                tray.BalloonTipIcon = ToolTipIcon.Info;
                tray.BalloonTipTitle = String.Format("Fireball: {0}", activePlugin.Name);
                tray.BalloonTipText = url;
                tray.ShowBalloonTip(1000);
            }, TaskScheduler.FromCurrentSynchronizationContext());
            uploadTask.Start();
        }

        private void CaptureArea()
        {
            if (activePlugin == null)
            {
                Helper.InfoBoxShow("Plugin not loaded, can't upload!");
                return;
            }

            bool createdNew;
            using (new Mutex(true, "Fireball TakeForm", out createdNew))
            {
                if (!createdNew) 
                    return;

                using (TakeForm takeForm = new TakeForm())
                {
                    if (takeForm.ShowDialog() == DialogResult.OK)
                    {
                        ForwardImageToPlugin(takeForm.GetSelection());
                    }
                }
            }
        }

        private void CaptureScreen()
        {
            if (activePlugin == null)
            {
                Helper.InfoBoxShow("Plugin not loaded, can't upload!");
                return;
            }

            ForwardImageToPlugin(ScreenManager.GetScreenshot(Screen.PrimaryScreen));
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

            activePlugin = item.Plugin;
            bPluginSettings.Enabled = activePlugin.HasSettings;
        }
        #endregion

        #region :: Hotkeys Events ::
        private void CaptureAreaHotkeyPressed(object sender, System.ComponentModel.HandledEventArgs e)
        {
            if (!(hkArea.Focused || hkScreen.Focused))
                CaptureArea();
        }

        private void CaptureScreenHoteyPressed(object sender, System.ComponentModel.HandledEventArgs e)
        {
            if (!(hkArea.Focused || hkScreen.Focused))
                CaptureScreen();
        }
        #endregion

        #region :: Tray Events ::
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

        private void TrayBalloonTipClicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(tray.BalloonTipText);
        }
        #endregion
    }
}
