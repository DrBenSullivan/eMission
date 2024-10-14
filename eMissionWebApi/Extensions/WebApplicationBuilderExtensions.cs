namespace EMission.Api.Extensions
{
	#region documentation
	/// <summary>
	/// Extension class for <see cref="WebApplicationBuilder"/>
	/// </summary>
	#endregion
	public static class WebApplicationBuilderExtensions
	{
		#region documentation
		/// <summary>
		/// Adds all necessary HttpClients to the IoC container for the application's external API calls.
		/// </summary>
		/// <exception cref="ApplicationException">Thrown if the <c>CarbonInterfaceApiBaseUri</c> is not present in <c>applicationsettings.json</c>.</exception>
		#endregion
		public static WebApplicationBuilder AddExternalApiClients(this WebApplicationBuilder builder)
		{
			string apiBaseUri = builder.Configuration.GetValue<string>("CarbonInterfaceApiBaseUri")
				?? throw new ApplicationException("Carbon Interface API Base Uri was not be found in application configuration.");

			string apiKey = builder.Configuration["CarbonInterfaceApiKey"]
				?? throw new ApplicationException("Carbon Interface API Key was not found in application configuration.");

			builder.Services.AddHttpClient("CarbonInterfaceApiClient", client =>
			{
				client.BaseAddress = new Uri(apiBaseUri);
				client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
			});

			return builder;
		}
	}
}

