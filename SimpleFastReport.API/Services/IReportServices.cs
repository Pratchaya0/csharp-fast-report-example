using SimpleFastReport.API.DTOs;

namespace SimpleFastReport.API.Services
{
	public interface IReportServices
	{
		Task<List<OrderReponseDTO>> FullDetailOrderByIDAsync(int orderID, CancellationToken cancellationToken);
		Task<List<EmployeeReponseDTO>> ListEmployeeAsync(CancellationToken cancellationToken);
	}
}