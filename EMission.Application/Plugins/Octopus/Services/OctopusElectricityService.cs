using EMission.Application.Interfaces.ServiceInterfaces;
using EMission.Application.Models;
using EMission.Application.Plugins.Octopus.Interfaces.ExternalApiClientInterfaces;
using EMission.Application.Plugins.Octopus.Interfaces.ServiceInterfaces;
using EMission.Application.Plugins.Octopus.Models;
using EMission.Application.Services;

namespace EMission.Application.Plugins.Octopus.Services
{
	public class OctopusElectricityService : IOctopusElectricityService
	{
		#region private readonly fields
		private readonly IOctopusElectricityConsumptionApiClient _octopusApiClient;
		private readonly IElectricityEmissionsEstimateService _carbonEstimateService;
		#endregion

		#region constructor
		public OctopusElectricityService(IOctopusElectricityConsumptionApiClient octopusApiClient, IElectricityEmissionsEstimateService carbonInterfaceElectricityEmissionsEstimateService)
		{
			_octopusApiClient = octopusApiClient;
			_carbonEstimateService = carbonInterfaceElectricityEmissionsEstimateService;
		}
		#endregion

		#region documentation
		/// <inheritdoc/>
		#endregion
		public async Task<List<HourlyElectricityConsumptionKwh>> GetHourlyConsumptionAsync(OctopusElectricityConsumptionRequest request)
		{
			return await _octopusApiClient.GetHourlyElectricityConsumptionKwhAsync(request);
		}

		#region documentation
		/// <inheritdoc/>
		#endregion
		public async Task<List<HourlyElectricityEmissionsEstimate>> GetHourlyEmissionsEstimateAsync(OctopusElectricityConsumptionRequest request)
		{
			var hourlyConsumption = await GetHourlyConsumptionAsync(request);
			var emissionFactor = await _carbonEstimateService.GetElectricityEmissionFactorAsync("gb");

			return hourlyConsumption.Select(h => h.ToElectricityEmissionsEstimatePerHour(emissionFactor)).ToList();
		}

		#region documentation
		/// <inheritdoc/>
		#endregion
		public async Task<byte[]> GetHourlyConsumptionGraphAsync(OctopusElectricityConsumptionRequest request)
		{
			var hourlyConsumption = await GetHourlyConsumptionAsync(request);

			return GraphPlottingService.GetHourlyConsumptionGraph(hourlyConsumption);
		}

		#region documentation
		/// <inheritdoc/>
		#endregion
		public async Task<byte[]> GetHourlyEmissionsGraphAsync(OctopusElectricityConsumptionRequest request)
		{
			var hourlyEmissions = await GetHourlyEmissionsEstimateAsync(request);

			return GraphPlottingService.GetHourlyEmissionsGraph(hourlyEmissions);
		}
	}
}
