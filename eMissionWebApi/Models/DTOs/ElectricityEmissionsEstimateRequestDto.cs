using System.ComponentModel;
using EMission.Api.Models.Validators;
using EMission.Application.Models;
using EMission.Domain.Enums;

namespace EMission.Api.Models.DTOs
{
	#region documentation
	/// <summary>
	/// A DTO representing a received request for an electricity carbon emissions estimate.
	/// </summary>
	#endregion
	public class ElectricityEmissionsEstimateRequestDto
	{
		#region documentation
		/// <summary>
		/// A string representing the <see cref="ElectricalUnit"/> <c>enum</c>.
		/// </summary>
		#endregion
		[DisplayName("'Electrical Units'")]
		[EnumValidator(typeof(ElectricalUnit))]
		public string ElectricalUnits { get; set; } = string.Empty;

		#region documentation
		/// <summary>
		/// A <c>double</c> representing the number of <c>ElectricalUnits</c> used.
		/// </summary>
		#endregion
		[DisplayName("'Total Units Used")]
		[RequiredValidator]
		[GreaterThanZeroValidator]
		public double ElectricityValue { get; set; }

		#region documentation
		/// <summary>
		/// A two-letter ISO country code representing the country that the request is relevant to.
		/// <para>
		/// Acceptable codes available in <c>~/Emissions.Domain/Assets/IsoCountryCodes.json</c>.
		/// </para>
		/// </summary>
		#endregion
		[DisplayName("'Country Code'")]
		[RequiredValidator]
		[CountryCodeValidator]
		public string CountryCode { get; set; } = string.Empty;
	}

	#region documentation
	/// <summary>
	/// Extension class for <see cref="ElectricityEmissionsEstimateRequestDto" />.
	/// </summary>
	#endregion
	public static class ElectricityEstimateRequestDtoExtensions
	{
		#region documentation
		/// <summary>
		/// Maps an <see cref="ElectricityEmissionsEstimateRequestDto" /> to an <see cref="ElectricityEmissionsEstimateRequest"/> for consumption by the application layer.
		/// </summary>
		/// <param name="dto">The <c>DTO</c> to be transformed.</param>
		/// <returns>The mapped <see cref="ElectricityEmissionsEstimateRequest"/>.</returns>
		#endregion
		public static ElectricityEmissionsEstimateRequest ToElectricityEmissionsEstimateRequest(this ElectricityEmissionsEstimateRequestDto dto) => new()
		{
			ElectricalUnits = (ElectricalUnit)Enum.Parse(typeof(ElectricalUnit), dto.ElectricalUnits, true),
			TotalUnits = dto.ElectricityValue,
			CountryCode = dto.CountryCode
		};
	}
}
