using DevTease.Plugins.Api;
using System;

namespace DevTease.Plugins.PluginA
{
    public class Plugin : IPlugin
    {
        public void Load() => Console.WriteLine("Plugin A was loaded. Yay!");
        public void Unload() => Console.WriteLine("Plugin A was unloaded. Nay!");
    }
}
