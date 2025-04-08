﻿using FastReport.Web;
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

				throw new NotImplementedException();

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

				throw new NotImplementedException();

			}
			catch (Exception ex)
			{
				return StatusCode(500, $"An error occurred while generating the report: {ex.Message}");
			}

		}

	}
}
