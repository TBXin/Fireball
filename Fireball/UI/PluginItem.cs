using Fireball.Plugin;

namespace Fireball.UI
{
    class PluginItem
    {
        public IPlugin Plugin { get; set; }

        public PluginItem(IPlugin plugin)
        {
            Plugin = plugin;
        }

        public override string ToString()
        {
            return Plugin.Name;
        }
    }
}
