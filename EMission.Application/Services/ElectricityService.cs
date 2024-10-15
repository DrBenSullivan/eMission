using EMission.Application.Exceptions;
using EMission.Application.Interfaces.ExternalApiClientInterfaces;
using EMission.Application.Interfaces.ServiceInterfaces;
using EMission.Application.Models;

namespace EMission.Application.Services
{
	public class ElectricityService : IElectricityService
	{
		#region private readonly fields
		private readonly IElectricityEstimatesApiClient _apiClient;
		#endregion

		#region constructor
		/// <summary>
		/// Creates an instance of <see cref="ElectricityService"/>.
		/// </summary>
		public ElectricityService(IElectricityEstimatesApiClient apiClient)
		{
			_apiClient = apiClient;
		}
		#endregion

		public async Task<ElectricityEstimateResponse> GetElectricityEstimateAsync(ElectricityEstimateRequest request)
		{
			try
			{
				return await _apiClient.GetElectricityEstimateAsync(request);
			}
			catch (Exception ex)
			{
				throw new ElectricityEstimatesApiClientException("An unexpected error occurred while retrieving data from an external API. Please try again later.", ex);
			}
		}
	}
}
