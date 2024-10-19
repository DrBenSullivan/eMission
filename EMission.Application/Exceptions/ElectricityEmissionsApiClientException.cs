namespace EMission.Application.Exceptions
{
	public class ElectricityEmissionsApiClientException : Exception
	{
		public ElectricityEmissionsApiClientException()
		{
		}

		public ElectricityEmissionsApiClientException(string? message) : base(message)
		{
		}

		public ElectricityEmissionsApiClientException(string? message, Exception? innerException) : base(message, innerException)
		{
		}
	}
}
