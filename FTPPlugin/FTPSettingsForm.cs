using System.Windows.Forms;

namespace FTPPlugin
{
    public partial class FTPSettingsForm : Form
    {
        public FTPSettingsForm(FTPSettings settings)
        {
            InitializeComponent();

            if (settings == null)
                return;

            if (settings.IsEmpty)
                return;

            tServer.Text = settings.Server;
            tDirectory.Text = settings.Directory;
            tUrl.Text = settings.Url;
            tUser.Text = settings.Username;
            tPassword.Text = settings.Password;
        }

        public FTPSettings GetSettings()
        {
            return new FTPSettings()
            {
                Server =tServer.Text,
                Directory = tDirectory.Text,
                Url = tUrl.Text,
                Username = tUser.Text,
                Password = tPassword.Text
            };
        }

        private void FTPSettingsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                DialogResult = DialogResult.Cancel;
        }
    }
}
