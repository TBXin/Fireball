using System.Collections;
using System.Windows.Forms;

namespace Fireball.UI
{
    public class HotkeyControl : TextBox
    {
        private Keys hotkey = Keys.None;
        private Keys modifiers = Keys.None;

        // Списки кнопок, требующие особые модификаторы.
        private ArrayList needNonShiftModifier;
        private ArrayList needNonAltGrModifier;

        public HotkeyControl()
        {
            KeyPress += HotkeyControlKeyPress;
            KeyUp += HotkeyControlKeyUp;
            KeyDown += HotkeyControlKeyDown;

            needNonShiftModifier = new ArrayList();
            needNonAltGrModifier = new ArrayList();
            PopulateModifierLists();
        }
        private void PopulateModifierLists()
        {
            // Shift + 0 - 9, A - Z
            for (Keys k = Keys.D0; k <= Keys.Z; k++)
                needNonShiftModifier.Add((int)k);

            // Shift + Numpad keys
            for (Keys k = Keys.NumPad0; k <= Keys.NumPad9; k++)
                needNonShiftModifier.Add((int)k);

            // Shift + Misc (,;<./ etc)
            for (Keys k = Keys.Oem1; k <= Keys.OemBackslash; k++)
                needNonShiftModifier.Add((int)k);

            // Shift + Space, PgUp, PgDn, End, Home
            for (Keys k = Keys.Space; k <= Keys.Home; k++)
                needNonShiftModifier.Add((int)k);

            needNonShiftModifier.Add((int)Keys.Insert);
            needNonShiftModifier.Add((int)Keys.Help);
            needNonShiftModifier.Add((int)Keys.Multiply);
            needNonShiftModifier.Add((int)Keys.Add);
            needNonShiftModifier.Add((int)Keys.Subtract);
            needNonShiftModifier.Add((int)Keys.Divide);
            needNonShiftModifier.Add((int)Keys.Decimal);
            needNonShiftModifier.Add((int)Keys.Return);
            needNonShiftModifier.Add((int)Keys.Escape);
            needNonShiftModifier.Add((int)Keys.NumLock);
            needNonShiftModifier.Add((int)Keys.Scroll);

            // Ctrl+Alt + 0 - 9
            for (Keys k = Keys.D0; k <= Keys.D9; k++)
                needNonAltGrModifier.Add((int)k);
        }

        public new void Clear()
        {
            Hotkey = Keys.None;
            HotkeyModifiers = Keys.None;
        }

        private void HotkeyControlKeyDown(object sender, KeyEventArgs e)
        {
            // Стираем хоткей
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                ResetHotkey();
            }
            else
            {
                modifiers = e.Modifiers;
                hotkey = e.KeyCode;
                Redraw();
            }
        }

        private void HotkeyControlKeyUp(object sender, KeyEventArgs e)
        {
            if (hotkey == Keys.None && ModifierKeys == Keys.None)
            {
                ResetHotkey();
            }
        }

        /// <summary>
        /// Блокирует ввод текста.
        /// </summary>
        private void HotkeyControlKeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        /// <summary>
        /// Блокирует системные комбинации, такие как Ctrl+Delete and Shift+Insert.
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Delete || keyData == (Keys.Control | Keys.Delete))
            {
                ResetHotkey();
                return true;
            }

            // Вставить
            if (keyData == (Keys.Shift | Keys.Insert))
                return true; // Запрет

            // Остальные обрабатываем
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void ResetHotkey()
        {
            hotkey = Keys.None;
            modifiers = Keys.None;
            Redraw();
        }

        public Keys Hotkey
        {
            get
            {
                return hotkey;
            }
            set
            {
                hotkey = value;
                Redraw(true);
            }
        }

        public Keys HotkeyModifiers
        {
            get
            {
                return modifiers;
            }
            set
            {
                modifiers = value;
                Redraw(true);
            }
        }

        private void Redraw(bool bCalledProgramatically = false)
        {
            if (hotkey == Keys.None)
            {
                Text = "None";
                return;
            }

            if (hotkey == Keys.LWin || hotkey == Keys.RWin)
            {
                Text = "None";
                return;
            }

            // Проверка входящих данных, только если они пришли от пользователя
            if (bCalledProgramatically == false)
            {
                // Без модификатора или только шифт И хоткей требует модификатор не шифт.
                if ((modifiers == Keys.Shift || modifiers == Keys.None) && needNonShiftModifier.Contains((int)hotkey))
                {
                    if (modifiers == Keys.None)
                    {
                        if (needNonAltGrModifier.Contains((int)hotkey) == false)
                        {
                            modifiers = Keys.Alt | Keys.Control;
                        }
                        else
                        {
                            modifiers = Keys.Alt | Keys.Shift;
                        }
                    }
                    else
                    {
                        hotkey = Keys.None;
                        Text = modifiers + " + Invalid key";
                        return;
                    }
                }
                
                if ((modifiers == (Keys.Alt | Keys.Control)) && needNonAltGrModifier.Contains((int)hotkey))
                {   
                    hotkey = Keys.None;
                    Text = modifiers + " + Invalid key";
                    return;
                }
            }

            if (modifiers == Keys.None)
            {
                if (hotkey == Keys.None)
                {
                    Text = "None";
                    return;
                }

                Text = hotkey.ToString();
                return;
            }

            if (hotkey == Keys.Menu /* Alt */ || hotkey == Keys.ShiftKey || hotkey == Keys.ControlKey)
                hotkey = Keys.None;

            Text = modifiers + " + " + hotkey;
        }
    }
}
