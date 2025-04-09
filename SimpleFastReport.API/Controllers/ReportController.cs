using Microsoft.AspNetCore.Mvc;
using SimpleFastReport.API.Helpers;
using SimpleFastReport.API.Services;

namespace SimpleFastReport.API.Controllers
{
	[Route("api/report")]
	[ApiController]
	public class ReportController : ControllerBase
	{
		private readonly IReportServices _services;
		private readonly FastReportHelper _fastReportHelper;

		public ReportController(IReportServices services, FastReportHelper fastReportHelper)
		{
			_services = services;
			_fastReportHelper = fastReportHelper;
		}


		[HttpGet("data-employee-json")]
		public async Task<IActionResult> GetListEmployee(CancellationToken cancellationToken = default) => Ok(await _services.ListEmployeeAsync(cancellationToken));

		[HttpGet("employee-pdf")]
		public async Task<IActionResult> EmployeePDFReport(CancellationToken cancellationToken = default)
		{
			var employees = await _services.ListEmployeeAsync(cancellationToken);

			return await _fastReportHelper.ExportReport(employees, "ReportTemplateI.frx", "fileName", ExportType.PDF, "Employees");
		}




		[HttpGet("data-order-json/{orderID}")]
		public async Task<IActionResult> GetFulldetailOrderByID([FromRoute] int orderID, CancellationToken cancellationToken = default) => Ok(await _services.FullDetailOrderByIDAsync(orderID, cancellationToken));

		[HttpGet("order-pdf/{orderID}")]
		public async Task<IActionResult> OrderPDFReport([FromRoute] int orderID, CancellationToken cancellationToken)
		{
			var order = await _services.FullDetailOrderByIDAsync(orderID, cancellationToken);

			return await _fastReportHelper.ExportReport(order, "OrderByID.frx", "order_details", ExportType.PDF);
		}

	}
}

