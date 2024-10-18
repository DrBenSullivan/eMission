using EMission.Api.Plugins.Octopus.DTOs;
using EMission.Application.Plugins.Octopus.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace EMission.Api.Plugins.Octopus.Controllers
{
	#region documentation
	/// <summary>
	/// Controller for requesting an Octopus Electricity Carbon Emissions estimate.
	/// </summary>
	/// <remarks>
	/// <b>DISCLAIMER</b>: Does not represent actual carbon emissions.
	/// See <see href="https://octopus.energy/renewables/">Octopus website</see> for more information.
	/// </remarks>
	#endregion
	[Route("api/octopus")]
	[ApiController]
	public class OctopusElectricityController : ControllerBase
	{
		#region private readonly fields
		private readonly IOctopusElectricityService _octopusElectricityConsumptionService;
		#endregion

		#region constructor
		/// <summary>
		/// Creates an instance of <see cref="OctopusElectricityController"/>
		/// </summary>
		/// <param name="octopusElectricityService"></param>
		public OctopusElectricityController(IOctopusElectricityService octopusElectricityService)
		{
			_octopusElectricityConsumptionService = octopusElectricityService;
		}
		#endregion

		#region documentation
		/// <summary>
		/// Requests hourly electricity consumption for Octopus customers.
		/// </summary>
		/// <param name="requestDto">An <see cref="OctopusElectricityConsumptionRequestDto" />.</param>
		/// <remarks>
		/// <b>DISCLAIMER</b>: Does not represent actual carbon emissions.
		/// See <see href="https://octopus.energy/renewables/">Octopus website</see> for more information.
		/// </remarks>
		/// <returns><see cref="Task"/> with a result of type <see cref="IActionResult"/>.</returns>
		#endregion
		[HttpPost("consumption")]
		public async Task<IActionResult> GetHourlyElectricityConsumption([Bind] OctopusElectricityConsumptionRequestDto requestDto)
		{
			if (!ModelState.IsValid)
			{
				BadRequest(ModelState);
			}

			var request = requestDto.ToOctopusElectricityConsumptionRequest();

			var response = await _octopusElectricityConsumptionService.GetHourlyConsumptionAsync(request);

			return Ok(response);
		}

		#region documentation
		/// <summary>
		/// Requests hourly estimated carbon emissions from electricity consumption for Octopus customers.
		/// </summary>
		/// <param name="requestDto">An <see cref="OctopusElectricityConsumptionRequestDto" />.</param>
		/// <remarks>
		/// <b>DISCLAIMER</b>: Does not represent actual carbon emissions.
		/// See <see href="https://octopus.energy/renewables/">Octopus website</see> for more information.
		/// </remarks>
		/// <returns><see cref="Task"/> with a result of type <see cref="IActionResult"/>.</returns>
		#endregion
		[HttpPost("emissions")]
		public async Task<IActionResult> GetHourlyEstimatedCarbonEmissions([Bind] OctopusElectricityConsumptionRequestDto requestDto)
		{
			if (!ModelState.IsValid)
			{
				BadRequest(ModelState);
			}

			var request = requestDto.ToOctopusElectricityConsumptionRequest();

			var response = await _octopusElectricityConsumptionService.GetHourlyEmissionsEstimateAsync(request);

			return Ok(response);
		}

		#region documentation
		/// <summary>
		/// Requests hourly electricity consumption graph for Octopus customers.
		/// </summary>
		/// <param name="requestDto">An <see cref="OctopusElectricityConsumptionRequestDto" />.</param>
		/// <remarks>
		/// <b>DISCLAIMER</b>: Does not represent actual carbon emissions.
		/// See <see href="https://octopus.energy/renewables/">Octopus website</see> for more information.
		/// </remarks>
		/// <returns><see cref="Task"/> with a result of type <see cref="IActionResult"/>.</returns>
		#endregion
		[HttpPost("consumption-graph")]
		public async Task<IActionResult> GetHourlyElectricityConsumptionGraph([Bind] OctopusElectricityConsumptionRequestDto requestDto)
		{
			if (!ModelState.IsValid)
			{
				BadRequest(ModelState);
			}

			var request = requestDto.ToOctopusElectricityConsumptionRequest();

			var response = await _octopusElectricityConsumptionService.GetHourlyConsumptionGraphAsync(request);

			return File(response, "image/jpeg");
		}
	}
}
