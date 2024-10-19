using EMission.Application.Interfaces.ServiceInterfaces;
using EMission.Application.Plugins.Octopus.Models;
using EMission.Application.Plugins.Octopus.Services;

namespace EMission.Application.Plugins.Octopus.Interfaces.ServiceInterfaces
{
	#region documentation
	/// <summary>
	/// Interface implemented to enable dependency injection of <see cref="OctopusElectricityService"/>.
	/// </summary>
	#endregion
	public interface IOctopusElectricityService : IElectricityConsumptionService<OctopusElectricityConsumptionRequest>
	{
	}
}
