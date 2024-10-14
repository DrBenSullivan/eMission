using System.ComponentModel.DataAnnotations;

namespace eMissionWebApi.Core.Models
{
	public class ElectricityEstimate
	{
		[Key]
		public Guid Id { get; set; }

		[Required(ErrorMessage = "A country code must be provided.")]
		[StringLength(maximumLength:2, MinimumLength = 2, ErrorMessage = "The country code provided must be exactly 2 alphabetical characters.")]
		public string? Country { get; set; }

		[StringLength(maximumLength:2, MinimumLength = 2, ErrorMessage = "The state code provided must be exactly 2 alphabetical characters.")]
		public string? State { get; set; }

		[Range(0, double.MaxValue, ErrorMessage = "The electricity value provided must be a positive number.")]
		public double ElectricityValueKwh { get; set; }

		[Required]
		public DateTime EstimatedAt { get; set; }

		[Required]
		[Range(0, int.MaxValue, ErrorMessage = "The carbon emissions must be a positive number.")]
		public int CarbonEmissionsGrams { get; set; }
	}
}
