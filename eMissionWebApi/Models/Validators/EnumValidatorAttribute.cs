using System.ComponentModel.DataAnnotations;

namespace EMission.Api.Models.Validators
{
	#region documentation
	/// <summary>
	/// Specifies that a field is required and exists as a value in the given enum.
	/// </summary>
	/// <exception cref="ArgumentException">Thrown if the provided object is not an enum.</exception>
	#endregion
	public class EnumValidatorAttribute : ValidationAttribute
	{
		private readonly Type _enumType;

		#region documentation
		/// <summary>
		/// Creates a new instance of the <see cref="EnumValidatorAttribute"/> class.
		/// </summary>
		/// <param name="enumType">The type of enum expected.</param>
		/// <exception cref="ArgumentException">Thrown if the object provided is not an enum.</exception>
		#endregion
		public EnumValidatorAttribute(Type enumType)
		{
			if (!enumType.IsEnum)
			{
				throw new ArgumentException($"The type of {enumType.GetType} is invalid for {nameof(enumType)}. It must be an enum.");
			}

			_enumType = enumType;
		}

		#region documentation
		/// <inheritdoc/>
		#endregion
		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			if (value == null)
			{
				return new ValidationResult($"A value for {validationContext.DisplayName} is required.");
			}

			if (Enum.TryParse(_enumType, value.ToString(), true, out var enumValue))
			{
				if (Enum.IsDefined(_enumType, enumValue))
				{
					return ValidationResult.Success;
				}
			}

			return new ValidationResult($"'{value}' is an invalid value for {validationContext.DisplayName}. Valid values are: '{string.Join("', ", Enum.GetNames(_enumType))}'.");
		}
	}
}
