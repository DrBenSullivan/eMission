namespace EMission.Application.Models
{
	#region documentation
	/// <summary>
	/// A object representing the number of <c>KilowattHours</c> consumed during a given hour.
	/// </summary>
	#endregion

	public class HourlyElectricityConsumptionKwh
	{
		#region documentation
		/// <summary>
		/// A <c>double</c> representing the number of <c>KilowattHours</c> consumed.
		/// </summary>
		#endregion
		public double KilowattHours { get; set; }

		#region documentation
		/// <summary>
		/// A <c>DateTime</c> representing the hour of the consumption.
		/// </summary>
		#endregion
		public DateTime Hour { get; set; }
	}
}
