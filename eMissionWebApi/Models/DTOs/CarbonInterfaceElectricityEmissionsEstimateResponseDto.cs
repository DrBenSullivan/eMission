using EMission.Application.Models;
using EMission.Domain.Enums;

namespace EMission.Api.Models.DTOs
{
	#region documentation
	/// <summary>
	/// A DTO representing a dto to a request for an electricity carbon emissions estimate.
	/// </summary>
	#endregion
	public class CarbonInterfaceElectricityEmissionsEstimateResponseDto
	{
		#region documentation
		/// <summary>
		/// A string representing the <see cref="ElectricalUnit"/> enum.
		/// </summary>
		#endregion
		public string ElectricalUnits { get; set; } = string.Empty;

		#region documentation
		/// <summary>
		/// A <c>double</c> representing the number of <see cref="ElectricalUnits"/> used.
		/// </summary>
		#endregion
		public double ElectricityValue { get; set; }

		#region documentation
		/// <summary>
		/// A two-letter ISO country code representing the country that the request is pertinent to.
		/// </summary>
		#endregion
		public string CountryCode { get; set; } = string.Empty;

		#region documentation
		/// <summary>
		/// The <see cref="DateTime"/> the request was processed at.
		/// </summary>
		#endregion
		public DateTime EstimatedAt { get; set; }

		#region documentation
		/// <summary>
		/// An <c>int</c> representing the estimated Carbon emissions in grams (g).
		/// </summary>
		#endregion
		public int CarbonEmissionsGrams { get; set; }
	}

	#region documentation
	/// <summary>
	/// Extension class for <see cref="CarbonInterfaceElectricityEmissionsEstimateResponse" />.
	/// </summary>
	#endregion
	public static class ElectricityEstimateResponseExtensions
	{
		#region documentation
		/// <summary>
		/// Transforms an <see cref="CarbonInterfaceElectricityEmissionsEstimateResponse" /> from the application layer into an <see cref="CarbonInterfaceElectricityEmissionsEstimateResponseDto"/> for Web API use.
		/// </summary>
		/// <param name="dto">The <see cref="CarbonInterfaceElectricityEmissionsEstimateResponse" /> to be transformed.</param>
		/// <returns>The generated <see cref="CarbonInterfaceElectricityEmissionsEstimateResponseDto"/>.</returns>
		#endregion
		public static CarbonInterfaceElectricityEmissionsEstimateResponseDto ToCarbonInterfaceElectricityEmissionsEstimateResponseDto(this CarbonInterfaceElectricityEmissionsEstimateResponse dto) => new()
		{
			ElectricalUnits = dto.ElectricityUnit.ToString(),
			ElectricityValue = dto.ElectricityValue,
			CountryCode = dto.CountryCode,
			EstimatedAt = dto.EstimatedAt,
			CarbonEmissionsGrams = dto.CarbonEmissionsGrams,

		};
	}
}
