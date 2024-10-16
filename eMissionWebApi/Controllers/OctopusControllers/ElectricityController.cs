using Microsoft.AspNetCore.Mvc;

namespace EMission.Api.Controllers.OctopusControllers
{
	[Route("api/octopus/[controller]")]
	[ApiController]
	public class ElectricityController : ControllerBase
	{
		[HttpPost]
		public async Task<IActionResult> GetOctopusElectricityCarbonEmissionsEstimate()
		{

		}
	}
}
