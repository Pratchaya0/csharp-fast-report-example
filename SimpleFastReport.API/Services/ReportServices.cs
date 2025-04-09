using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SimpleFastReport.API.Data;
using SimpleFastReport.API.DTOs;

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

		public async Task<List<EmployeeReponseDTO>> ListEmployeeAsync()
			=> await _dBContext.Employees.Take(1000).ProjectTo<EmployeeReponseDTO>(_mapper.ConfigurationProvider).ToListAsync();

		public async Task<List<OrderReponseDTO>> FullDetailOrderByIDAsync(int orderID)
		{
			var order = await _dBContext.Orders
				.Include(_ => _.OrderDetails)
				.Include(_ => _.OrderDetails).ThenInclude(_ => _.Product)
				.Include(_ => _.OrderDetails).ThenInclude(_ => _.Product).ThenInclude(_ => _.ProductGroup)
				.Where(_ => _.OrderId == orderID && _.IsActive == true)
				.AsSplitQuery()
				.ProjectTo<OrderReponseDTO>(_mapper.ConfigurationProvider)
				.ToListAsync();

			return order;
		}

	}
}
