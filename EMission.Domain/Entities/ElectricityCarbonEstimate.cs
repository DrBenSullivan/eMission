namespace EMission.Domain.Entities
{
	#region documentation
	/// <summary>
	/// A core entity representing an electricity request.
	/// </summary>
	#endregion
	public class ElectricityCarbonEstimate
	{
		public Guid Id { get; set; }
		public string? CountryCode { get; set; }
		public double ElectricityConsumptionKwh { get; set; }
		public DateTime EstimatedAt { get; set; }
		public int CarbonEmissionsGrams { get; set; }
	}
}
