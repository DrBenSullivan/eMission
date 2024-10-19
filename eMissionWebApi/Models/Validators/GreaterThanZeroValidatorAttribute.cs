using System.ComponentModel.DataAnnotations;

namespace EMission.Api.Models.Validators
{
	#region documentation
	/// <summary>
	/// Specifies that a field is required and must be of type <c>double</c>, <c>int</c> or <c>decimal</c> with a value greater than 0.
	/// </summary>
	/// <exception cref="ApplicationException">Thrown on application start up if the ISO country codes file could not be found or read.</exception>
	#endregion
	public class GreaterThanZeroValidatorAttribute : ValidationAttribute
	{
		#region documentation
		/// <summary>
		/// Specifies that a field is required and must be of type <c>double</c>, <c>int</c> or <c>decimal</c> with a value greater than 0.
		/// <returns><c>true</c> if the value is valid; otherwise, <c>false</c>.</returns>
		#endregion

		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			if (value == null)
				return new ValidationResult($"A value for {validationContext.DisplayName} is required.");

			switch (value)
			{
				case double doubleValue when doubleValue > 0:
				case int intValue when intValue > 0:
				case decimal decimalValue when decimalValue > 0:
					return ValidationResult.Success;

				default:
					return new ValidationResult($"'{value}' is an invalid value for {validationContext.DisplayName}. It must be greater than zero.");
			}
		}
	}
}
