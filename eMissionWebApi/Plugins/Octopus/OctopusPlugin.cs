using EMission.Api.Interfaces;
using EMission.Application.Plugins.Octopus.Interfaces.ExternalApiClientInterfaces;
using EMission.Application.Plugins.Octopus.Interfaces.ServiceInterfaces;
using EMission.Application.Plugins.Octopus.Services;
using EMission.Infrastructure.Plugins.Octopus.ExternalApiClients;

namespace EMission.Api.Plugins.Octopus
{
	#region documentation 
	/// <summary>
	/// A class to be found by <see cref="PluginConfigurer"/> to add necessary services to the IoC container.
	/// </summary>
	#endregion
	public class OctopusPlugin : IPlugin
	{
		#region documentation
		/// <summary>
		/// Adds necessary services to the IoC container.
		/// <para>
		/// This is automatically called by <see cref="PluginConfigurer"/> during application startup.
		/// </para>
		/// </summary>
		/// <param name="builder"></param>
		#endregion
		public void ConfigureServices(WebApplicationBuilder builder)
		{
			builder.Services.AddTransient<IOctopusElectricityService, OctopusElectricityService>();
			builder.Services.AddTransient<IOctopusElectricityConsumptionApiClient, OctopusElectricityConsumptionApiClient>();
		}
	}
}
