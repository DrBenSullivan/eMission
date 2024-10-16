using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EMission.Api.Models.Validators;

namespace EMission.Api.Models.DTOs
{
	#region documentation
	/// <summary>
	/// A DTO representing a received request for an Octopus Electricity Carbon Emissions estimate.
	/// </summary>
	/// <remarks>
	/// <b>DISCLAIMER</b>: Does not represent actual carbon emissions.
	/// <para>
	/// See <see href="https://octopus.energy/renewables/">Octopus website</see> for more information.
	/// </para>
	/// </remarks>
	#endregion
	public class OctopusElectricityEstimateRequestDto
	{
		#region documentation
		/// <summary>
		/// Octopus Energy API Key.
		/// </summary>
		/// <remarks>
		/// Obtainable by Octopus customers <see href="https://octopus.energy/dashboard/new/accounts/personal-details/api-access">here</see>.
		/// </remarks>
		#endregion
		[DisplayName("'Octopus API Key'")]
		[RequiredValidator]
		public string? APIKey { get; set;} = string.Empty;

		#region documentation
		/// <summary>
		/// Electricity Meter Point Administration Number (MPAN).
		/// </summary>
		/// <remarks>
		/// Obtainable by Octopus customers <see href="https://octopus.energy/dashboard/new/accounts/personal-details/api-access">here</see>.
		/// </remarks>
		#endregion
		[DisplayName("'Meter Point Administration Number'")]
		[RequiredValidator]
		[RegularExpression("^[0-9]{9}$", ErrorMessage = "")]
		public string? MPAN { get; set; }  = string.Empty;

		#region documentation
		/// <summary>
		/// Electricity Meter Point Serial Number.
		/// </summary>
		/// <remarks>
		/// Obtainable by Octopus customers <see href="https://octopus.energy/dashboard/new/accounts/personal-details/api-access">here</see>.
		/// </remarks>
		#endregion
		[DisplayName("'Octopus Meter Serial Number'")]
		[RequiredValidator]
		[RegularExpression("^[0-9]{2}[a-zA-Z]{1}[0-9]{7}$")]
		public string? SerialNumber { get; set; } = string.Empty;

		#region documentation
		/// <summary>
		/// Optional <c>int</c> representing the number of days to process.
		/// </summary>
		#endregion
		[DisplayName("'Number of Days'")]
		[Range(1, 365)]
		public int? Days { get; set; }
	}
}
