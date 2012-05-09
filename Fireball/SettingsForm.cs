using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fireball.Core;
using Fireball.Editor;
using Fireball.Managers;
using Fireball.Plugin;
using Fireball.UI;
using wyDay.Controls;

namespace Fireball
{
    public partial class SettingsForm : Form
    {
        private Boolean isUploading;
        private Settings settings;
        private Boolean isVisible;
        private IPlugin activePlugin;

        private string imageFilter;

        #region :: Ctor ::
        public SettingsForm()
        {
            InitializeComponent();

            AutomaticUpdaterBackend back = new AutomaticUpdaterBackend()
            {
                GUID = "Fireball AutoUpdater",
                UpdateType = UpdateType.Automatic
            };

            back.Initialize();
            back.AppLoaded();

            back.ReadyToBeInstalled += (s, e) =>
            {
                if (back.UpdateStepOn == UpdateStepOn.UpdateReadyToInstall)
                {
                    back.InstallNow();
                    Application.Exit();
                }
            };

            if (back.ClosingForInstall)
                return;

            back.ForceCheckForUpdate(true);

            Icon = tray.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            StringBuilder builder = new StringBuilder();
            {
                builder.Append("Image Files (*.png;*.gif;*.jpg;*.jpeg;*.bmp)|*.png;*.gif;*.jpg;*.jpeg;*.bmp|");
                builder.Append("PNG|*.png|");
                builder.Append("GIF|*.gif|");
                builder.Append("JPG|*.jpg|");
                builder.Append("JPEG|*.jpeg|");
                builder.Append("BMP|*.bmp");
            }

            imageFilter = builder.ToString();

            PopulateCombos();
            Settings.Instance = SettingsManager.Load();
            settings = Settings.Instance;
            PopulateSettings();

            PluginManager.Load();

            foreach (IPlugin plugin in PluginManager.Plugins)
            {
                PluginItem item = new PluginItem(plugin);
                cPlugins.Items.Add(item);

                if (settings.ActivePlugin.Equals(plugin.Name))
                    cPlugins.SelectedItem = item;
            }

            if (cPlugins.SelectedItem == null && cPlugins.Items.Count > 0)
                cPlugins.SelectedIndex = 0;

            #region :: Register Hotkeys ::
            /*StringBuilder hotkeyRegisterErrorBuilder = new StringBuilder();

            if (settings.CaptureScreenHotey.GetCanRegister(this))
            {
                settings.CaptureScreenHotey.Register(this);
                settings.CaptureScreenHotey.Pressed += CaptureScreenHotkeyPressed;
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
                Helper.InfoBoxShow(String.Format("Failed to register hotkeys!\n{0}", hotkeyRegisterErrorBuilder));
            }*/
            #endregion

            SaveSettings();

            Application.ApplicationExit += (s, e) =>
            {
                SettingsManager.Save();
            };
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
            if (e.CloseReason != CloseReason.UserClosing)
                return;

            if (isVisible)
            {
                Hide();
                isVisible = false;
                e.Cancel = true;
            }

            base.OnFormClosing(e);
        }
        #endregion

        private void PopulateCombos()
        {
            cLanguage.Items.Clear();
            cLanguage.Items.Add(new LanguageItem("Eng", new CultureInfo("en-US")));
            cLanguage.Items.Add(new LanguageItem("Rus", new CultureInfo("ru-RU")));

            cCaptureMode.Items.Clear();
            foreach (object type in Enum.GetValues(typeof(CaptureMode)))
            {
                cCaptureMode.Items.Add(type);
            }

            cNotification.Items.Clear();
            foreach (object type in Enum.GetValues(typeof(NotificationType)))
            {
                cNotification.Items.Add(type);
            }
        }

        private void PopulateHotkeyControl(HotkeySelectControl khControl, Hotkey hk)
        {
            khControl.Hotkey = hk.KeyCode;
            khControl.Win = hk.Win;
            khControl.Ctrl = hk.Ctrl;
            khControl.Shift = hk.Shift;
            khControl.Alt = hk.Alt;
        }

        private void PopulateSettings()
        {
            foreach (object item in cLanguage.Items)
            {
                if (item.ToString().Equals(settings.Language))
                {
                    cLanguage.SelectedItem = item;
                    break;
                }
            }

            if (cLanguage.SelectedIndex == -1)
                cLanguage.SelectedIndex = 0;

            PopulateHotkeyControl(hkScreen, settings.CaptureScreenHotey);
            PopulateHotkeyControl(hkArea, settings.CaptureAreaHotkey);
            PopulateHotkeyControl(hkClipboard, settings.UploadFromClipboardHotkey);
            PopulateHotkeyControl(hkFile, settings.UploadFromFileHotkey);

            if (cCaptureMode.Items.Contains(settings.CaptureMode))
                cCaptureMode.SelectedItem = settings.CaptureMode;

            if (cNotification.Items.Contains(settings.Notification))
                cNotification.SelectedItem = settings.Notification;

            cAutoStart.Checked = settings.StartWithComputer;
            cWithoutEditor.Checked = settings.WithoutEditor;
        }

        private void UpdateHotkey(HotkeySelectControl hkControl, Hotkey hotkey, HandledEventHandler hkEvent)
        {
            if (hkControl.Hotkey == Keys.None && hotkey.Registered)
            {
                hotkey.Pressed -= hkEvent;
                hotkey.Unregister();
                hotkey.KeyCode = Keys.None;
            }
            else
            {
                hotkey.KeyCode = hkControl.Hotkey;
                hotkey.Win = hkControl.Win;
                hotkey.Ctrl = hkControl.Ctrl;
                hotkey.Shift = hkControl.Shift;
                hotkey.Alt = hkControl.Alt;

                if (!hotkey.Registered && hotkey.KeyCode != Keys.None)
                {
                    hotkey.Register(this);
                    hotkey.Pressed += hkEvent;
                }
            }
        }

        private Boolean SaveSettings()
        {
            LanguageItem languageItem = cLanguage.SelectedItem as LanguageItem;

            if (languageItem != null)
                settings.Language = languageItem.Name;

            try
            {
                UpdateHotkey(hkScreen, settings.CaptureScreenHotey, CaptureScreenHotkeyPressed);
                #region unused
                /*if (hkScreen.Hotkey == Keys.None && settings.CaptureScreenHotey.Registered)
                {
                    settings.CaptureScreenHotey.Pressed -= CaptureScreenHoteyPressed;
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
                    {
                        settings.CaptureScreenHotey.Register(this);
                        settings.CaptureScreenHotey.Pressed += CaptureScreenHoteyPressed;
                    }
                }*/
                #endregion
            }
            catch (Exception)
            {
                Helper.InfoBoxShow("Failed to register capture screen hotkey!");
                return false;
            }

            try
            {
                UpdateHotkey(hkArea, settings.CaptureAreaHotkey, CaptureAreaHotkeyPressed);
                #region unused
                /*if (hkArea.Hotkey == Keys.None && settings.CaptureAreaHotkey.Registered)
                {
                    settings.CaptureAreaHotkey.Pressed -= CaptureAreaHotkeyPressed;
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
                    {
                        settings.CaptureAreaHotkey.Register(this);
                        settings.CaptureAreaHotkey.Pressed += CaptureAreaHotkeyPressed;
                    }
                }*/
                #endregion
            }
            catch (Exception)
            {
                Helper.InfoBoxShow("Failed to register capture area hotkey!");
                return false;
            }

            try
            {
                UpdateHotkey(hkClipboard, settings.UploadFromClipboardHotkey, UploadFromClipboardHotkeyPressed);
            }
            catch (Exception)
            {
                Helper.InfoBoxShow("Failed to register upload from clipboard hotkey!");
                return false;
            }

            try
            {
                UpdateHotkey(hkFile, settings.UploadFromFileHotkey, UploadFromFileHotkeyPressed);
            }
            catch (Exception)
            {
                Helper.InfoBoxShow("Failed to register upload from file hotkey!");
                return false;
            }

            PluginItem selectedPlugin = cPlugins.SelectedItem as PluginItem;

            if (selectedPlugin != null) 
                settings.ActivePlugin = selectedPlugin.Plugin.Name;

            NotificationType notification = (NotificationType)cNotification.SelectedItem;
            settings.Notification = notification;

            CaptureMode captureMode = (CaptureMode)cCaptureMode.SelectedItem;
            settings.CaptureMode = captureMode;

            settings.StartWithComputer = cAutoStart.Checked;
            settings.WithoutEditor = cWithoutEditor.Checked;

            Helper.SetStartup(cAutoStart.Checked);
            SettingsManager.Save();
            return true;
        }

        private void ForwardImageToPlugin(Image image)
        {
            if (image == null)
                return;

            if (!Settings.Instance.WithoutEditor)
            {
                using (EditorForm editor = new EditorForm(image, Thread.CurrentThread.CurrentUICulture))
                {
                    if (editor.ShowDialog() == DialogResult.OK)
                    {
                        image = editor.GetImage();
                        SettingsManager.Save();
                    }
                    else
                    {
                        SettingsManager.Save();
                        return;
                    }
                }
            }

            NotificationForm notificationForm = null;

            if (settings.Notification == NotificationType.Tooltip)
            {
                tray.BalloonTipIcon = ToolTipIcon.Info;
                tray.BalloonTipTitle = String.Format("Fireball: {0}", activePlugin.Name);
                tray.BalloonTipText = "Uploading...";
                tray.ShowBalloonTip(1000);
            }
            else if (settings.Notification == NotificationType.Window)
            {
                notificationForm = new NotificationForm(String.Format("Fireball: {0}", activePlugin.Name));
                notificationForm.Show();
            }

            string url = string.Empty;

            Task uploadTask = new Task(() =>
            {
                isUploading = true;

                try
                {
                    url = activePlugin.Upload(image);
                }
                catch { }

                isUploading = false;

                if (url.StartsWith("http://"))
                    Settings.Instance.MRUList.Enqueue(url);
            });

            uploadTask.ContinueWith(arg =>
            {
                try
                {
                    if (settings.Notification == NotificationType.Tooltip)
                    {
                        // Скопировать в буфер и показать тултип
                        Clipboard.SetDataObject(url, true, 5, 500);

                        // ======= твик =======
                        // прячем предыдущий тултип, если он сам не скрылся
                        tray.Visible = false;
                        tray.Visible = true;
                        // ====================

                        tray.BalloonTipIcon = ToolTipIcon.Info;
                        tray.BalloonTipTitle = String.Format("Fireball: {0}", activePlugin.Name);
                        tray.BalloonTipText = String.IsNullOrEmpty(url) ? "empty" : url;
                        tray.ShowBalloonTip(1000);
                    }
                    else if (settings.Notification == NotificationType.Window)
                    {
                        // Вывести ссылку в форму уведомления
                        if (notificationForm != null)
                            notificationForm.SetUrl(url);
                    }
                    else
                    {
                        // Тихо копировать в буфер обмена
                        Clipboard.SetDataObject(url, true, 5, 500);
                    }
                }
                catch { }
            }, TaskScheduler.FromCurrentSynchronizationContext());
            uploadTask.Start();
        }

        private bool PreuploadCheck()
        {
            if (activePlugin == null)
            {
                Helper.InfoBoxShow("Plugin not loaded, can't upload!");
                return false;
            }

            if (isUploading)
            {
                tray.ShowBalloonTip(1000, "Fireball", "Wait until the upload is complete!", ToolTipIcon.Warning);
                return false;
            }

            return true;
        }

        private void CaptureArea()
        {
            if (!PreuploadCheck())
                return;

            Image screenImage = ScreenManager.GetScreenshot(Screen.PrimaryScreen);
            trayMenu.Hide();

            bool createdNew;
            using (new Mutex(true, "Fireball TakeForm", out createdNew))
            {
                if (!createdNew)
                    return;

                using (TakeForm takeForm = new TakeForm(screenImage, settings.CaptureMode))
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
            if (!PreuploadCheck())
                return;

            Image screenImage = ScreenManager.GetScreenshot(Screen.PrimaryScreen);
            trayMenu.Hide();

            ForwardImageToPlugin(screenImage);
        }

        private void UploadFromClipboard()
        {
            if (!PreuploadCheck())
                return;

            Image image = null;

            try
            {
                if (Clipboard.ContainsFileDropList())
                {
                    StringCollection col = Clipboard.GetFileDropList();

                    if (col.Count > 0)
                    {
                        string path = col[0];

                        if (File.Exists(path))
                            image = Bitmap.FromFile(path);
                    }
                }
                else if (Clipboard.ContainsImage())
                {
                    image = Clipboard.GetImage();
                }
            }
            catch { return; }

            if (image == null)
            {
                tray.ShowBalloonTip(1000, "Fireball", "Clipboard is empty!", ToolTipIcon.Warning);
                return;
            }

            ForwardImageToPlugin(image);
        }

        private void UploadFromFile()
        {
            if (!PreuploadCheck())
                return;

            using (OpenFileDialog op = new OpenFileDialog() { FileName = string.Empty, Filter = imageFilter })
            {
                if (op.ShowDialog() == DialogResult.OK)
                {
                    Image image = null;

                    try
                    {
                        image = Bitmap.FromFile(op.FileName);
                    }
                    catch
                    {
                        tray.ShowBalloonTip(1000, "Fireball", "Unsupported image format!", ToolTipIcon.Warning);
                        return;
                    }

                    ForwardImageToPlugin(image);
                }
            }
        }

        private void SetLanguage(Form form, CultureInfo lang)
        {
            Thread.CurrentThread.CurrentUICulture = lang;
            ComponentResourceManager resources = new ComponentResourceManager(form.GetType());

            Localizer.ApplyResourceToControl(resources, trayMenu, lang);
            Localizer.ApplyResourceToControl(resources, form, lang);

            form.Text = resources.GetString("$this.Text", lang);
            lVersion.Text = String.Format("Version: {0}", Application.ProductVersion);
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

        private void CLanguageSelectedIndexChanged(object sender, EventArgs e)
        {
            LanguageItem item = cLanguage.SelectedItem as LanguageItem;

            if (item != null)
                SetLanguage(this, item.Culture);
        }
        #endregion

        #region :: Hotkeys Events ::
        private void CaptureAreaHotkeyPressed(object sender, HandledEventArgs e)
        {
            CaptureArea();
        }

        private void CaptureScreenHotkeyPressed(object sender, HandledEventArgs e)
        {
            CaptureScreen();
        }

        private void UploadFromClipboardHotkeyPressed(object semder, HandledEventArgs e)
        {
            UploadFromClipboard();
        }

        private void UploadFromFileHotkeyPressed(object semder, HandledEventArgs e)
        {
            UploadFromFile();
        }
        #endregion

        #region :: Tray Events ::
        private void TrayDoubleClick(object sender, EventArgs e)
        {
            TraySubSettingsClick(this, new EventArgs());
        }

        private void TraySubCaptureAreaClick(object sender, EventArgs e)
        {
            CaptureArea();
        }

        private void TraySubCaptureScreenClick(object sender, EventArgs e)
        {
            CaptureScreen();
        }

        private void traySubUploadFromClipboard_Click(object sender, EventArgs e)
        {
            UploadFromClipboard();
        }

        private void uploadFromFile_Click(object sender, EventArgs e)
        {
            UploadFromFile();
        }

        private void TraySubSettingsClick(object sender, EventArgs e)
        {
            if (!isVisible)
            {
                isVisible = true;
                PopulateSettings();
                Show();
            }

            mainTabControl.SelectedTab = generalTab;
        }

        private void TraySubAboutClick(object sender, EventArgs e)
        {
            if (!isVisible)
            {
                isVisible = true;
                PopulateSettings();
                Show();
            }

            mainTabControl.SelectedTab = aboutTab;
        }

        private void TraySubCheckForUpdatesClick(object sender, EventArgs e)
        {
            TraySubSettingsClick(this, new EventArgs());
            updaterControl.ForceCheckForUpdate(true);
        }

        private void TraySubExitClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TrayBalloonTipClicked(object sender, EventArgs e)
        {
            if (tray.BalloonTipText.StartsWith("http://"))
                System.Diagnostics.Process.Start(tray.BalloonTipText);
        }

        private void trayMenu_Opening(object sender, CancelEventArgs e)
        {
            recentToolStripMenuItem.DropDown.Items.Clear();
            Settings.Instance.MRUList.Items.ForEach((item) =>
            {
                recentToolStripMenuItem.DropDown.Items.Add(item, Properties.Resources.image, (s1, e1) =>
                {
                    System.Diagnostics.Process.Start(item);
                });
            });
        }
        #endregion
    }
}