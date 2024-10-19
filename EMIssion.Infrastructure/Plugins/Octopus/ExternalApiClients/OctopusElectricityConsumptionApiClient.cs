using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using EMission.Application.Models;
using EMission.Application.Plugins.Octopus.Exceptions;
using EMission.Application.Plugins.Octopus.Interfaces.ExternalApiClientInterfaces;
using EMission.Application.Plugins.Octopus.Models;
using EMission.Infrastructure.Plugins.Octopus.Models;
using Newtonsoft.Json;

namespace EMission.Infrastructure.Plugins.Octopus.ExternalApiClients
{
	#region documentation
	/// <inheritdoc />
	#endregion
	public class OctopusElectricityConsumptionApiClient : IOctopusElectricityConsumptionApiClient
	{
		#region private readonly fields
		private readonly HttpClient _httpClient;
		private readonly string _uriBase;
		#endregion

		#region constructor
		#region documentation
		/// <summary>
		/// Creates a new instance of <see cref="OctopusElectricityConsumptionApiClient" />.
		/// </summary>
		/// <param name="httpClientFactory">Injected dependency.</param>
		#endregion
		public OctopusElectricityConsumptionApiClient(IHttpClientFactory httpClientFactory)
		{
			_uriBase = "https://api.octopus.energy/v1/electricity-meter-points/";

			var httpClient = httpClientFactory.CreateClient("Generic");
			httpClient.BaseAddress = new Uri(_uriBase);



			_httpClient = httpClient;
		}
		#endregion

		#region documentation
		/// <inheritdoc/>
		/// <exception cref="OctopusElectricityConsumptionApiClientException"></exception>
		#endregion
		public async Task<List<HourlyElectricityConsumptionKwh>> GetHourlyElectricityConsumptionKwhAsync(OctopusElectricityConsumptionRequest request)
		{
			var hours = request.Days * 24;

			var endpoint = $"{request.MPAN}/meters/{request.SerialNumber}/consumption/?page_size={hours}&group_by=hour";

			var authValue = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{request.APIKey}:"));
			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authValue);

			HttpResponseMessage response;

			try
			{
				response = await _httpClient.GetAsync(endpoint);
			}
			catch (TaskCanceledException ex) when (ex.CancellationToken.IsCancellationRequested)
			{
				throw new OctopusElectricityConsumptionApiClientException("The request was cancelled by the user.", ex);
			}
			catch (TaskCanceledException ex)
			{
				throw new OctopusElectricityConsumptionApiClientException("The request timed out. Please try again later.", ex);
			}
			catch (HttpRequestException ex)
			{
				throw new OctopusElectricityConsumptionApiClientException("An error occurred while sending the HTTP request.", ex);
			}

			var message = await response.Content.ReadAsStringAsync();

			if (!response.IsSuccessStatusCode)
			{
				throw new OctopusElectricityConsumptionApiClientException($"Request failed with status code {response.StatusCode}. Error: {message}");
			}

			var responseMessageJson = JsonDocument.Parse(message);

			if (responseMessageJson.RootElement.TryGetProperty("results", out var resultsElement))
			{

				try
				{
					var consumption = JsonConvert.DeserializeObject<List<OctopusElectricityConsumptionElement>>(resultsElement.ToString())
						.Select(e => e.ToElectricityConsumptionKilowattsPerHour())
						.ToList();

					return consumption
						?? throw new OctopusElectricityConsumptionApiClientException($"Failed to deserialize the API response. Response: {resultsElement.ToString()}");

				}
				catch (Exception ex)
				{
					throw new OctopusElectricityConsumptionApiClientException(message, ex);
				}
			}

			throw new OctopusElectricityConsumptionApiClientException($"The expected 'results' property in the API response is missing or not an array. ResultsElement: {resultsElement.ToString()}");
		}

	}
}