using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text.Json;
using EMission.Api.Models.Validators;
using EMission.Domain.Enums;

namespace EMission.Api.Models.DTOs
{
	#region documentation
	/// <summary>
	/// A DTO to represent a received request for an electricity carbon emissions estimate.
	/// </summary>
	#endregion
	public class ElectricityEstimateRequest
    {
        #region documentation
        /// <summary>
        /// A string representing the <see cref="ElectricalUnit"/> <c>enum</c>.
        /// </summary>
        #endregion
        [DisplayName("'Electrical Unit'")]
        [EnumValidator(typeof(ElectricalUnit))]
        public string ElectricalUnit { get; set; } = string.Empty;

        #region documentation
        /// <summary>
        /// A <c>double</c> representing the number of <c>ElectricityUnit</c>s used.
        /// </summary>
        #endregion
        [DisplayName("'Total Units Used")]
        [RequiredValidator]
        [GreaterThanZeroValidator]
        public double TotalUnits { get; set; }

        #region documentation
        /// <summary>
        /// A two-letter ISO country code representing the country that the request is pertinent to.
        /// </summary>
        #endregion
        [DisplayName("'Country Code'")]
        [RequiredValidator]
        [CountryCodeValidator]
        public string CountryCode { get; set; } = string.Empty;
    }

    #region documentation
    /// <summary>
    /// Extension class for <see cref="ElectricityEstimateRequest" />.
    /// </summary>
    #endregion
    public static class ElectricityEstimateRequestExtensions
    {
        #region documentation
        /// <summary>
        /// Transforms an <see cref="ElectricityEstimateRequest" /> into a <see cref="HttpContent"/> for consumption by the external Carbon Interface API.
        /// </summary>
        /// <param name="request">The <see cref="ElectricityEstimateRequest" /> to be transformed.</param>
        /// <returns>The generated <see cref="HttpContent"/>.</returns>
        #endregion
        public static StringContent ToCarbonInterfaceRequestContent(this ElectricityEstimateRequest request)
        {
            var requestBody = new Dictionary<string, string>() {
                { "type", "electricity" },
                { "electricity_unit", request.ElectricalUnit.ToLower() },
                { "electricity_value", request.TotalUnits.ToString() },
                { "country", request.CountryCode.ToLower() }
            };

            var jsonContent = JsonSerializer.Serialize(requestBody);
            var httpContent = new StringContent(jsonContent);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return httpContent;
        }
    }
}
