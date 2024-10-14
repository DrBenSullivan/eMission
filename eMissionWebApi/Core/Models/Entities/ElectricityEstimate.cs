using System.ComponentModel.DataAnnotations;
using eMissionWebApi.Core.Models.Validators;

namespace eMissionWebApi.Core.Models.Entities
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
		[CountryCodeValidator]
		public string? CountryCode { get; set; }

		#region documentation
		/// <summary>
		/// A <c>double</c> representing the electricity consumption in kilowatt-hours (kWh).
		/// </summary>
		#endregion
		[Required(ErrorMessage = $"A value for {nameof(ElectricityValueKwh)} is required.")]
		[GreaterThanZeroValidator]
		public double ElectricityValueKwh { get; set; }

		#region documentation
		/// <summary>
		/// The date the estimate was requested at.
		/// </summary>
		#endregion
		[Required(ErrorMessage = $"A value for {nameof(EstimatedAt)} is required.")]
		public DateTime EstimatedAt { get; set; }

		#region documentation
		/// <summary>
		/// An <c>int</c> representing the estimated carbon emissions in grams (g).
		/// </summary>
		#endregion
		[Required(ErrorMessage = $"A value for {nameof(CarbonEmissionsGrams)} is required.")]
		[GreaterThanZeroValidator]
		public int CarbonEmissionsGrams { get; set; }
	}
}
