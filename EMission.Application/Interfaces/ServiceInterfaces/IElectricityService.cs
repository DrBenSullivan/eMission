using EMission.Application.Models;

namespace EMission.Application.Interfaces.ServiceInterfaces
{
	public interface IElectricityService
	{
		public Task<ElectricityEstimateResponse> GetElectricityEstimateAsync(ElectricityEstimateRequest request);
	}
}
