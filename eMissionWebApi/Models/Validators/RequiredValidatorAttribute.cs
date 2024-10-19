using System.ComponentModel.DataAnnotations;

namespace EMission.Api.Models.Validators
{
	#region documentation
	/// <summary>
	/// Specifies that a field is required.
	/// </summary>
	#endregion
	public class RequiredValidatorAttribute : ValidationAttribute
	{

		#region documentation
		/// <summary>
		/// Specifies that a field is required.
		/// </summary>
		/// <returns><c>true</c> if the value is valid; otherwise, <c>false</c>.</returns>
		#endregion
		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			if (value == null)
			{
				return new ValidationResult($"A value is required for '{validationContext.DisplayName}'.");
			}

			if (value is string stringValue)
			{
				if (string.IsNullOrEmpty(stringValue))
				{
					return new ValidationResult($"A non-empty value is required for '{validationContext.DisplayName}'.");
				}
			}

			return ValidationResult.Success;
		}
	}
}
