using EMission.Application.Models;

namespace EMission.Application.Interfaces.ExternalApiClientInterfaces
{
	#region documentation
	/// <summary>
	/// Represents an external API client class with methods to retrieve electricity estimates.
	/// </summary>
	#endregion
	public interface IElectricityEstimatesApiClient
	{
		#region documentation
		/// <summary>
		/// Retrieves an <see cref="ElectricityEstimateRequest"/> object based on the <c>request</c> by calling an external API.
		/// </summary>
		/// <param name="request"></param>
		/// <exception cref="ElectricityEstimatesApiClientException">Thrown if the API call is cancelled by the user, timesout, fails to connect, delivers an unsuccessful 
		/// response or, the response cannot be serialized.</exception>
		/// <returns>A <see cref="Task"/> with a result type of <see cref="ElectricityEstimateResponse"/>.</returns>
		#endregion
		public Task<ElectricityEstimateResponse> GetElectricityEstimateAsync(ElectricityEstimateRequest request);
	}
}
