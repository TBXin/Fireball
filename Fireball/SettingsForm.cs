using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fireball
{
    public partial class SettingsForm : Form
    {
        private Boolean isVisible;

        public SettingsForm()
        {
            InitializeComponent();

            Icon = tray.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            /*Keys modifiers = Keys.Alt | Keys.Control | Keys.Shift;

            bool alt = (modifiers & Keys.Alt) == Keys.Alt;
            bool shift = (modifiers & Keys.Shift) == Keys.Shift;
            bool control = (modifiers & Keys.Control) == Keys.Control;

            alt = alt;*/
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
                Show();
            }
        }

        private void TraySubExitClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BCancelClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
