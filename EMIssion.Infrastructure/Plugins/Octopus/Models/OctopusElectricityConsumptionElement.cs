using EMission.Application.Models;
using Newtonsoft.Json;

namespace EMission.Infrastructure.Plugins.Octopus.Models
{
	public class OctopusElectricityConsumptionElement
	{
		[JsonProperty("consumption")]
		public double Kilowatts { get; set; }

		[JsonProperty("interval_end")]
		public DateTime Period { get; set; }
	}

	public static class OctopusElectricityConsumptionElementExtensions
	{
		public static HourlyElectricityConsumptionKwh ToElectricityConsumptionKilowattsPerHour(this OctopusElectricityConsumptionElement el) => new()
		{
			KilowattHours = el.Kilowatts,
			Hour = el.Period,
		};
	}
}
