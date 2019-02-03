using DevTease.Plugins.Api;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;
using System.Threading;

namespace DevTease.Plugins.Host
{
    class Plugin
    {
        private readonly string _pluginDirectory;
        private Assembly _rootAssembly;
        private IPlugin _instance;

        public Plugin(string pluginDirectory)
        {
            _pluginDirectory = pluginDirectory;
        }

        public void Load()
        {
            if (_instance != null)
            {
                return;
            }

            var assemblyLoadContext = new PluginLoadContext();
            var assemblyPaths = Directory.GetFiles(_pluginDirectory, "*.dll");

            foreach (string assemblyPath in assemblyPaths)
            {
                _rootAssembly = assemblyLoadContext.LoadFromAssemblyPath(assemblyPath);

                var types = _rootAssembly.GetTypes();

                foreach (var type in types)
                {
                    if (typeof(IPlugin).IsAssignableFrom(type))
                    {
                        _instance = (IPlugin)Activator.CreateInstance(type);
                        _instance.Load();
                        return;
                    }
                }
            }

            throw new NoPluginTypeFoundException(_pluginDirectory);
        }

        public void Unload()
        {
            if (_instance != null)
            {
                _instance.Unload();
                _instance = null;
                var assemblyLoadContext = AssemblyLoadContext.GetLoadContext(_rootAssembly);
                _rootAssembly = null;
                assemblyLoadContext.Unload();
            }
        }
    }
}
