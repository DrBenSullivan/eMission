using EMission.Application.Models;
using ScottPlot;
using ScottPlot.TickGenerators;
using ScottPlot.TickGenerators.TimeUnits;

namespace EMission.Application.Services
{
	#region documentation
	/// <summary>
	/// Static service for plotting graphs.
	/// </summary>
	#endregion
	public static class GraphPlottingService
	{
		#region documentation
		/// <summary>
		/// Gets a <c>byte[]</c> representing the <c>jpeg</c> of a plotted graph based on the given hourly consumption.
		/// </summary>
		/// <param name="hourlyConsumption">A list of <see cref="HourlyElectricityConsumptionKwh"/> representing electricity consumption (kWh) per hour.</param>
		/// <returns>The plotted graph <c>jpeg</c> represented as a <c>byte[]</c>.</returns>
		#endregion
		public static byte[] GetHourlyConsumptionGraph(List<HourlyElectricityConsumptionKwh> hourlyConsumption)
		{
			List<DateTime> dateTimes = hourlyConsumption.Select(h => h.Hour).ToList();
			List<double> consumption = hourlyConsumption.Select(h => h.KilowattHours).ToList();

			var plot = DrawHourlyGraph(dateTimes, consumption);
			plot.Title($"Your Hourly Electricity Consumption\n({dateTimes.Last():dd/MM/yy} - {dateTimes.First():dd/MM/yy})");
			plot.YLabel("Electricity Consumption (kWh)");

			return plot.GetImageBytes(600, 400, ImageFormat.Jpeg);
		}

		#region documentation
		/// <summary>
		/// Gets a <c>byte[]</c> representing the <c>jpeg</c> of a plotted graph based on the given hourly emissions.
		/// </summary>
		/// <param name="hourlyConsumption">A list of <see cref="HourlyElectricityEmissionsEstimate"/> representing carbon dioxide emissions (g) per hour.</param>
		/// <returns>The plotted graph <c>jpeg</c> represented as a <c>byte[]</c>.</returns>
		#endregion
		public static byte[] GetHourlyEmissionsGraph(List<HourlyElectricityEmissionsEstimate> hourlyEmissions)
		{
			List<DateTime> dateTimes = hourlyEmissions.Select(h => h.Hour).ToList();
			List<double> emissions = hourlyEmissions.Select(h => h.CarbonEmissionsGrams).ToList();

			var plot = DrawHourlyGraph(dateTimes, emissions);
			plot.Title($"Your Estimated Hourly CO₂ Emissions from Electricity Consumption\n({dateTimes.Last():dd/MM/yy} - {dateTimes.First():dd/MM/yy})");
			plot.YLabel("Estimated CO₂ Emissions (g)");

			return plot.GetImageBytes(600, 400, ImageFormat.Jpeg);
		}

		#region documentation
		/// <summary>
		/// Gets a <see cref="Plot"/> with hours plotted on the x-axis and the hourly values plotted on the y-axis.
		/// <para>
		/// The title and y-axis label should be subsequently added to the returned <see cref="Plot"/>. The x-axis will be labelled "Hour".
		/// </para>
		/// </summary>
		/// <param name="dateTimes">A list of <c>DateTime</c>s to be plotted on the x-axis.</param>
		/// <param name="hourlyValues">A list of values to be plotted on the y-axis.</param>
		/// <returns>The <see cref="Plot"/> of the plotted values.</returns>
		#endregion
		private static Plot DrawHourlyGraph(List<DateTime> dateTimes, List<double> hourlyValues)
		{
			var startDateTime = dateTimes.Last();
			var endDateTime = dateTimes.First();

			Plot plot = new();
			double[] dataX = [.. dateTimes.Select(d => d.ToOADate())];
			double[] dataY = [.. hourlyValues];
			plot.Add.Scatter(dataX, dataY);

			plot.AddHourXAxis(startDateTime);
			plot.Axes.SetLimitsX(startDateTime.ToOADate(), endDateTime.AddHours(1).ToOADate());

			return plot;
		}
	}

	#region documentation
	/// <summary>
	/// Extension class for <see cref="Plot"/>.
	/// </summary>
	#endregion
	public static class PlotExtensions
	{
		#region documentation
		/// <summary>
		/// Adds tick marks and labels to the x-axis of the given <see cref="Plot"/>.
		/// </summary>
		/// <param name="plot">The Plot to add the x-axis and label to.</param>
		/// <param name="startDateTime">The Date Time to start the hour values at.</param>
		/// <returns>The <see cref="Plot"/> with the added x-axis label and tickmarks.</returns>
		#endregion
		public static Plot AddHourXAxis(this Plot plot, DateTime startDateTime)
		{
			plot.Axes.DateTimeTicksBottom().TickGenerator = new DateTimeFixedInterval(
				new Hour(), 1,
				getIntervalStartFunc: dt => startDateTime);

			plot.RenderManager.RenderStarting += (s, e) =>
			{
				Tick[] ticks = plot.Axes.Bottom.TickGenerator.Ticks;
				for (int i = 0; i < ticks.Length; i++)
				{
					if (i % 6 == 0)
					{
						DateTime dt = DateTime.FromOADate(ticks[i].Position);
						string label = $"{dt:HH:mm}";
						ticks[i] = new Tick(ticks[i].Position, label);
					}
					else
					{
						ticks[i] = new Tick(ticks[i].Position, string.Empty, false);
					}
				}
			};

			plot.XLabel("Hour");

			return plot;
		}
	}
}
