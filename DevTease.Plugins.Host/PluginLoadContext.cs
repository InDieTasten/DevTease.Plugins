using System.Reflection;
using System.Runtime.Loader;

namespace DevTease.Plugins.Host
{
    class PluginLoadContext : AssemblyLoadContext
    {
        public PluginLoadContext() : base(true)
        {}
        protected override Assembly Load(AssemblyName assemblyName) => null;
    }
}
