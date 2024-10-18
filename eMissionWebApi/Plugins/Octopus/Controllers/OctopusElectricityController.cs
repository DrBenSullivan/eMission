using EMission.Api.Plugins.Octopus.DTOs;
using EMission.Application.Plugins.Octopus.Interfaces.ServiceInterfaces;
using EMission.Application.Plugins.Octopus.Models;
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
		private readonly IOctopusElectricityConsumptionService _octopusElectricityConsumptionService;
		#endregion

		#region constructor
		/// <summary>
		/// Creates an instance of <see cref="OctopusElectricityController"/>
		/// </summary>
		/// <param name="octopusElectricityService"></param>
		public OctopusElectricityController(IOctopusElectricityConsumptionService octopusElectricityService)
		{
			_octopusElectricityConsumptionService = octopusElectricityService;
		}
		#endregion

		#region documentation
		/// <summary>
		/// Requests a new carbon emissions estimate over time for Octopus customers.
		/// </summary>
		/// <param name="requestDto">An <see cref="OctopusElectricityEstimateRequestDto" />.</param>
		/// <remarks>
		/// <b>DISCLAIMER</b>: Does not represent actual carbon emissions.
		/// See <see href="https://octopus.energy/renewables/">Octopus website</see> for more information.
		/// </remarks>
		/// <returns><see cref="Task"/> with a result of type <see cref="IActionResult"/>.</returns>
		#endregion
		[HttpPost]
		public async Task<IActionResult> GetOctopusElectricityConsumption([Bind] OctopusElectricityConsumptionRequestDto requestDto)
		{
			if (!ModelState.IsValid)
			{
				var errors = ModelState.Values
						.SelectMany(val => val.Errors)
						.Select(err => err.ErrorMessage);

				throw new BadHttpRequestException($"Invalid {nameof(OctopusElectricityConsumptionRequestDto)} provided in {nameof(GetOctopusElectricityConsumption)} action method. Validation Errors: {errors}.");
			}

			var request = requestDto.ToOctopusElectricityConsumptionRequest();

			var response = await _octopusElectricityConsumptionService.GetHourlyElectricityConsumptionAsync(request);

			return Ok(response);
		}
	}
}
