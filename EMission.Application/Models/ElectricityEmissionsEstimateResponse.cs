using EMission.Domain.Enums;

namespace EMission.Application.Models
{
	#region documentation
	/// <summary>
	/// An object used to respond to a carbon emission estimate request.
	/// </summary>
	#endregion	
	public class ElectricityEmissionsEstimateResponse
	{
		#region documentation
		/// <summary>
		/// A string representing the 2-letter ISO Country Code that the request is relevant to.
		/// <para>
		/// Acceptable codes available in <c>~/Emissions.Domain/Assets/IsoCountryCodes.json</c>.
		/// </para>
		/// </summary>
		#endregion
		public string CountryCode { get; set; } = string.Empty;

		#region documentation
		/// <summary>
		/// An enum of type <see cref="ElectricalUnit"/> representing the unit used.
		/// </summary>
		#endregion
		public ElectricalUnit ElectricityUnit { get; set; }

		#region documentation
		/// <summary>
		/// A <c>double</c> representing the number of <c>ElectricalUnits</c> consumed.
		/// </summary>
		#endregion

		public double ElectricityValue { get; set; }

		#region documentation
		/// <summary>
		/// A <c>DateTime</c> representing when the request was processed.
		/// </summary>
		#endregion

		public DateTime EstimatedAt { get; set; }

		#region documentation
		/// <summary>
		/// A <c>int</c> representing the estimated number of grams of Carbon Emissions produced by the electricity consumed.
		/// </summary>
		#endregion

		public int CarbonEmissionsGrams { get; set; }
	}
}