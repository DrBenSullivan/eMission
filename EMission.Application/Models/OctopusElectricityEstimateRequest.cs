namespace EMission.Application.Models
{
	public class OctopusElectricityEstimateRequest
	{
		public required string APIKey { get; set; }
		public int MPAN { get; set; }
		public required string SerialNumber { get; set; }
		public int Days { get; set; }
	}
}
