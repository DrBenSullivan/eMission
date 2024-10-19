using EMission.Api.Models.DTOs;
using EMission.Application.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace EMission.Api.Controllers
{
	#region documentation
	/// <summary>
	/// Controller for requesting carbon emission estimates from electricity consumption.
	/// </summary>
	#endregion
	[Route("api/[controller]")]
	[ApiController]
	public class ElectricityEmissionsController : ControllerBase
	{
		#region private readonly fields
		private readonly IElectricityEmissionsEstimateService _carbonInterfaceElectricityEmissionsEstimateService;
		#endregion

		#region constructor
		/// <summary>
		/// Creates an instance of <see cref="ElectricityEmissionsController"/>
		/// </summary>
		/// <param name="carbonInterfaceElectricityEmissionsEstimateService"></param>
		public ElectricityEmissionsController(IElectricityEmissionsEstimateService carbonInterfaceElectricityEmissionsEstimateService)
		{
			_carbonInterfaceElectricityEmissionsEstimateService = carbonInterfaceElectricityEmissionsEstimateService;
		}
		#endregion

		#region documentation
		/// <summary>
		/// Requests a new carbon emissions estimate using a given electricity consumption.
		/// </summary>
		/// <param name="requestDto">An <see cref="CarbonInterfaceElectricityEmissionsEstimateRequestDto"/>.</param>
		/// <returns><see cref="Task"/> with a result of type <see cref="IActionResult"/>.</returns>
		#endregion
		[HttpPost]
		[ProducesResponseType(typeof(CarbonInterfaceElectricityEmissionsEstimateResponseDto), 200)]
		public async Task<IActionResult> GetEstimate([Bind] CarbonInterfaceElectricityEmissionsEstimateRequestDto requestDto)
		{
			if (!ModelState.IsValid)
			{
				var errors = ModelState.Values
						.SelectMany(val => val.Errors)
						.Select(err => err.ErrorMessage);

				throw new BadHttpRequestException($"Invalid {nameof(CarbonInterfaceElectricityEmissionsEstimateRequestDto)} provided in {nameof(GetEstimate)} action method. Validation Errors: {errors}.");
			}

			var request = requestDto.ToCarbonInterfaceElectricityEmissionsEstimateRequest();
			var response = await _carbonInterfaceElectricityEmissionsEstimateService.GetElectricityEmissionsEstimateAsync(request);
			var electricityEstimateResponseDto = response.ToCarbonInterfaceElectricityEmissionsEstimateResponseDto();
			return Ok(electricityEstimateResponseDto);
		}
	}
}
