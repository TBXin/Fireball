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
        private bool isUploading;
        private Settings settings;
        private Boolean isVisible;
        private IPlugin activePlugin;

        #region :: Ctor ::
        public SettingsForm()
        {
            InitializeComponent();

            Icon = tray.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            lVersion.Text = String.Format("Version: {0}", Application.ProductVersion);

            settings = SettingsManager.Load();
            PopulateSettings();

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
            hkScreen.Win = settings.CaptureScreenHotey.Win;
            hkScreen.Ctrl = settings.CaptureScreenHotey.Ctrl;
            hkScreen.Shift = settings.CaptureScreenHotey.Shift;
            hkScreen.Alt = settings.CaptureScreenHotey.Alt;

            hkArea.Hotkey = settings.CaptureAreaHotkey.KeyCode;
            hkArea.Win = settings.CaptureAreaHotkey.Win;
            hkArea.Ctrl = settings.CaptureAreaHotkey.Ctrl;
            hkArea.Shift = settings.CaptureAreaHotkey.Shift;
            hkArea.Alt = settings.CaptureAreaHotkey.Alt;

            cAutoStart.Checked = settings.StartWithComputer;
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
                    settings.CaptureScreenHotey.KeyCode = hkScreen.Hotkey;
                    settings.CaptureScreenHotey.Win = hkScreen.Win;
                    settings.CaptureScreenHotey.Ctrl = hkScreen.Ctrl;
                    settings.CaptureScreenHotey.Shift = hkScreen.Shift;
                    settings.CaptureScreenHotey.Alt = hkScreen.Alt;

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
                    settings.CaptureAreaHotkey.KeyCode = hkArea.Hotkey;
                    settings.CaptureAreaHotkey.Win = hkArea.Win;
                    settings.CaptureAreaHotkey.Ctrl = hkArea.Ctrl;
                    settings.CaptureAreaHotkey.Shift = hkArea.Shift;
                    settings.CaptureAreaHotkey.Alt = hkArea.Alt;

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

            settings.StartWithComputer = cAutoStart.Checked;

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

            Task uploadTask = new Task(() =>
            {
                isUploading = true;
                Thread.Sleep(5000);
                //url = activePlugin.Upload(image);
            });

            uploadTask.ContinueWith(arg =>
            {
                Clipboard.SetDataObject(url, true, 5, 500);

                tray.BalloonTipIcon = ToolTipIcon.Info;
                tray.BalloonTipTitle = String.Format("Fireball: {0}", activePlugin.Name);
                tray.BalloonTipText = String.IsNullOrEmpty(url) ? "empty" : url;
                tray.ShowBalloonTip(1000);
                isUploading = false;
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

            if (isUploading)
            {
                tray.ShowBalloonTip(1000, "Fireball", "Wait until the upload is complete", ToolTipIcon.Warning);
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
            if (isUploading)
            {
                tray.ShowBalloonTip(1000, "Fireball", "Wait until the upload is complete", ToolTipIcon.Warning);
                return;
            }

            if (activePlugin == null)
            {
                Helper.InfoBoxShow("Plugin not loaded, can't upload!");
                return;
            }

            ForwardImageToPlugin(ScreenManager.GetScreenshot(Screen.PrimaryScreen));
        }

        #region :: Form Controlls Events ::
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

        private void CAutoStartCheckedChanged(object sender, EventArgs e)
        {
            Helper.SetStartup(cAutoStart.Checked);
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
