using EMission.Application.Models;
using EMission.Infrastructure.Plugins.Octopus.ExternalApiClients;
using Newtonsoft.Json;

namespace EMission.Infrastructure.Plugins.Octopus.Models
{
	#region documentation
	/// <summary>
	/// A class to assist in the deserialization of the <see cref="OctopusElectricityConsumptionApiClient"/> response.
	/// </summary>
	#endregion
	public class OctopusElectricityConsumptionElement
	{
		#region documentation
		/// <summary>
		/// A <c>double</c> representing the number of KilowattHours (kWh) consumed in the given hour.
		/// </summary>
		#endregion
		[JsonProperty("consumption")]
		public double KilowattHours { get; set; }

		#region documentation
		/// <summary>
		/// A <see cref="DateTime" /> representing the hour of the consumption.
		/// </summary>
		#endregion
		[JsonProperty("interval_end")]
		public DateTime Period { get; set; }
	}

	#region documentation
	/// <summary>
	/// Extension class for <see cref="OctopusElectricityConsumptionElement"/>
	/// </summary>
	#endregion
	public static class OctopusElectricityConsumptionElementExtensions
	{
		#region documentation
		/// <summary>
		/// Maps an <see cref="OctopusElectricityConsumptionElement"/> to an instance of <see cref="HourlyElectricityConsumptionKwh"/>.
		/// </summary>
		/// <param name="el">The <see cref="OctopusElectricityConsumptionElement"/> to be mapped.</param>
		/// <returns>The mapped <see cref="HourlyElectricityConsumptionKwh"/>.</returns>
		#endregion
		public static HourlyElectricityConsumptionKwh ToElectricityConsumptionKilowattsPerHour(this OctopusElectricityConsumptionElement el) => new()
		{
			KilowattHours = el.KilowattHours,
			Hour = el.Period,
		};
	}
}
