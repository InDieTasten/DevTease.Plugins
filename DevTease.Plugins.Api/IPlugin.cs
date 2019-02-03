using System;

namespace DevTease.Plugins.Api
{
    public interface IPlugin
    {
        void Load();
        void Unload();
    }
}
