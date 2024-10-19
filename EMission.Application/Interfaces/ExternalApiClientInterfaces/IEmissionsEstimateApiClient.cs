using EMission.Application.Exceptions;
using EMission.Application.Models;

namespace EMission.Application.Interfaces.ExternalApiClientInterfaces
{
	#region documentation
	/// <summary>
	/// An interface to be implemented by an external API client class with methods to retrieve electricity emissions estimates.
	/// </summary>
	#endregion
	public interface IEmissionsEstimateApiClient
	{
		#region documentation
		/// <summary>
		/// Gets an <see cref="ElectricityEmissionsEstimateResponse"/> based on the <see cref="ElectricityEmissionsEstimateRequest"/> by asynchronously calling an external API.
		/// </summary>
		/// <param name="request">An <see cref="ElectricityEmissionsEstimateRequest"/>.</param>
		/// <exception cref="ElectricityEmissionsApiClientException">Thrown if an exception thrown by the external API client is thrown.</exception>
		/// <returns>A <see cref="Task"/> with a result type of <see cref="ElectricityEmissionsEstimateResponse"/>.</returns>
		#endregion
		public Task<ElectricityEmissionsEstimateResponse> GetElectricityEmissionsEstimateAsync(ElectricityEmissionsEstimateRequest request);
	}
}
