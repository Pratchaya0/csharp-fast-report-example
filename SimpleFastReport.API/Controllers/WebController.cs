using FastReport.Web;
using Microsoft.AspNetCore.Mvc;
using SimpleFastReport.API.Helpers;
using SimpleFastReport.API.Services;

namespace SimpleFastReport.API.Controllers
{

	[Route("web")]
	public class WebController : Controller
	{

		private readonly IReportServices _services;
		private readonly FastReportHelper _fastReportHelper;

		public WebController(IReportServices services, FastReportHelper fastReportHelper)
		{
			_services = services;
			_fastReportHelper = fastReportHelper;
		}

		[HttpGet("employees")]
		public async Task<IActionResult> EmployeeReportViewer(CancellationToken cancellationToken = default)
		{

			try
			{

				var employees = await _services.ListEmployeeAsync(cancellationToken);

				var webReport = _fastReportHelper.CreateWebReport(employees, "ReportTemplateI.frx", "Employees");

				ToolbarSettings toolbar = new ToolbarSettings()
				{
					ShowRefreshButton = false,
					Exports = new ExportMenuSettings()
					{
						Show = true,
						ExportTypes = Exports.Prepared | Exports.Pdf | Exports.HTML | Exports.Csv | Exports.Image
					}
				};
				webReport.Toolbar = toolbar;

				ViewBag.WebReport = webReport;
				return View("~/Views/Report/Index.cshtml");

			}
			catch (Exception ex)
			{
				return StatusCode(500, $"An error occurred while generating the report: {ex.Message}");
			}

		}

		[HttpGet("order-details/{orderID}")]
		public async Task<IActionResult> OrderDetailReportViewer([FromRoute] int orderID, CancellationToken cancellationToken = default)
		{

			try
			{

				var (header, details) = await _services.OrderFullDetailByOrderID(orderID, cancellationToken);

				var dataSources = new Dictionary<string, IEnumerable<object>>
				{
					{ "Header", header },
					{ "Details", details },
				};

				var webReport = _fastReportHelper.CreateWebReport(dataSources, "ReportTemplateII.frx");

				ToolbarSettings toolbar = new ToolbarSettings()
				{
					ShowRefreshButton = false,
					Exports = new ExportMenuSettings()
					{
						Show = true,
						ExportTypes = Exports.Prepared | Exports.Pdf | Exports.Excel2007 | Exports.Word2007 | Exports.HTML | Exports.Csv | Exports.Image
					}
				};
				webReport.Toolbar = toolbar;

				ViewBag.WebReport = webReport;
				return View("~/Views/Report/OrderDetails.cshtml");

			}
			catch (Exception ex)
			{
				return StatusCode(500, $"An error occurred while generating the report: {ex.Message}");
			}

		}


	}
}
