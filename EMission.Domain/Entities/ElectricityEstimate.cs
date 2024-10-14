using System.ComponentModel.DataAnnotations;

namespace EMission.Domain.Entities
{
	#region documentation
	/// <summary>
	/// A core entity representing an electricity request.
	/// </summary>
	#endregion
	public class ElectricityEstimate
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
		/// An two-letter ISO country code representing the country the estimate is pertinent to.
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
		public double ElectricityValueKwh { get; set; }

		#region documentation
		/// <summary>
		/// The date the estimate was requested at.
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
