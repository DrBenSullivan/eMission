using EMission.Application.Interfaces.ExternalApiClientInterfaces;
using EMission.Application.Interfaces.ServiceInterfaces;
using EMission.Application.Services;
using EMission.Domain.Entities.Identity;
using EMission.Infrastructure.DbContext;
using EMission.Infrastructure.ExternalApiClients;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EMission.Api.Extensions
{
	#region documentation
	/// <summary>
	/// Extension class for <see cref="WebApplicationBuilder"/>.
	/// </summary>
	#endregion
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
			builder.Services.AddSwaggerGen(options =>
			{
				options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "api.xml"));
			});

			builder.Services.AddDbContext<ApplicationDbContext>( options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
			});

			builder.Services
				.AddIdentity<ApplicationUser, ApplicationRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders()
				.AddUserStore<UserStore<ApplicationUser, ApplicationRole, ApplicationDbContext, Guid>>()
				.AddRoleStore<RoleStore<ApplicationRole, ApplicationDbContext, Guid>>();

			builder.Services.AddControllers();

			builder.AddCarbonInterfaceApiHttpClientFactory();
			builder.AddGenericHttpClientFactory();
			builder.Services.AddTransient<IElectricityEmissionsEstimateService, EmissionsEstimateService>();
			builder.Services.AddTransient<IEmissionsEstimateApiClient, CarbonInterfaceExternalApiClient>();
			PluginConfigurer.ConfigurePlugins(builder);

			return builder;
		}

		#region documentation
		/// <summary>
		/// Adds the Carbon Interface External API Client Factory to the IoC container.
		/// <para>
		/// Requires a Carbon Interface API key (obtained <see href="https://www.carboninterface.com/">here</see>) added to the application configuration with key <c>"CarbonInterfaceApiKey"</c>.
		/// </para>
		/// <para>
		/// Requires a Carbon Interface API base URI (see <c>appsettings.json</c>) added to the application configuration with key <c>"CarbonInterfaceApiBaseUri"</c>.
		/// </para>
		/// </summary>
		/// <exception cref="ApplicationException">Thrown if either <c>"CarbonInterfaceApiBaseUri"</c> or <c>"CarbonInterfaceApiKey"</c> are not present in the application configuration.</exception>
		#endregion
		internal static WebApplicationBuilder AddCarbonInterfaceApiHttpClientFactory(this WebApplicationBuilder builder)
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

		#region documentation
		/// <summary>
		/// Adds a Generic Http Client Factory for open configuration to the IoC container.
		/// </summary>
		#endregion
		internal static WebApplicationBuilder AddGenericHttpClientFactory(this WebApplicationBuilder builder)
		{
			builder.Services.AddHttpClient("Generic", client =>
			{
				client.Timeout = TimeSpan.FromSeconds(30);
			});

			return builder;
		}
	}
}

