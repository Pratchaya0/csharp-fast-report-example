using AutoMapper;
using SimpleFastReport.API.DTOs;
using SimpleFastReport.API.Models;

namespace SimpleFastReport.API
{
	public class AutoMapperProfile : Profile
	{

		public AutoMapperProfile()
		{

			CreateMap<Employee, EmployeeReponseDTO>();

			CreateMap<Order, OrderReponseDTO>();

			CreateMap<OrderDetail, OrderDetailReponseDTO>()
				.ForMember(_ => _.ProductDetail, _ => _.MapFrom(_ => _.Product));

		}
	}
}
