using System.Text.Json.Serialization;
using EMission.Application.Models;
using EMission.Domain.Enums;

namespace EMission.Infrastructure.Models
{
	public class ElectricityAPIResponseDto
	{
		[JsonPropertyName("country")]
		public string CountryCode { get; set; } = string.Empty;
		//[JsonPropertyName("state")]
		//public required string State { get; set; } = String.Empty;
		[JsonPropertyName("electricity_unit")]
		public string ElectricityUnit { get; set; } = string.Empty;
		[JsonPropertyName("electricity_value")]
		public double ElectricityValue { get; set; }
		[JsonPropertyName("estimated_at")]
		public DateTime EstimatedAt { get; set; }
		[JsonPropertyName("carbon_g")]
		public int CarbonEmissionsGrams { get; set; }
		//[JsonPropertyName("carbon_lb")]
		//public required double CarbonLb { get; set; }
		//[JsonPropertyName("carbon_kg")]
		//public required double CarbonKg { get; set; }
		//[JsonPropertyName("carbon_mt")]
		//public required double CarbonMt { get; set; }
	}

	public static class ElectricityEstimateApiResponseDtoExtensions
	{
		public static ElectricityEstimateResponse ToElectricityEstimateResponse(this ElectricityAPIResponseDto dto)
		{
			if (Enum.TryParse(typeof(ElectricalUnit), dto.ElectricityUnit, true, out var electricalUnit))
			{
				return new ElectricityEstimateResponse()
				{
					CountryCode = dto.CountryCode,
					ElectricityUnit = (ElectricalUnit)electricalUnit,
					ElectricityValue = dto.ElectricityValue,
					EstimatedAt = dto.EstimatedAt,
					CarbonEmissionsGrams = dto.CarbonEmissionsGrams
				};
			}
			
			throw new ArgumentException($"Value '{dto.ElectricityUnit}' is invalid for {nameof(ElectricityEstimateResponse.ElectricityUnit)}");
		}
	}
}