﻿using FastReport;
using FastReport.Data;
using FastReport.Export.Html;
using FastReport.Export.Image;
using FastReport.Export.PdfSimple;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Text;
using System.Drawing;
using System.Text.Json.Serialization;
using FastReport.Web;

namespace SimpleFastReport.API.Helpers
{
	public class FastReportHelper : ControllerBase
	{
		public string ReportsPath { get; private set; }

		public FastReportHelper()
		{
			SetReportsFolder();
		}

		private void SetReportsFolder() => ReportsPath = FindReportsFolder(Environment.CurrentDirectory);

		private string FindReportsFolder(string startDir)
		{
			string directory = Path.Combine(startDir, "Reports");
			if (Directory.Exists(directory))
				return directory;
			for (int i = 0; i < 6; i++)
			{
				startDir = Path.Combine(startDir, "..");
				directory = Path.Combine(startDir, "Reports");
				if (Directory.Exists(directory))
					return directory;
			}
			throw new Exception("Reports directory is not found");
		}

		public async Task<IActionResult> ExportReport<T>(IEnumerable<T> data, string reportTemplate, string filename, ExportType type, string? dataSourceName = "JSON")
		{

			var report = new Report();

			try
			{

				report.Load(Path.Combine(ReportsPath, reportTemplate));
				report.RegisterData(data, dataSourceName);
				report.Prepare();

				using (MemoryStream ms = new MemoryStream())
				{
					switch (type)
					{
						case ExportType.PDF:
							PDFSimpleExport pdf = new PDFSimpleExport();
							report.Export(pdf, ms);
							return File(ms.ToArray(), "application/pdf", $"{filename}.pdf");

						case ExportType.HTML:
							HTMLExport html = new HTMLExport();
							report.Export(html, ms);
							return File(ms.ToArray(), "text/html", $"{filename}.html");

						case ExportType.JPEG:
						case ExportType.PNG:
							ImageExport image = new ImageExport();
							image.ImageFormat = GetImageFormat(type);
							report.Export(image, ms);
							return File(ms.ToArray(), GetMimeType(type), $"{filename}.{type.ToString().ToLower()}");

						default:
							return BadRequest("Unsupported export type");
					}
				}

			}
			catch (Exception ex)
			{
				return BadRequest($"Error generating report: {ex.Message}");
			}
			finally
			{
				report.Dispose();
			}

		}

		// For more than 1 data set
		public async Task<IActionResult> ExportReport<T>(Dictionary<string, IEnumerable<T>> dataSources, string reportTemplate, string filename, ExportType type)
		{
			var report = new Report();

			try
			{

				report.Load(Path.Combine(ReportsPath, reportTemplate));

				// Register all datasets dynamically
				foreach (var kv in dataSources)
				{
					report.RegisterData(kv.Value, kv.Key);
				}

				report.Prepare();

				using (MemoryStream ms = new MemoryStream())
				{

					switch (type)
					{
						case ExportType.PDF:
							var pdf = new PDFSimpleExport();
							report.Export(pdf, ms);
							break;
						case ExportType.HTML:
							var html = new HTMLExport();
							report.Export(html, ms);
							break;
						case ExportType.JPEG:
						case ExportType.PNG:
							var image = new ImageExport { ImageFormat = GetImageFormat(type) };
							report.Export(image, ms);
							break;
						default:
							return BadRequest("Unsupported export type");
					}

					var contentType = GetMimeType(type);
					var fileExtension = type.ToString().ToLower();

					return File(ms.ToArray(), contentType, $"{filename}.{fileExtension}");

				}	

			}
			catch (Exception ex)
			{
				return BadRequest($"Error generating report: {ex.Message}");
			}
			finally
			{
				report.Dispose();
			}

		}

		public WebReport CreateReport<T>(IEnumerable<T> data, string reportTemplate, string? dataSetName = "JSON")
		{
			var webReport = new WebReport();
			webReport.Report.Load(Path.Combine(ReportsPath, reportTemplate));
			webReport.Report.RegisterData(data, dataSetName);
			webReport.Report.Prepare();
			return webReport;
		}

		private ImageExportFormat GetImageFormat(ExportType type)
		{
			switch (type)
			{
				case ExportType.JPEG: return ImageExportFormat.Jpeg;
				case ExportType.PNG: return ImageExportFormat.Png;
				default: throw new ArgumentException("Invalid image export type");
			}
		}

		private string GetMimeType(ExportType type)
		{
			switch (type)
			{
				case ExportType.JPEG: return "image/jpeg";
				case ExportType.PNG: return "image/png";
				default: throw new ArgumentException("Invalid image export type");
			}
		}
	}

	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum ExportType
	{
		Excel = 0,
		PDF = 1,
		HTML = 2,
		JPEG = 3,
		PNG = 4,
	}

}
