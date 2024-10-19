namespace EMission.Application.Plugins.Octopus.Exceptions
{
	public class OctopusElectricityConsumptionApiClientException : Exception
	{
		public OctopusElectricityConsumptionApiClientException()
		{
		}

		public OctopusElectricityConsumptionApiClientException(string? message) : base(message)
		{
		}

		public OctopusElectricityConsumptionApiClientException(string? message, Exception? innerException) : base(message, innerException)
		{
		}
	}
}
