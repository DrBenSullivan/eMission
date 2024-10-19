using EMission.Application.Interfaces.ModelInterfaces;

namespace EMission.Application.Plugins.Octopus.Models
{
	public class OctopusElectricityConsumptionRequest : IElectricityConsumptionRequest
	{
		public required string APIKey { get; set; }
		public string MPAN { get; set; } = string.Empty;
		public required string SerialNumber { get; set; }
		public int Days { get; set; }
	}
}
