using System.Net.Http.Headers;
using System.Text.Json;
using EMission.Application.Models;

namespace EMission.Infrastructure.Extensions
{
	#region documentation
	/// <summary>
	/// Extension class for <see cref="ElectricityEstimateRequest" />.
	/// </summary>
	#endregion
	internal static class ElectricityEstimateRequestExtensions
	{
		#region documentation
		/// <summary>
		/// Transforms an <see cref="ElectricityEstimateRequest" /> into a <see cref="StringContent"/> object for consumption by the external Carbon Interface API.
		/// </summary>
		/// <param name="request">The <see cref="ElectricityEstimateRequest" /> to be transformed.</param>
		/// <returns>The generated <see cref="StringContent"/> object.</returns>
		#endregion
		public static StringContent ToStringContent(this ElectricityEstimateRequest request)
		{
			var requestBody = new
			{
				type = "electricity",
				electricity_unit = request.ElectricalUnits.ToString().ToLower(),
				electricity_value = request.TotalUnits.ToString(),
				country = request.CountryCode.ToLower()
			};

			var jsonContent = JsonSerializer.Serialize(requestBody);
			StringContent stringContent = new(jsonContent);
			stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

			return stringContent;
		}
	}
}