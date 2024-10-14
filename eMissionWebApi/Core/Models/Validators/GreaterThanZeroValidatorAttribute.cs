using System.ComponentModel.DataAnnotations;

namespace eMissionWebApi.Core.Models.Validators
{
	#region documentation
	/// <summary>
	/// Validates that the value of the Property decorated with this attribute is not a <c>null</c> or empty <c>string</c>,
	/// contains exactly 2 alphabetic characters, and exists within the list of ISO country codes from <c>IsoCountryCodes.json</c>.
	/// </summary>
	/// <exception cref="ApplicationException">Thrown on application start up if the ISO country codes file could not be found or read.</exception>
	#endregion
	public class GreaterThanZeroValidatorAttribute : ValidationAttribute
	{
		#region documentation
		/// <inheritdoc/>
		#endregion
		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			switch (value)
			{
				case double doubleValue when doubleValue > 0:
				case int intValue when intValue > 0:
				case decimal decimalValue when decimalValue > 0:
					return ValidationResult.Success;

				default: return new ValidationResult($"'{value}' is not a valid value for {validationContext.DisplayName}. It must be greater than zero.");
			}
		}
	}
}
