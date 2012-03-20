using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Fireball.Managers;

namespace Fireball.Plugin
{
    static class PluginManager
    {
        public static List<IPlugin> Plugins { get; private set; }

        static PluginManager()
        {
            Plugins = new List<IPlugin>();
        }

        public static void Load()
        {
            string[] dlls = Directory.GetFiles(FileManager.ApplicationFolder, "*.dll");

            foreach (string dll in dlls)
            {
                Type objType = null;

                try
                {
                    Assembly asm = Assembly.LoadFile(dll);
                    if (asm != null)
                    {
                        objType = asm.GetType("Fireball.Plugin.PluginBody");
                    }

                    IPlugin plugin = Activator.CreateInstance(objType) as IPlugin;

                    if (plugin != null)
                        Plugins.Add(plugin);
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
