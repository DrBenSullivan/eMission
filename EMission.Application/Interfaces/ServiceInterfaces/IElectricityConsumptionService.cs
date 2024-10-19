using EMission.Application.Interfaces.ModelInterfaces;
using EMission.Application.Models;

namespace EMission.Application.Interfaces.ServiceInterfaces
{
	public interface IElectricityConsumptionService<TRequest>
		where TRequest : IElectricityConsumptionRequest
	{
		#region documentation
		/// <summary>
		/// Gets a list of hourly electricity consumption in kWh.
		/// </summary>
		/// <param name="request">An object implementing <see cref="IElectricityConsumptionRequest"/>.</param>
		/// <returns>A list of <see cref="HourlyElectricityConsumptionKwh"/>.</returns>
		#endregion
		public Task<List<HourlyElectricityConsumptionKwh>> GetHourlyConsumptionAsync(TRequest request);

		#region documentation
		/// <summary>
		/// Gets a list of hourly emissions estimates in grams based on electricity consumption.
		/// </summary>
		/// <param name="request">An object implementing <see cref="IElectricityConsumptionRequest"/>.</param>
		/// <returns>A list of <see cref="HourlyElectricityEmissionsEstimate"/>.</returns>
		#endregion
		public Task<List<HourlyElectricityEmissionsEstimate>> GetHourlyEmissionsEstimateAsync(TRequest request);

		#region documentation
		/// <summary>
		/// Gets a <c>jpeg</c> as a <c>byte[]</c> representing a plotted graph of hourly electricity consumption asynchronously.
		/// </summary>
		/// <param name="request">An object implementing <see cref="IElectricityConsumptionRequest"/>.</param>
		/// <returns>A <see cref="Task"/> with a return type of <c>byte[]</c> representing the <c>jpeg</c> of the plotted graph.</returns>
		#endregion
		public Task<byte[]> GetHourlyConsumptionGraphAsync(TRequest request);

		#region documentation
		/// <summary>
		/// Gets a <c>jpeg</c> as a <c>byte[]</c> representing a plotted graph of hourly emissions estimates in grams based on electricity consumption asynchronously.
		/// </summary>
		/// <param name="request">An object implementing <see cref="IElectricityConsumptionRequest"/>.</param>
		/// <returns>A <see cref="Task"/> with a return type of <c>byte[]</c> representing the <c>jpeg</c> of the plotted graph.</returns>
		#endregion
		public Task<byte[]> GetHourlyEmissionsGraphAsync(TRequest request);
	}
}
