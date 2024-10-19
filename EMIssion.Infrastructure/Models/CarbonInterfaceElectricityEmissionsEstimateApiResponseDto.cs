using System.Text.Json.Serialization;
using EMission.Application.Models;
using EMission.Domain.Enums;

namespace EMission.Infrastructure.Models
{
	public class CarbonInterfaceElectricityEmissionsEstimateApiResponseDto
	{
		[JsonPropertyName("country")]
		public string CountryCode { get; set; } = string.Empty;
		[JsonPropertyName("electricity_unit")]
		public string ElectricityUnit { get; set; } = string.Empty;
		[JsonPropertyName("electricity_value")]
		public double ElectricityValue { get; set; }
		[JsonPropertyName("estimated_at")]
		public DateTime EstimatedAt { get; set; }
		[JsonPropertyName("carbon_g")]
		public int CarbonEmissionsGrams { get; set; }
	}

	public static class ElectricityEstimateApiResponseDtoExtensions
	{
		public static ElectricityEmissionsEstimateResponse ToCarbonInterfaceElectricityEmissionsEstimateResponse(this CarbonInterfaceElectricityEmissionsEstimateApiResponseDto dto)
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