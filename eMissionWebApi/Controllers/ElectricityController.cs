using EMission.Api.Models.DTOs;
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
        private readonly string _route;
        private readonly HttpClient _httpClient;
        #endregion

        #region constructor
        /// <summary>
        /// Creates an instance of <see cref="ElectricityController" /> class.
        /// </summary>
        /// <param name="httpClientFactory">The injected <see cref="IHttpClientFactory" />.</param>
        public ElectricityController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("CarbonInterfaceApiClient");
            _route = "estimates";
        }
        #endregion

        #region documentation
        /// <summary>
        /// An action method for requesting a new carbon emissions estimate from a given electricity consumption.
        /// </summary>
        /// <param name="request">An <see cref="ElectricityEstimateRequest"/>.</param>
        /// <returns><see cref="Task"/> with a result of type <see cref="IActionResult"/>.</returns>
        #endregion
        [HttpPost]
        [Route("/")]
        public async Task<IActionResult> GetEstimate([Bind] ElectricityEstimateRequest request)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                        .SelectMany(val => val.Errors)
                        .Select(err => err.ErrorMessage);

                return BadRequest(errors);
            }

            var httpContent = request.ToCarbonInterfaceRequestContent();
            var response = await _httpClient.PostAsync(_route, httpContent);

            if (response.IsSuccessStatusCode)
            {
                var responseData = response.Content.ReadAsStringAsync().Result;
                return Ok(responseData);
            }
            else
            {
                return StatusCode((int)response.StatusCode, response.Content.ReadAsStringAsync());
            }
        }
    }
}
