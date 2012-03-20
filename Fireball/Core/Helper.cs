using System.Windows.Forms;

namespace Fireball.Core
{
    class Helper
    {
        public static void InfoBoxShow(string text)
        {
            MessageBox.Show(text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
