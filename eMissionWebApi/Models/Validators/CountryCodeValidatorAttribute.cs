using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace EMission.Api.Models.Validators
{
	#region documentation
	/// <summary>
	/// Specifies that a field must be a valid ISO country code.
	/// <para>
	/// This is a 3-part process: A <c>NullOrEmpty</c> check, a check that the variable is 2 alphabetic characters, 
	/// and exists within the list of ISO country codes in <c>~/EMission.Domain/Assets/IsoCountryCodes.json</c>.
	/// </para>
	/// </summary>
	/// <exception cref="ApplicationException">Thrown if <c>~/EMission.Domain/Assets/IsoCountryCodes.json</c> cannot be found or read on application startup.</exception>
	#endregion
	public class CountryCodeValidatorAttribute : ValidationAttribute
	{
		private static readonly Dictionary<string, string> _countryCodes;

		static CountryCodeValidatorAttribute()
		{
			string jsonFilePath = Path.Combine(AppContext.BaseDirectory, "Core", "Assets", "IsoCountryCodes.json");
			try
			{
				_countryCodes = JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText(jsonFilePath))
								?? throw new ApplicationException($"Valid Country Codes could not be loaded from {jsonFilePath}.");
			}
			catch (Exception ex)
			{
				throw new ApplicationException($"Error loading country codes from JSON file at {jsonFilePath}", ex);
			}
		}

		#region documentation
		/// <summary>
		/// Specifies that a field must be a valid ISO country code.
		/// <para>
		/// This is a 3-part process: A <c>NullOrEmpty</c> check, a check that the variable is 2 alphabetic characters, 
		/// and exists within the list of ISO country codes in <c>~/EMission.Domain/Assets/IsoCountryCodes.json</c>.
		/// </para>
		/// </summary>
		/// <returns><c>true</c> if the value is valid; otherwise, <c>false</c>.</returns>
		#endregion
		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			if (value == null)
			{
				return new ValidationResult($"A value for {validationContext.DisplayName} is required.");
			}

			if (value is not string stringValue)
			{
				return new ValidationResult($"{value.GetType}' is an invalid value for {validationContext.DisplayName}. It must be a string.");
			}

			if (string.IsNullOrEmpty(stringValue))
			{
				return new ValidationResult($"A value for {validationContext.DisplayName} is required.");
			}

			stringValue = stringValue.ToUpper();

			var regex = new Regex("^[A-Z]{2}$");
			if (!regex.IsMatch(stringValue))
			{
				return new ValidationResult($"'{value}' is an invalid value for {validationContext.DisplayName}. It must be exactly two alphabetical characters.");
			}

			if (!_countryCodes.ContainsKey(stringValue))
			{
				return new ValidationResult($"'{value}' is an invalid value for {validationContext.DisplayName}. It must be a recognised ISO country code.");
			}

			return ValidationResult.Success;
		}
	}
}
