using System.Reflection;
using EMission.Api.Interfaces;

namespace EMission.Api
{
	#region documentation
	/// <summary>
	/// Static class to add <see cref="IPlugin"/> <c>Types</c>. The <see cref="IPlugin"/> services will then be added to the IoC container.
	/// </summary>
	#endregion
	public static class PluginConfigurer
	{
		private readonly static List<IPlugin> _plugins = [];

		#region documentation
		/// <summary>
		/// Scans the assembly for types that implement <see cref="IPlugin"/> and adds them to the IoC container.
		/// </summary>
		/// <param name="builder">The Web Application Builder to add the plugins to as services.</param>
		#endregion
		internal static void ConfigurePlugins(WebApplicationBuilder builder)
		{
			var pluginTypes = Assembly.GetExecutingAssembly()
				.GetTypes()
				.Where(t => typeof(IPlugin).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);


			if (pluginTypes.Any())
			{
				foreach (var type in pluginTypes)
				{
					if (Activator.CreateInstance(type) is IPlugin plugin)
					{
						_plugins.Add(plugin);
					}
				}

				foreach (var plugin in _plugins)
				{
					plugin.ConfigureServices(builder);
				}
			}
		}
	}
}
