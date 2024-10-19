using EMission.Application.Interfaces.ModelInterfaces;

namespace EMission.Application.Plugins.Octopus.Models
{
	#region documentation
	/// <summary>
	/// An object that implements <see cref="IElectricityConsumptionRequest"/> that represents a request for Octopus Electricity Consumption.
	/// </summary>
	#endregion
	public class OctopusElectricityConsumptionRequest : IElectricityConsumptionRequest
	{
		#region documentation
		/// <summary>
		/// A <c>string</c> representing the Octopus customer's API key. 
		/// </summary>
		/// <remarks>
		/// Keys are available <see cref="https://octopus.energy/dashboard/new/accounts/personal-details/api-access">here</see>.
		/// </remarks>
		#endregion
		public required string APIKey { get; set; }

		#region documentation
		/// <summary>
		/// A <c>string</c> representing the Octopus customer's meter point access number (MPAN).
		/// </summary>
		/// <remarks>
		/// MPANs are available <see cref="https://octopus.energy/dashboard/new/accounts/personal-details/api-access">here</see>.
		/// </remarks>
		#endregion
		public string MPAN { get; set; } = string.Empty;

		#region documentation
		/// <summary>
		/// A <c>string</c> representing the Octopus customer's electricity meter serial number.
		/// </summary>
		/// <remarks>
		/// Meter serial numbers are available <see cref="https://octopus.energy/dashboard/new/accounts/personal-details/api-access">here</see>.
		/// </remarks>
		#endregion
		public required string SerialNumber { get; set; }

		#region documentation
		/// <summary>
		/// An <c>int</c> representing the number of days to include in the request for consumption values.
		/// </summary>
		#endregion
		public int Days { get; set; }
	}
}
