using System;
using System.Globalization;

namespace Fireball.UI
{
    class LanguageItem
    {
        public String Name { get; set; }
        public CultureInfo Culture { get; set; }

        public LanguageItem(string name, CultureInfo culture)
        {
            Name = name;
            Culture = culture;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
