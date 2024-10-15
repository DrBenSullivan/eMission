using System.Text.Json;
using EMission.Application.Exceptions;
using EMission.Application.Interfaces.ExternalApiClientInterfaces;
using EMission.Application.Models;
using EMission.Infrastructure.Extensions;
using EMission.Infrastructure.Models;

namespace EMission.Infrastructure.ExternalApiClients
{
	#region documentation
	/// <inheritdoc />
	#endregion
	public class ElectricityEstimatesApiClient : IElectricityEstimatesApiClient
	{
		#region private readonly fields
		private readonly HttpClient _httpClient;
		private readonly string _endpoint;
		#endregion

		#region constructor
		/// <summary>
		/// Creates a new instance of <see cref="ElectricityEstimatesApiClient" />.
		/// </summary>
		/// <param name="httpClientFactory">Injected dependency.</param>
		public ElectricityEstimatesApiClient(IHttpClientFactory httpClientFactory)
		{
			_httpClient = httpClientFactory.CreateClient("CarbonInterfaceApiClient");
			_endpoint = "estimates";
		}
		#endregion

		#region documentation
		/// <inheritdoc />
		#endregion
		public async Task<ElectricityEstimateResponse> GetElectricityEstimateAsync(ElectricityEstimateRequest request)
        {
            var requestStringContent = request.ToStringContent();
            HttpResponseMessage response;

            try
            {
                response = await _httpClient.PostAsync(_endpoint, requestStringContent);
            }
            catch (TaskCanceledException ex) when (ex.CancellationToken.IsCancellationRequested)
            {
                throw new ElectricityEstimatesApiClientException("The request was cancelled by the user.", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new ElectricityEstimatesApiClientException("The request timed out. Please try again later.", ex);
            }
            catch (HttpRequestException ex)
            {
                throw new ElectricityEstimatesApiClientException("An error occurred while sending the HTTP request.", ex);
            }

            var message = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ElectricityEstimatesApiClientException($"Request failed with status code {response.StatusCode}. Error: {message}");
            }

            var responseMessageJson = JsonDocument.Parse(message);
            var responseAttributes = responseMessageJson.RootElement.GetProperty("data").GetProperty("attributes");

            var responseDto = JsonSerializer.Deserialize<ElectricityAPIResponseDto>(responseAttributes)
                ?? throw new ElectricityEstimatesApiClientException($"Failed to parse the response from the external API. Response: {message}");

            return responseDto.ToElectricityEstimateResponse();
        }
	}
}
