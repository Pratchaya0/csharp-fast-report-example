using FastReport.Web;
using Microsoft.AspNetCore.Mvc;
using SimpleFastReport.API.Helpers;
using SimpleFastReport.API.Models;
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
		public async Task<IActionResult> EmployeeReportViewer()
		{

			try
			{

				var employees = await _services.ListEmployeeAsync();

				var webReport = _fastReportHelper.CreateWebReport(employees, "ReportTemplateI.frx", "Employees");

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
				return View("~/Views/Report/Index.cshtml");

			}
			catch (Exception ex)
			{
				return StatusCode(500, $"An error occurred while generating the report: {ex.Message}");
			}

		}

		[HttpGet("orders")]
		public async Task<IActionResult> OrderReportViewer()
		{

			try
			{

				var order = await _services.FullDetailOrderByIDAsync(4);

				var webReport = _fastReportHelper.CreateWebReport(order, "ReportTemplateII.frx", "Orders");

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
