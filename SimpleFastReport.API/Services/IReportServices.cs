using SimpleFastReport.API.DTOs;
using SimpleFastReport.API.Models;

namespace SimpleFastReport.API.Services
{
	public interface IReportServices
	{
		Task<List<EmployeeReponseDTO>> ListEmployeeAsync(CancellationToken cancellationToken);
		Task<(List<OrderReponseDTO> header, List<OrderDetailReponseDTO> details)> OrderFullDetailByOrderID(int orderID, CancellationToken cancellationToken = default);
	}
}