using EMission.Application.Interfaces.ExternalApiClientInterfaces;
using EMission.Application.Interfaces.ServiceInterfaces;
using EMission.Application.Services;
using EMission.Infrastructure.ExternalApiClients;

namespace EMission.Api.Extensions
{
	internal static class WebApplicationBuilderExtensions
	{
		#region documentation
		/// <summary>
		/// Adds all required services to the <see cref="WebApplicationBuilder"/>.
		/// </summary>
		/// <param name="builder">The instance of <see cref="WebApplicationBuilder"/>.</param>
		/// <returns>The <see cref="WebApplicationBuilder"/> with added services.</returns>
		#endregion
		internal static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
		{
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.AddExternalApiClients();

			builder.Services.AddControllers();
			builder.Services.AddTransient<IElectricityService, ElectricityService>();
			builder.Services.AddTransient<IElectricityEstimatesApiClient, ElectricityEstimatesApiClient>();
			return builder;
		}

		#region documentation
		/// <summary>
		/// Adds all necessary HttpClients to the IoC container for the application's external API calls.
		/// </summary>
		/// <exception cref="ApplicationException">Thrown if the <c>CarbonInterfaceApiBaseUri</c> is not present in <c>applicationsettings.json</c>.</exception>
		#endregion
		internal static WebApplicationBuilder AddExternalApiClients(this WebApplicationBuilder builder)
		{
			string apiBaseUri = builder.Configuration.GetValue<string>("CarbonInterfaceApiBaseUri")
				?? throw new ApplicationException("Carbon Interface API Base Uri was not be found in application configuration.");

			string apiKey = builder.Configuration["CarbonInterfaceApiKey"]
				?? throw new ApplicationException("Carbon Interface API Key was not found in application configuration.");

			builder.Services.AddHttpClient("CarbonInterfaceApiClient", client =>
			{
				client.BaseAddress = new Uri(apiBaseUri);
				client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
				client.Timeout = TimeSpan.FromSeconds(30);
			});

			return builder;
		}
	}
}

