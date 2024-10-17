using EMission.Api.Interfaces;
using EMission.Application.Plugins.Octopus.Interfaces.ExternalApiClientInterfaces;
using EMission.Application.Plugins.Octopus.Interfaces.ServiceInterfaces;
using EMission.Application.Plugins.Octopus.Services;
using EMission.Infrastructure.Plugins.Octopus.ExternalApiClients;

namespace EMission.Api.Plugins.Octopus
{
	/// <inheritdoc cref="IPlugin"/>
	public class OctopusPlugin : IPlugin
	{
		/// <inheritdoc cref="ConfigureServices(WebApplicationBuilder)"/>
		public void ConfigureServices(WebApplicationBuilder builder)
		{
			builder.Services.AddTransient<IOctopusElectricityConsumptionService, OctopusElectricityConsumptionService>();
			builder.Services.AddTransient<IOctopusElectricityConsumptionApiClient, OctopusElectricityConsumptionApiClient>();
		}
	}
}
