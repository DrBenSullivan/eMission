using System.Text.Json;
using EMission.Application.Exceptions;
using EMission.Application.Interfaces.ExternalApiClientInterfaces;
using EMission.Application.Models;
using EMission.Infrastructure.Extensions;
using EMission.Infrastructure.Models;

namespace EMission.Infrastructure.ExternalApiClients
{
	#region documentation
	/// <summary>
	/// A class representing an External API client for estimating carbon emissions by implementing <see cref="IEmissionsEstimateApiClient"/>.
	/// </summary>
	#endregion
	public class CarbonInterfaceExternalApiClient : IEmissionsEstimateApiClient
	{
		#region private readonly fields
		private readonly HttpClient _httpClient;
		private readonly string _endpoint;
		#endregion

		#region constructor
		/// <summary>
		/// Creates a new instance of <see cref="CarbonInterfaceExternalApiClient" />.
		/// </summary>
		/// <param name="httpClientFactory">Injected dependency.</param>
		public CarbonInterfaceExternalApiClient(IHttpClientFactory httpClientFactory)
		{
			_httpClient = httpClientFactory.CreateClient("CarbonInterfaceApiClient");
			_endpoint = "estimates";
		}
		#endregion

		#region documentation
		/// <inheritdoc />
		#endregion
		public async Task<ElectricityEmissionsEstimateResponse> GetElectricityEmissionsEstimateAsync(ElectricityEmissionsEstimateRequest request)
		{
			var requestStringContent = request.ToStringContent();
			HttpResponseMessage response;

			try
			{
				response = await _httpClient.PostAsync(_endpoint, requestStringContent);
			}
			catch (TaskCanceledException ex) when (ex.CancellationToken.IsCancellationRequested)
			{
				throw new ElectricityEmissionsApiClientException("The request was cancelled by the user.", ex);
			}
			catch (TaskCanceledException ex)
			{
				throw new ElectricityEmissionsApiClientException("The request timed out. Please try again later.", ex);
			}
			catch (HttpRequestException ex)
			{
				throw new ElectricityEmissionsApiClientException("An error occurred while sending the HTTP request.", ex);
			}

			var message = await response.Content.ReadAsStringAsync();

			if (!response.IsSuccessStatusCode)
			{
				throw new ElectricityEmissionsApiClientException($"Request failed with status code {response.StatusCode}. Error: {message}");
			}

			var responseMessageJson = JsonDocument.Parse(message);
			var responseAttributes = responseMessageJson.RootElement.GetProperty("data").GetProperty("attributes");

			var responseDto = JsonSerializer.Deserialize<ElectricityEmissionsEstimateApiResponseDto>(responseAttributes)
				?? throw new ElectricityEmissionsApiClientException($"Failed to parse the response from the external API. Response: {message}");

			return responseDto.ToCarbonInterfaceElectricityEmissionsEstimateResponse();
		}
	}
}
