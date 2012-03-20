using System;
using System.Drawing;

namespace Fireball.Plugin
{
    public class PluginBody : IPlugin
    {
        public string Name
        {
            get { return  "imgur Plugin"; }
        }

        public Single Version
        {
            get { return 1.0f; }
        }

        public bool HasSettings
        {
            get { return false; }
        }

        public void ShowOptions()
        {
            throw new NotImplementedException();
        }

        public string Upload(Image image)
        {
            throw new NotImplementedException();
        }
    }
}
