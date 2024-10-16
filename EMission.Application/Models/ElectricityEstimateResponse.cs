using EMission.Domain.Enums;

namespace EMission.Application.Models
{
	public class ElectricityEstimateResponse
	{
		public string CountryCode { get; set; } = string.Empty;
		public ElectricalUnit ElectricityUnit { get; set; }
		public double ElectricityValue { get; set; }
		public DateTime EstimatedAt { get; set; }
		public int CarbonEmissionsGrams { get; set; }
	}
}