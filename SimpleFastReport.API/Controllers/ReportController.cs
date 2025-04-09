using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
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

		[HttpGet("employee-pdf")]
		public async Task<IActionResult> EmployeePDFReport(CancellationToken cancellationToken = default)
		{
			var employees = await _services.ListEmployeeAsync(cancellationToken);

			return await _fastReportHelper.ExportReport(employees, "ReportTemplateI.frx", "employee-list", ExportType.PDF, "Employees");
		}

		[HttpGet("order-details/{orderID}")]
		public async Task<IActionResult> GetOrderDetailByOrderID([FromRoute] int orderID, CancellationToken cancellationToken = default)
		{

			var (header, details) = await _services.OrderFullDetailByOrderID(orderID, cancellationToken);

			var dataSources = new Dictionary<string, IEnumerable<object>>
			{
				{ "Header", header },
				{ "Details", details },
			};

			return await _fastReportHelper.ExportReport(dataSources, "ReportTemplateII.frx", "order-details", ExportType.PDF);

		}

	}
}

