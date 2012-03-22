using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fireball
{
    public partial class NotificationForm : Form
    {
        public NotificationForm(string name)
        {
            InitializeComponent();
            Text = name;
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        public void SetUrl(string url)
        {
            uploadProgressBar.Style = ProgressBarStyle.Blocks;
            uploadProgressBar.Value = 100;

            tUrl.Text = url;
            tUrl.Visible = bCopy.Visible = bUrl.Visible = true;
            Height = 130;
        }

        private void BCopyClick(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(tUrl.Text, true, 5, 500);
            Close();
        }

        private void BUrlClick(object sender, EventArgs e)
        {
            if (tUrl.Text.StartsWith("http://"))
            {
                System.Diagnostics.Process.Start(tUrl.Text);
                Close();
            }
        }
    }
}
