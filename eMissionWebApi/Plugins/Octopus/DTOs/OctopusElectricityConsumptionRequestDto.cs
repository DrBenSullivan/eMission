using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EMission.Api.Interfaces;
using EMission.Api.Models.Validators;
using EMission.Application.Plugins.Octopus.Models;

namespace EMission.Api.Plugins.Octopus.DTOs
{
	#region documentation
	/// <summary>
	/// A <c>DTO</c> representing a received request for an Octopus Energy electricity carbon emissions estimate.
	/// </summary>
	/// <remarks>
	/// <b>DISCLAIMER</b>: Does not represent actual carbon emissions.
	/// <para>
	/// See <see href="https://octopus.energy/renewables/">Octopus website</see> for more information.
	/// </para>
	/// </remarks>
	#endregion
	public class OctopusElectricityConsumptionRequestDto : IElectricityConsumptionRequestDto
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
		public string APIKey { get; set; } = string.Empty;

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
		[RegularExpression("^[0-9]{13}$")]
		public string MPAN { get; set; } = string.Empty;

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
		public string SerialNumber { get; set; } = string.Empty;

		#region documentation
		/// <summary>
		/// Optional <c>int</c> representing the number of days to process.
		/// </summary>
		#endregion
		[DisplayName("'Number of Days'")]
		[Range(1, 365)]
		public int Days { get; set; }
	}

	#region documentation
	/// <summary>
	/// Extension method class for <see cref="OctopusElectricityConsumptionRequestDto" />.
	/// </summary>
	#endregion
	public static class OctopusElectricityEstimateRequestDtoExtensions
	{
		#region documentation
		/// <summary>
		/// Transforms an <see cref="OctopusElectricityConsumptionRequestDto" /> into an <see cref="OctopusElectricityConsumptionRequest"/> for consumption by the application layer.
		/// </summary>
		/// <param name="dto">The <see cref="OctopusElectricityConsumptionRequestDto" /> to be transformed.</param>
		/// <returns>The generated <see cref="OctopusElectricityConsumptionRequest"/>.</returns>
		#endregion
		internal static OctopusElectricityConsumptionRequest ToOctopusElectricityConsumptionRequest(this OctopusElectricityConsumptionRequestDto dto) => new()
		{
			APIKey = dto.APIKey,
			MPAN = dto.MPAN,
			SerialNumber = dto.SerialNumber,
			Days = dto.Days
		};
	}
}
