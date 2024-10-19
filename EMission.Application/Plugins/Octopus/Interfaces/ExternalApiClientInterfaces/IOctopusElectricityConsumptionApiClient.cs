using EMission.Application.Interfaces.ExternalApiClientInterfaces;
using EMission.Application.Plugins.Octopus.Models;

namespace EMission.Application.Plugins.Octopus.Interfaces.ExternalApiClientInterfaces
{
	#region documentation
	/// <summary>
	/// Interface implemented to enable dependency injection of <c>~/EMission.Infrastructure/Plugins/Octopus/ExternalApiClients/OctopusElectricityConsumptionApiClient</c>.
	/// </summary>
	#endregion

	public interface IOctopusElectricityConsumptionApiClient : IElectricityConsumptionApiClient<OctopusElectricityConsumptionRequest>
	{
	}
}
