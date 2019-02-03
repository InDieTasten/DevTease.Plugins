using System.Collections.Generic;
using System.IO;

namespace DevTease.Plugins.Host
{
    class Program
    {
        static readonly List<Plugin> _plugins = new List<Plugin>();

        static void Main(string[] args)
        {
            for (int i = 0; i < 1000; i++)
            {
                System.Console.WriteLine($"Pass #{i}");
                LoadPlugins();
                UnloadPlugins();
            }
        }

        private static void UnloadPlugins()
        {
            foreach (var plugin in _plugins.ToArray())
            {
                plugin.Unload();
                _plugins.Remove(plugin);
            }
        }

        private static void LoadPlugins()
        {
            var directories = Directory.GetDirectories(Path.Combine(Directory.GetCurrentDirectory(), "PluginFolder"));

            foreach (string pluginDirectory in directories)
            {
                _plugins.Add(new Plugin(pluginDirectory));
            }

            foreach (var plugin in _plugins)
            {
                plugin.Load();
            }
        }
    }
}
