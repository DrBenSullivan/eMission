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
		/// Adds an <see cref="IPlugin"/> to added to the IoC container.
		/// </summary>
		/// <typeparam name="T">The <c>Type</c> of <see cref="IPlugin"/>.</typeparam>
		#endregion
		public static void AddPlugin<T>() where T : IPlugin
		{
			var plugin = Activator.CreateInstance<T>();
			_plugins.Add(plugin);
		}

		#region documentation
		/// <summary>
		/// Adds all configured <see cref="IPlugin"/> services to the IoC container.
		/// </summary>
		/// <param name="builder"></param>
		#endregion
		internal static void ConfigurePlugins(WebApplicationBuilder builder)
		{
			foreach (var plugin in _plugins)
			{
				plugin.ConfigureServices(builder);
			}
		}
	}
}
