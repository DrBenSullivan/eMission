using System.Text.Json.Serialization;
using EMission.Application.Models;
using EMission.Domain.Enums;
using EMission.Infrastructure.ExternalApiClients;

namespace EMission.Infrastructure.Models
{
	#region documentation
	/// <summary>
	/// An object representing the response from the <see cref="CarbonInterfaceExternalApiClient"/> that assists in its deserialization.
	/// </summary>
	#endregion
	public class ElectricityEmissionsEstimateApiResponseDto
	{
		#region documentation
		/// <summary>
		/// A <c>string</c> representing the 2-letter ISO Country Code that the emissions estimate is relevant to.
		/// </summary>
		#endregion
		[JsonPropertyName("country")]
		public string CountryCode { get; set; } = string.Empty;

		#region documentation
		/// <summary>
		/// A <c>string</c> representing the electricity unit used.
		/// </summary>
		#endregion
		[JsonPropertyName("electricity_unit")]
		public string ElectricityUnit { get; set; } = string.Empty;

		#region documentation
		/// <summary>
		/// A <c>double</c> representing the number of <c>ElectricityUnit</c>s consumed.
		/// </summary>
		#endregion
		[JsonPropertyName("electricity_value")]
		public double ElectricityValue { get; set; }

		#region documentation
		/// <summary>
		/// A <see cref="DateTime" /> representing when the request was processed.
		/// </summary>
		#endregion
		[JsonPropertyName("estimated_at")]
		public DateTime EstimatedAt { get; set; }

		#region documentation
		/// <summary>
		/// An <c>int</c> representing the estimated carbon emissions in grams from the electricity consumed.
		/// </summary>
		#endregion
		[JsonPropertyName("carbon_g")]
		public int CarbonEmissionsGrams { get; set; }
	}

	#region documentation
	/// <summary>
	/// Extension class for <see cref="ElectricityEmissionsEstimateApiResponseDto" />.
	/// </summary>
	#endregion
	public static class ElectricityEstimateApiResponseDtoExtensions
	{
		#region
		/// <summary>
		/// Maps an <see cref="ElectricityEmissionsEstimateApiResponseDto"/> to an <see cref="ElectricityEmissionsEstimateResponse"/>.
		/// </summary>
		/// <param name="dto">The <c>DTO</c> to be mapped.</param>
		/// <returns>The mapped <see cref="ElectricityEmissionsEstimateResponse"/>.</returns>
		/// <exception cref="ArgumentException">Thrown if the <see cref="ElectricityEmissionsEstimateApiResponseDto" /> cannot be mapped to a <see cref="ElectricityEmissionsEstimateResponse"/>.</exception>
		#endregion
		public static ElectricityEmissionsEstimateResponse ToElectricityEmissionsEstimateResponse(this ElectricityEmissionsEstimateApiResponseDto dto)
		{
			if (Enum.TryParse(typeof(ElectricalUnit), dto.ElectricityUnit, true, out var electricalUnit))
			{
				return new ElectricityEmissionsEstimateResponse()
				{
					CountryCode = dto.CountryCode,
					ElectricityUnit = (ElectricalUnit)electricalUnit,
					ElectricityValue = dto.ElectricityValue,
					EstimatedAt = dto.EstimatedAt,
					CarbonEmissionsGrams = dto.CarbonEmissionsGrams
				};
			}

			throw new ArgumentException($"Value '{dto.ElectricityUnit}' is invalid for {nameof(ElectricityEmissionsEstimateResponse.ElectricityUnit)}");
		}
	}
}