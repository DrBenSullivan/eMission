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
	public class ElectricityEstimateRequestDto
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
	/// Extension class for <see cref="ElectricityEstimateRequestDto" />.
	/// </summary>
	#endregion
	public static class ElectricityEstimateRequestDtoExtensions
	{
		#region documentation
		/// <summary>
		/// Transforms an <see cref="ElectricityEstimateRequestDto" /> into an <see cref="ElectricityEstimateRequest"/> for consumption by the application layer.
		/// </summary>
		/// <param name="requestDto">The <see cref="ElectricityEstimateRequestDto" /> to be transformed.</param>
		/// <returns>The generated <see cref="ElectricityEstimateRequest"/>.</returns>
		#endregion
		public static ElectricityEstimateRequest ToElectricityEstimateRequest(this ElectricityEstimateRequestDto requestDto) => new()
		{
			ElectricalUnits = (ElectricalUnit)Enum.Parse(typeof(ElectricalUnit), requestDto.ElectricalUnits, true),
			TotalUnits = requestDto.ElectricityValue,
			CountryCode = requestDto.CountryCode
		};
	}
}
