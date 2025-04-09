using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SimpleFastReport.API.Data;
using SimpleFastReport.API.DTOs;
using SimpleFastReport.API.Models;

namespace SimpleFastReport.API.Services
{
	public class ReportServices : IReportServices
	{

		private readonly AppDBContext _dBContext;
		private readonly IMapper _mapper;

		public ReportServices(AppDBContext dBContext, IMapper mapper)
		{
			_dBContext = dBContext;
			_mapper = mapper;
		}

		public async Task<List<EmployeeReponseDTO>> ListEmployeeAsync(CancellationToken cancellationToken = default)
			=> await _dBContext.Employees.Take(1000).ProjectTo<EmployeeReponseDTO>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

		public async Task<(List<OrderReponseDTO> header, List<OrderDetailReponseDTO> details)> OrderFullDetailByOrderID(int orderID, CancellationToken cancellationToken = default)
		{

			var header = await _dBContext.Orders
				.Include(_ => _.Customer)
				.Include(_ => _.Employee)
				.Include(_ => _.Location)
				.Include(_ => _.Status)
				.Where(_ => _.OrderId == orderID)
				.AsSplitQuery()
				.ProjectTo<OrderReponseDTO>(_mapper.ConfigurationProvider)
				.ToListAsync(cancellationToken);


			var details = await _dBContext.OrderDetails
				.Include(_ => _.Order)
				.Include(_ => _.Product)
				.Include(_ => _.Product).ThenInclude(_ => _.Category)
				.Where(_ => _.OrderId == orderID)
				.AsSplitQuery()
				.ProjectTo<OrderDetailReponseDTO>(_mapper.ConfigurationProvider)
				.ToListAsync(cancellationToken);

			return (header, details);

		}

	}
}
