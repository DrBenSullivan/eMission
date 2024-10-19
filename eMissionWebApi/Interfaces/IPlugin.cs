using EMission.Api.Plugins.Octopus;

namespace EMission.Api.Interfaces
{
	#region documentation
	/// <summary>
	/// Interface to assist to be implemented by Plugins developed for individual Energy Providers.
	/// <para>
	/// See <see cref="OctopusPlugin"/> for implementation.
	/// </para>
	/// </summary>
	#endregion
	public interface IPlugin
	{
		#region documentation
		/// <summary>
		/// Scans the assembly for Plugins implementing <see cref="IPlugin"/> whose services are to be added to the IoC container.
		/// <para>
		/// See <see cref="OctopusPlugin" /> for implementation.
		/// </para>
		/// </summary>
		/// <param name="builder"></param>
		#endregion
		void ConfigureServices(WebApplicationBuilder builder);
	}
}
