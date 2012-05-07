using System;
using System.Windows.Forms;

namespace Fireball.UI
{
    public partial class HotkeySelectControl : UserControl
    {
        public Keys Hotkey
        {
            get { return (Keys) cKey.SelectedItem; }
            set { cKey.SelectedItem = cKey.Items.Contains(value) ? value : Keys.None; }
        }

        public Boolean Win
        {
            get { return bWin.Checked; }
            set { bWin.Checked = value; }
        }

        public Boolean Ctrl
        {
            get { return bCtrl.Checked; }
            set { bCtrl.Checked = value; }
        }

        public Boolean Shift
        {
            get { return bShift.Checked; }
            set { bShift.Checked = value; }
        }

        public Boolean Alt
        {
            get { return bAlt.Checked; }
            set { bAlt.Checked = value; }
        }

        public HotkeySelectControl()
        {
            InitializeComponent();

            PopulateKeys();
        }

        private void PopulateKeys()
        {
            cKey.Items.Clear();

            cKey.Items.Add(Keys.None);

            for (Keys k = Keys.D0; k <= Keys.D9; k++)
            {
                cKey.Items.Add(k);
            }

            for (Keys k = Keys.A; k <= Keys.Z; k++)
            {
                cKey.Items.Add(k);
            }

            for (Keys k = Keys.F1; k <= Keys.F12; k++)
            {
                cKey.Items.Add(k);
            }

            cKey.Items.Add(Keys.PrintScreen);
            cKey.Items.Add(Keys.Pause);
            cKey.Items.Add(Keys.Insert);
            cKey.Items.Add(Keys.Delete);
            cKey.Items.Add(Keys.Home);
            cKey.Items.Add(Keys.End);
            cKey.Items.Add(Keys.PageUp);
            cKey.Items.Add(Keys.PageDown);

            cKey.SelectedItem = Keys.None;
        }
    }
}
