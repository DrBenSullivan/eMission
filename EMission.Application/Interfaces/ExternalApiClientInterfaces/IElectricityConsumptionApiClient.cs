using EMission.Application.Interfaces.ModelInterfaces;
using EMission.Application.Models;

namespace EMission.Application.Interfaces.ExternalApiClientInterfaces
{
	#region documentation
	/// <summary>
	/// An interface to be implemented by electricity consumption api client classes in the infrastructure layer.
	/// </summary>
	/// <remarks>
	/// See <c>~/EMissions.Infrastructure/Plugins/Octopus/ExternalApiClients/OctopusElectricityConsumptionApiClient</c> for example implementation.
	/// </remarks>
	/// <typeparam name="TRequest">A request object that implements <see cref="IElectricityConsumptionRequest"/></typeparam>
	#endregion
	public interface IElectricityConsumptionApiClient<TRequest>
		where TRequest : IElectricityConsumptionRequest
	{
		#region documentation
		/// <summary>
		/// Gets an A list of <see cref="HourlyElectricityConsumptionKwh"/> objects by asynchronously calling an external API client.
		/// </summary>
		/// <param name="request">An instance of an object implementing <see cref="IElectricityConsumptionRequest" />.</param>
		/// <returns>A list of <see cref="HourlyElectricityConsumptionKwh"/> objects.</returns>
		/// <remarks>
		/// See <c>~/EMissions.Infrastructure/Plugins/Octopus/ExternalApiClients/OctopusElectricityConsumptionApiClient</c> for example implementation.
		/// </remarks>
		#endregion
		public Task<List<HourlyElectricityConsumptionKwh>> GetHourlyElectricityConsumptionKwhAsync(TRequest request);
	}
}
