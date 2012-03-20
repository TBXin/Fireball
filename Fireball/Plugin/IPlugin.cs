using System;
using System.Drawing;

namespace Fireball.Plugin
{
    public interface IPlugin
    {
        String Name { get; }
        Single Version { get; }
        Boolean HasSettings { get; }
        void ShowOptions();
        String Upload(Image image);
    }
}
