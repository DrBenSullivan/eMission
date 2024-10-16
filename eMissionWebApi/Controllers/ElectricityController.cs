using EMission.Api.Models.DTOs;
using EMission.Application.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace EMission.Api.Controllers
{
	#region documentation
	/// <summary>
	/// Controller for requesting electricity estimates.
	/// </summary>
	#endregion
	[Route("api/[controller]")]
	[ApiController]
	public class ElectricityController : ControllerBase
	{
		#region private readonly fields
		private readonly IElectricityService _electricityService;
		#endregion

		#region constructor
		/// <summary>
		/// Creates an instance of <see cref="ElectricityController"/>
		/// </summary>
		/// <param name="electricityService"></param>
		public ElectricityController(IElectricityService electricityService)
		{
			_electricityService = electricityService;
		}
		#endregion

		#region documentation
		/// <summary>
		/// Requests a new carbon emissions estimate using a given electricity consumption.
		/// </summary>
		/// <param name="requestDto">An <see cref="ElectricityEstimateRequestDto"/>.</param>
		/// <returns><see cref="Task"/> with a result of type <see cref="IActionResult"/>.</returns>
		#endregion
		[HttpPost]
		public async Task<IActionResult> GetCarbonEmissionEstimate([Bind] ElectricityEstimateRequestDto requestDto)
		{
			if (!ModelState.IsValid)
			{
				var errors = ModelState.Values
						.SelectMany(val => val.Errors)
						.Select(err => err.ErrorMessage);

				throw new BadHttpRequestException($"Invalid {nameof(ElectricityEstimateRequestDto)} provided in {nameof(GetCarbonEmissionEstimate)} action method. Validation Errors: {errors}.");
			}

			var request = requestDto.ToElectricityEstimateRequest();
			var response = await _electricityService.GetElectricityEstimateAsync(request);
			var electricityEstimateResponseDto = response.ToElectricityEstimateResponseDto();
			return Ok(electricityEstimateResponseDto);
		}
	}
}
