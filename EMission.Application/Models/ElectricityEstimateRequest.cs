using EMission.Domain.Enums;

namespace EMission.Application.Models
{
	public class ElectricityEstimateRequest
	{
		public ElectricalUnit ElectricalUnits { get; set; }
		public double TotalUnits { get; set; }
		public string CountryCode { get; set; } = string.Empty;
	}
}