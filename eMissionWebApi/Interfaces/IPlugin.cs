using EMission.Api.Plugins.Octopus;

namespace EMission.Api.Interfaces
{
	#region documentation
	/// <summary>
	/// Interface to assist in independent development of Plugins for other Energy Providers.
	/// <para>
	/// See <see cref="OctopusPlugin"/> for implementation.
	/// </para>
	/// </summary>
	#endregion
	public interface IPlugin
	{
		#region documentation
		/// <summary>
		/// Adds Plugin services to the IoC container.
		/// <para>
		/// See <see cref="OctopusPlugin" /> for implementation.
		/// </para>
		/// </summary>
		/// <param name="builder"></param>
		#endregion
		void ConfigureServices(WebApplicationBuilder builder);
	}
}
