using EMission.Application.Exceptions;
using EMission.Application.Interfaces.ExternalApiClientInterfaces;
using EMission.Application.Interfaces.ServiceInterfaces;
using EMission.Application.Models;

namespace EMission.Application.Services
{
	public class EmissionsEstimateService : IElectricityEmissionsEstimateService
	{
		#region private readonly fields
		private readonly IEmissionsEstimateApiClient _apiClient;
		#endregion

		#region constructor
		/// <summary>
		/// Creates an instance of <see cref="EmissionsEstimateService"/>.
		/// </summary>
		public EmissionsEstimateService(IEmissionsEstimateApiClient apiClient)
		{
			_apiClient = apiClient;
		}
		#endregion

		///<inheritdoc />
		public async Task<ElectricityEmissionsEstimateResponse> GetElectricityEmissionsEstimateAsync(ElectricityEmissionsEstimateRequest request)
		{
			try
			{
				return await _apiClient.GetElectricityEmissionsEstimateAsync(request);
			}
			catch (Exception ex)
			{
				throw new ElectricityEmissionsApiClientException("An unexpected error occurred while retrieving data from an external API. Please try again later.", ex);
			}
		}

		///<inheritdoc />
		public async Task<double> GetElectricityEmissionFactorAsync(string countryCode)
		{
			var emissionFactorRequest = new ElectricityEmissionsEstimateRequest()
			{
				CountryCode = countryCode,
				ElectricalUnits = Domain.Enums.ElectricalUnit.KWh,
				TotalUnits = 1
			};

			try
			{
				var emissionFactorResponse = await _apiClient.GetElectricityEmissionsEstimateAsync(emissionFactorRequest);
				return emissionFactorResponse.CarbonEmissionsGrams;
			}
			catch (Exception ex)
			{
				throw new ElectricityEmissionsApiClientException("An unexpected error occurred while retrieving data from an external API. Please try again later.", ex);
			}
		}
	}
}
