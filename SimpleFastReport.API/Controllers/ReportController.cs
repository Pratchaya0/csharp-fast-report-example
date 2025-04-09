using FastReport.Web;
using Microsoft.AspNetCore.Mvc;
using SimpleFastReport.API.DTOs;
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



        [HttpGet("data-order-json/{orderID}")]
        public async Task<IActionResult> GetFulldetailOrderByID([FromRoute] int orderID, CancellationToken cancellationToken = default) => Ok(await _services.FullDetailOrderByIDAsync(orderID, cancellationToken));

    }
}

