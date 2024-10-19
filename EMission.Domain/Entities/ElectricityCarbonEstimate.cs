using System.ComponentModel.DataAnnotations;

namespace EMission.Domain.Entities
{
	#region documentation
	/// <summary>
	/// A core entity representing an electricity request.
	/// </summary>
	#endregion
	public class ElectricityCarbonEstimate
	{
		#region documentation
		/// <summary>
		/// Guid of the estimate.
		/// </summary>
		#endregion
		[Key]
		public Guid Id { get; set; }

		#region documentation
		/// <summary>
		/// A string representing the 2-letter ISO Country Code that the request is relevant to.
		/// <para>
		/// Acceptable codes available in <c>~/Emissions.Domain/Assets/IsoCountryCodes.json</c>.
		/// </para>
		/// </summary>
		#endregion
		[Required]
		public string? CountryCode { get; set; }

		#region documentation
		/// <summary>
		/// A <c>double</c> representing the electricity consumption in kilowatt-hours (kWh).
		/// </summary>
		#endregion
		[Required]
		public double ElectricityConsumptionKwh { get; set; }

		#region documentation
		/// <summary>
		/// A <see cref="DateTime"/> representing when the request was processed.
		/// </summary>
		#endregion
		[Required]
		public DateTime EstimatedAt { get; set; }

		#region documentation
		/// <summary>
		/// An <c>int</c> representing the estimated carbon emissions in grams (g).
		/// </summary>
		#endregion
		[Required]
		public int CarbonEmissionsGrams { get; set; }
	}
}
