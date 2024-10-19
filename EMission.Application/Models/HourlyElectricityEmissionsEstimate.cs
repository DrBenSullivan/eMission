namespace EMission.Application.Models
{
	#region documentation
	/// <summary>
	/// An object representing Carbon Dioxide emissions in grams over a given one-hour period.
	/// </summary>
	#endregion
	public class HourlyElectricityEmissionsEstimate
	{
		public double CarbonEmissionsGrams { get; set; }
		public DateTime Hour { get; set; }
	}

	#region documentation
	/// <summary>
	/// Extension class for HourlyElectricityConsumptionKwh.
	/// </summary>
	#endregion
	public static class HourlyElectricityConsumptionKilowattsExtensions
	{
		#region documentation
		/// <summary>
		/// Extension method for converting a <see cref="HourlyElectricityConsumptionKwh"/> into a <see cref="HourlyElectricityEmissionsEstimate"/> given an <c>ElectricityEmissionFactor</c>.
		/// </summary>
		/// <param name="consumption">The <see cref="HourlyElectricityConsumptionKwh"/> to be converted.</param>
		/// <param name="factor">The <c>ElectricityEmissionFactor</c>.</param>
		/// <returns>A <see cref="HourlyElectricityEmissionsEstimate"/>.</returns>
		#endregion
		public static HourlyElectricityEmissionsEstimate ToElectricityEmissionsEstimatePerHour(this HourlyElectricityConsumptionKwh consumption, double factor) => new()
		{
			CarbonEmissionsGrams = Math.Round(factor * consumption.KilowattHours, 2),
			Hour = consumption.Hour
		};
	}
}
