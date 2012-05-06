using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace Fireball.Core
{
    static class Localizer
    {
        public static void ApplyResourceToControl(ComponentResourceManager resources, Control control, CultureInfo lang)
        {
            if (control == null)
                return;

            foreach (Control c in control.Controls)
            {
                ApplyResourceToControl(resources, c, lang);
                string text = resources.GetString(c.Name + ".Text", lang);

                if (text != null)
                    c.Text = text;
            }
        }

        public static void ApplyResourceToControl(ComponentResourceManager resources, ContextMenuStrip menu, CultureInfo lang)
        {
            if (menu == null)
                return;

            foreach (ToolStripItem m in menu.Items)
            {
                string text = resources.GetString(m.Name + ".Text", lang);

                if (text != null)
                    m.Text = text;
            }
        }
    }
}
