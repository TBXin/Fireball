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
        public SettingsForm()
        {
            InitializeComponent();

            Icon = Tray.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            Keys modifiers = Keys.Alt | Keys.Control | Keys.Shift;

            bool alt = (modifiers & Keys.Alt) == Keys.Alt;
            bool shift = (modifiers & Keys.Shift) == Keys.Shift;
            bool control = (modifiers & Keys.Control) == Keys.Control;

            alt = alt;
        }
    }
}
