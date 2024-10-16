using EMission.Api.Models.OctopusModels.DTOs;
using EMission.Application.Interfaces.ServiceInterfaces.OctopusServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace EMission.Api.Controllers.Octopus
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
		private readonly IOctopusElectricityService _octopusElectricityService;
		#endregion

		#region constructor
		/// <summary>
		/// Creates an instance of <see cref="OctopusElectricityController"/>
		/// </summary>
		/// <param name="octopusElectricityService"></param>
		public OctopusElectricityController(IOctopusElectricityService octopusElectricityService)
		{
			_octopusElectricityService = octopusElectricityService;
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
		public async Task<IActionResult> GetOctopusElectricityCarbonEmissionsEstimate(OctopusElectricityEstimateRequestDto requestDto)
		{
			if (!ModelState.IsValid)
			{
				var errors = ModelState.Values
						.SelectMany(val => val.Errors)
						.Select(err => err.ErrorMessage);

				throw new BadHttpRequestException($"Invalid {nameof(OctopusElectricityEstimateRequestDto)} provided in {nameof(GetOctopusElectricityCarbonEmissionsEstimate)} action method. Validation Errors: {errors}.");
			}

			var request = requestDto.ToOctopusElectricityEstimateRequest();
			var response = await _octopusElectricityService.GetElectricityEstimateAsync(request);
			var octopusElectricityEstimateResponseDto = response.ToOctopusElectricityEstimateResponseDto();
			return Ok(octopusElectricityEstimateResponseDto);
		}
	}
}
