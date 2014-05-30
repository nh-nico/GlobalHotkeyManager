using nhammerlGlobalHotkeyPluginLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace nhammerl.GlobalHotkeyManager.Plugins
{
    public class GlobalHotkeyManagerLoadPlugins : ILoadPlugins
    {
        private readonly IPluginPath _pluginPath;

        public GlobalHotkeyManagerLoadPlugins(IPluginPath pluginPath)
        {
            if (pluginPath == null) { throw new ArgumentNullException("pluginPath"); }

            _pluginPath = pluginPath;
        }

        /// <summary>
        /// Get all instances of IGlobalHotkeyPlugin from Assemblies in PluginsDirectory
        /// </summary>
        public IEnumerable<IGlobalHotkeyPlugin> Plugins
        {
            get
            {
                return Directory.GetFiles(_pluginPath.Value, "*.dll")
                    .SelectMany(assemblyFile => (from t in Assembly.LoadFile(assemblyFile).GetTypes()
                                                 where t.GetInterfaces().Contains(typeof(IGlobalHotkeyPlugin))
                                                 && t.GetConstructor(Type.EmptyTypes) != null
                                                 select Activator.CreateInstance(t) as IGlobalHotkeyPlugin)).ToList();
            }
        }
    }
}