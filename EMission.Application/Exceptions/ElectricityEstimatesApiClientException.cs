namespace EMission.Application.Exceptions
{
	public class ElectricityEstimatesApiClientException : Exception
	{
		public ElectricityEstimatesApiClientException()
		{
		}

		public ElectricityEstimatesApiClientException(string? message) : base(message)
		{
		}

		public ElectricityEstimatesApiClientException(string? message, Exception? innerException) : base(message, innerException)
		{
		}
	}
}
