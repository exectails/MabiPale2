using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MabiPale2.Plugins
{
	public abstract class Plugin
	{
		protected IPluginManager manager;

		public Plugin(IPluginManager pluginManager)
		{
			manager = pluginManager;
		}

		/// <summary>
		/// Name of the plugin.
		/// </summary>
		public abstract string Name { get; }

		/// <summary>
		/// Called during loading the plugin.
		/// </summary>
		public abstract void Initialize();
	}
}
