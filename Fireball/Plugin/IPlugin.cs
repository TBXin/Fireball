using System;
using System.Drawing;

namespace Fireball.Plugin
{
    public interface IPlugin
    {
        String Name { get; }
        Int32 Version { get; }
        Boolean HasOptions { get; }
        void ShowOptions();
        String Upload(Image image);
    }
}
