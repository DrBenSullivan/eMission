using EMission.Api.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EMission.Api.Controllers.OctopusControllers
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
	[Route("api/octopus/[controller]")]
	[ApiController]
	public class OctopusElectricityController : ControllerBase
	{
		#region private readonly fields
		#endregion

		#region constructor
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
		public async Task<IActionResult> GetOctopusElectricityCarbonEmissionsEstimate(OctopusElectricityEstimateRequestDto requestDto)
		{
			if (!ModelState.IsValid)
			{
				var errors = ModelState.Values
						.SelectMany(val => val.Errors)
						.Select(err => err.ErrorMessage);

				throw new BadHttpRequestException($"Invalid {nameof(ElectricityEstimateRequestDto)} provided in {nameof(GetCarbonEmissionEstimate)} action method. Validation Errors: {errors}.");
			}

			var request = requestDto.ToOctopusElectricityEstimateRequest();
			var response = await _octopusElectricityService.GetElectricityEstimateAsync(request);
			var octopusElectricityEstimateResponseDto = response.ToOctopusElectricityEstimateResponseDto();
			return Ok(octopusElectricityEstimateResponseDto);
		}
	}
}
