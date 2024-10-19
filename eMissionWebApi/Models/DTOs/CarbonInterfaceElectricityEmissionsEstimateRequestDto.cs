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
	public class CarbonInterfaceElectricityEmissionsEstimateRequestDto
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
		/// A <c>double</c> representing the number of <see cref="ElectricalUnits"/> used.
		/// </summary>
		#endregion
		[DisplayName("'Total Units Used")]
		[RequiredValidator]
		[GreaterThanZeroValidator]
		public double ElectricityValue { get; set; }

		#region documentation
		/// <summary>
		/// A two-letter ISO country code representing the country that the request is pertinent to.
		/// </summary>
		#endregion
		[DisplayName("'Country Code'")]
		[RequiredValidator]
		[CountryCodeValidator]
		public string CountryCode { get; set; } = string.Empty;
	}

	#region documentation
	/// <summary>
	/// Extension class for <see cref="CarbonInterfaceElectricityEmissionsEstimateRequestDto" />.
	/// </summary>
	#endregion
	public static class ElectricityEstimateRequestDtoExtensions
	{
		#region documentation
		/// <summary>
		/// Transforms an <see cref="CarbonInterfaceElectricityEmissionsEstimateRequestDto" /> into an <see cref="ElectricityEmissionsEstimateRequest"/> for consumption by the application layer.
		/// </summary>
		/// <param name="dto">The <see cref="CarbonInterfaceElectricityEmissionsEstimateRequestDto" /> to be transformed.</param>
		/// <returns>The generated <see cref="ElectricityEmissionsEstimateRequest"/>.</returns>
		#endregion
		public static ElectricityEmissionsEstimateRequest ToCarbonInterfaceElectricityEmissionsEstimateRequest(this CarbonInterfaceElectricityEmissionsEstimateRequestDto dto) => new()
		{
			ElectricalUnits = (ElectricalUnit)Enum.Parse(typeof(ElectricalUnit), dto.ElectricalUnits, true),
			TotalUnits = dto.ElectricityValue,
			CountryCode = dto.CountryCode
		};
	}
}
