using EMission.Application.Exceptions;
using EMission.Application.Models;

namespace EMission.Application.Interfaces.ServiceInterfaces
{
	public interface IElectricityEmissionsEstimateService
	{
		#region documentation
		/// <summary>
		/// Requests an estimate of carbon emissions from the emissions estimate API client.
		/// </summary>
		/// <param name="request">An <see cref="ElectricityEmissionsEstimateRequest"/>.</param>
		/// <returns>A <see cref="Task"/> of Type <see cref="ElectricityEmissionsEstimateResponse"/>.</returns>
		/// <exception cref="ElectricityEmissionsApiClientException">Caught Exceptions rethrown.</exception>
		#endregion
		public Task<ElectricityEmissionsEstimateResponse> GetElectricityEmissionsEstimateAsync(ElectricityEmissionsEstimateRequest request);

		#region documentation
		/// <summary>
		/// Requests an Electricity Emission Factor from the Emissions Estimate API Client. An emission factor represent the weight in grams of 
		/// carbon dioxide released per kWh of electricity consumed. It is given the unit g/kWh.
		/// <para>
		/// Emission factors are country-specific dependent on a given country's methods of energy production.
		/// </para>
		/// </summary>
		/// <param name="countryCode">The 2-letter ISO Country Code of the country the request is relevant to.</param>
		/// <returns>A <c>double</c> representing the emission factor in g/kWh.</returns>
		/// <exception cref="ElectricityEmissionsApiClientException">Caught Exceptions rethrown.</exception>
		#endregion
		public Task<double> GetElectricityEmissionFactorAsync(string countryCode);
	}
}
