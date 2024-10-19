using EMission.Api.Plugins.Octopus.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace EMission.Api.Interfaces
{
	#region documentation
	/// <summary>
	/// An interface to be implemented by controllers for requesting electricity consumption and carbon emissions estimates for a given energy provider.
	/// </summary>
	/// <remarks>
	/// See <see cref="OctopusElectricityController"/> for example implementation.
	/// </remarks>
	#endregion
	public interface IElectricityController<TRequest>
		where TRequest : IElectricityConsumptionRequestDto
	{
		#region documentation
		/// <summary>
		/// Requests hourly electricity consumption for a given energy provider.
		/// </summary>
		/// <param name="requestDto">An <see cref="IElectricityConsumptionRequestDto" />.</param>
		/// <remarks>
		/// See <see cref="OctopusElectricityController"/> for example implementation.
		/// </remarks>
		/// <returns>A <see cref="Task"/> with a result of type <see cref="IActionResult"/>.</returns>
		#endregion
		public Task<IActionResult> GetHourlyElectricityConsumption(TRequest requestDto);

		#region documentation
		/// <summary>
		/// Requests hourly estimated carbon emissions from electricity consumption for a given energy provider.
		/// </summary>
		/// <param name="requestDto">An <see cref="IElectricityConsumptionRequestDto" />.</param>
		/// <remarks>
		/// See <see cref="OctopusElectricityController"/> for example implementation.
		/// </remarks>
		/// <returns>A <see cref="Task"/> with a result of type <see cref="IActionResult"/>.</returns>
		#endregion
		public Task<IActionResult> GetHourlyEstimatedCarbonEmissions(TRequest requestDto);

		#region documentation
		/// <summary>
		/// Requests a graph of hourly electricity consumption values for a given energy provider.
		/// </summary>
		/// <param name="requestDto">An <see cref="IElectricityConsumptionRequestDto" />.</param>
		/// <remarks>
		/// See <see cref="OctopusElectricityController"/> for example implementation.
		/// </remarks>
		/// <returns>A <see cref="Task"/> with a result of type <see cref="IActionResult"/>.</returns>
		#endregion
		public Task<IActionResult> GetHourlyElectricityConsumptionGraph(TRequest requestDto);

		#region documentation
		/// <summary>
		/// Requests a graph of estimated hourly carbon emissions based on electricity consumption for a given energy provider.
		/// </summary>
		/// <param name="requestDto">An <see cref="IElectricityConsumptionRequestDto" />.</param>
		/// <remarks>
		/// See <see cref="OctopusElectricityController"/> for example implementation.
		/// </remarks>
		/// <returns>A <see cref="Task"/> with a result of type <see cref="IActionResult"/>.</returns>
		#endregion
		public Task<IActionResult> GetHourlyElectricityEmissionsEstimateGraph(TRequest requestDto);
	}
}
