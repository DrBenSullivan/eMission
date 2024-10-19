using EMission.Application.Models;
using EMission.Domain.Enums;

namespace EMission.Api.Models.DTOs
{
	#region documentation
	/// <summary>
	/// A <c>DTO</c> representing a response to an electricity carbon emissions estimate request.
	/// </summary>
	#endregion
	public class ElectricityEmissionsEstimateResponseDto
	{
		#region documentation
		/// <summary>
		/// A string representing the <see cref="ElectricalUnit"/> enum.
		/// </summary>
		#endregion
		public string ElectricalUnits { get; set; } = string.Empty;

		#region documentation
		/// <summary>
		/// A <c>double</c> representing the number of <c>ElectricalUnits</c> used.
		/// </summary>
		#endregion
		public double ElectricityValue { get; set; }

		#region documentation
		/// <summary>
		/// A two-letter ISO country code representing the country that the request is relevant to.
		/// <para>
		/// Acceptable codes available in <c>~/Emissions.Domain/Assets/IsoCountryCodes.json</c>.
		/// </para>
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
		/// An <c>int</c> representing the estimated Carbon Emissions in Grams (g).
		/// </summary>
		#endregion
		public int CarbonEmissionsGrams { get; set; }
	}

	#region documentation
	/// <summary>
	/// Extension class for <see cref="ElectricityEmissionsEstimateResponse" />.
	/// </summary>
	#endregion
	public static class ElectricityEstimateResponseExtensions
	{
		#region documentation
		/// <summary>
		/// Maps an <see cref="ElectricityEmissionsEstimateResponse" /> from the application layer into an <see cref="ElectricityEmissionsEstimateResponseDto"/> for API layer consumption.
		/// </summary>
		/// <param name="dto">The <see cref="ElectricityEmissionsEstimateResponse" /> to be mapped.</param>
		/// <returns>The mapped <see cref="ElectricityEmissionsEstimateResponseDto"/>.</returns>
		#endregion
		public static ElectricityEmissionsEstimateResponseDto ToElectricityEmissionsEstimateResponseDto(this ElectricityEmissionsEstimateResponse dto) => new()
		{
			ElectricalUnits = dto.ElectricityUnit.ToString(),
			ElectricityValue = dto.ElectricityValue,
			CountryCode = dto.CountryCode,
			EstimatedAt = dto.EstimatedAt,
			CarbonEmissionsGrams = dto.CarbonEmissionsGrams,

		};
	}
}
