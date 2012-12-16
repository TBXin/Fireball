using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Fireball.Core
{
    public class Hotkey : IMessageFilter
    {
        #region :: Interop ::
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, Keys vk);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int UnregisterHotKey(IntPtr hWnd, int id);

        // ReSharper disable InconsistentNaming
        private const uint WM_HOTKEY = 0x312;

        private const uint MOD_ALT = 0x1;
        private const uint MOD_CONTROL = 0x2;
        private const uint MOD_SHIFT = 0x4;
        private const uint MOD_WIN = 0x8;

        private const uint ERROR_HOTKEY_ALREADY_REGISTERED = 1409;
        // ReSharper restore InconsistentNaming
        #endregion

        private static int currentID;
        private const int MaximumID = 0xBFFF;

        private Keys keyCode;
        private bool shift;
        private bool control;
        private bool alt;
        private bool windows;

        private int id;
        private bool registered;
        private Control windowControl;

        public event HandledEventHandler Pressed;

        public Hotkey() : this(false, false, false, false, Keys.None) { }

        public Hotkey(bool control, bool shift, bool alt, bool windows, Keys keyCode)
        {
            KeyCode = keyCode;
            Shift = shift;
            Ctrl = control;
            Alt = alt;
            Win = windows;

            Application.AddMessageFilter(this);
        }

        ~Hotkey()
        {
            // Отменяет регистрацию хоткея, если есть необходимость
            if (Registered)
            {
                Unregister();
            }
        }

        public Hotkey Clone()
        {
            return new Hotkey(control, shift, alt, windows, keyCode);
        }

        public bool GetCanRegister(Control windowControlParam)
        {
            // Обрабатываем любые исключения, которые могут помешать зарегистрировать хоткей
            try
            {
                if (!Register(windowControlParam))
                {
                    return false;
                }

                Unregister();

                return true;
            }
            catch (Win32Exception)
            {
                return false;
            }
            catch (NotSupportedException)
            {
                return false;
            }
        }

        public bool Register(Control windowControlParam)
        {
            if (registered)
            {
                throw new NotSupportedException("You cannot register a hotkey that is already registered");
            }

            if (Empty)
            {
                throw new NotSupportedException("You cannot register an empty hotkey");
            }

            // Получаем ID для хоткея и увеличиваем текущий ID
            id = currentID;
            currentID = currentID + 1 % MaximumID;

            // Переводим модификаторы в unmanaged версию
            uint modifiers = (Alt ? MOD_ALT : 0) | (Ctrl ? MOD_CONTROL : 0) | (Shift ? MOD_SHIFT : 0) | (Win ? MOD_WIN : 0);

            // Регистрируем хоткей
            if (RegisterHotKey(windowControlParam.Handle, id, modifiers, keyCode) == 0)
            {
                if (Marshal.GetLastWin32Error() == ERROR_HOTKEY_ALREADY_REGISTERED)
                {
                    return false;
                }

                throw new Win32Exception();
            }

            registered = true;
            windowControl = windowControlParam;

            return true;
        }

        public void Unregister()
        {
            if (!registered)
            {
                throw new NotSupportedException("You cannot unregister a hotkey that is not registered");
            }

            // Если контрол умер, то нет нужны отменять регистрацию
            if (!windowControl.IsDisposed)
            {
                if (UnregisterHotKey(windowControl.Handle, id) == 0)
                {
                    //throw new Win32Exception();
                }
            }

            registered = false;
            windowControl = null;
        }

        private void Reregister()
        {
            if (!registered)
            {
                return;
            }

            // Сохраняем ссылку на контрол
            Control windowControlParam = windowControl;

            Unregister();
            Register(windowControlParam);
        }

        public bool PreFilterMessage(ref Message message)
        {
            if (message.Msg != WM_HOTKEY)
            {
                return false;
            }

            // Проверяем что ID это наш ключ и зарегистрирован
            if (registered && (message.WParam.ToInt32() == id))
            {
                return OnPressed();
            }

            return false;
        }

        private bool OnPressed()
        {
            HandledEventArgs handledEventArgs = new HandledEventArgs(false);

            if (Pressed != null)
            {
                Pressed(this, handledEventArgs);
            }

            return handledEventArgs.Handled;
        }

        public override string ToString()
        {
            if (Empty)
            {
                return "(none)";
            }

            // Build key name
            var keyName = Enum.GetName(typeof(Keys), keyCode);

	        switch (keyCode)
	        {
		        case Keys.D0:
		        case Keys.D1:
		        case Keys.D2:
		        case Keys.D3:
		        case Keys.D4:
		        case Keys.D5:
		        case Keys.D6:
		        case Keys.D7:
		        case Keys.D8:
		        case Keys.D9:
			        // Пропускаем первую букву
			        if (keyName != null)
			        {
				        keyName = keyName.Substring(1);
			        }
			        break;
	        }

	        var modifiers = "";

            if (shift)
            {
                modifiers += "Shift+";
            }
            if (control)
            {
                modifiers += "Control+";
            }
            if (alt)
            {
                modifiers += "Alt+";
            }
            if (windows)
            {
                modifiers += "Windows+";
            }

            return modifiers + keyName;
        }

        public bool Empty
        {
            get { return keyCode == Keys.None; }
        }

        public bool Registered
        {
            get { return registered; }
        }

        public Keys KeyCode
        {
            get { return keyCode; }
            set
            {
                keyCode = value;
                Reregister();
            }
        }

        public bool Shift
        {
            get { return shift; }
            set
            {
                shift = value;
                Reregister();
            }
        }

        public bool Ctrl
        {
            get { return control; }
            set
            {
                control = value;
                Reregister();
            }
        }

        public bool Alt
        {
            get { return alt; }
            set
            {
                alt = value;
                Reregister();
            }
        }

        public bool Win
        {
            get { return windows; }
            set
            {
                windows = value;
                Reregister();
            }
        }
    }
}
