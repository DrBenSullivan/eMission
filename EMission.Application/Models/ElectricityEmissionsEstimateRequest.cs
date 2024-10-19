using EMission.Domain.Enums;

namespace EMission.Application.Models
{
	#region documentation
	/// <summary>
	/// An object used to request a carbon emission estimate based on electricity consumptino and country.
	/// </summary>
	#endregion
	public class ElectricityEmissionsEstimateRequest
	{
		#region documentation
		/// <summary>
		/// An enum of type <see cref="ElectricalUnit"/> representing the unit used.
		/// </summary>
		#endregion
		public ElectricalUnit ElectricalUnits { get; set; }

		#region documentation
		/// <summary>
		/// A <c>double</c> representing the number of <c>ElectricalUnits</c> consumed.
		/// </summary>
		#endregion
		public double TotalUnits { get; set; }

		#region documentation
		/// <summary>
		/// A string representing the 2-letter ISO Country Code that the request is relevant to.
		/// <para>
		/// Acceptable codes available in <c>~/Emissions.Domain/Assets/IsoCountryCodes.json</c>.
		/// </para>
		/// </summary>
		#endregion
		public string CountryCode { get; set; } = string.Empty;
	}
}