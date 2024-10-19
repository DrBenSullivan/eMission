using EMission.Api.Models.DTOs;
using EMission.Application.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace EMission.Api.Controllers
{
	#region documentation
	/// <summary>
	/// A controller for requesting carbon emission estimates from electricity consumption.
	/// </summary>
	#endregion
	[Route("api/[controller]")]
	[ApiController]
	public class ElectricityEmissionsController : ControllerBase
	{
		#region private readonly fields
		private readonly IElectricityEmissionsEstimateService _electricityEmissionsEstimateService;
		#endregion

		#region constructor
		#region documentation
		/// <summary>
		/// Creates an instance of <see cref="ElectricityEmissionsController"/>
		/// </summary>
		/// <param name="electricityEmissionsEstimateService"></param>
		#endregion
		public ElectricityEmissionsController(IElectricityEmissionsEstimateService electricityEmissionsEstimateService)
		{
			_electricityEmissionsEstimateService = electricityEmissionsEstimateService;
		}
		#endregion

		#region documentation
		/// <summary>
		/// Requests a new carbon emissions estimate from a given electricity consumption.
		/// </summary>
		/// <param name="requestDto">An <see cref="ElectricityEmissionsEstimateRequestDto"/>.</param>
		/// <returns>A <see cref="Task"/> with a result of type <see cref="IActionResult"/>.</returns>
		#endregion
		[HttpPost]
		[Produces("application/json")]
		[ProducesResponseType(typeof(ElectricityEmissionsEstimateResponseDto), 200)]
		public async Task<IActionResult> GetEstimate([Bind] ElectricityEmissionsEstimateRequestDto requestDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var request = requestDto.ToElectricityEmissionsEstimateRequest();

			var response = await _electricityEmissionsEstimateService.GetElectricityEmissionsEstimateAsync(request);

			var electricityEstimateResponseDto = response.ToElectricityEmissionsEstimateResponseDto();

			return Ok(electricityEstimateResponseDto);
		}
	}
}
