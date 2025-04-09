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

			CreateMap<Order, OrderReponseDTO>()
				.ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => $"{src.Customer.FirstName} {src.Customer.LastName}"))
				.ForMember(dest => dest.CustomerPhone, opt => opt.MapFrom(src => src.Customer.Phone))
				.ForMember(dest => dest.CustomerEmail, opt => opt.MapFrom(src => src.Customer.Email))
				.ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => $"{src.Employee.FirstName} {src.Employee.LastName}"))
				.ForMember(dest => dest.EmployeePhone, opt => opt.MapFrom(src => src.Employee.Phone))
				.ForMember(dest => dest.EmployeeEmail, opt => opt.MapFrom(src => src.Employee.Email))
				.ForMember(dest => dest.LocationName, opt => opt.MapFrom(src => src.Location.LocationName))
				.ForMember(dest => dest.LocationPhone, opt => opt.MapFrom(src => src.Location.Phone))
				.ForMember(dest => dest.LocationAddress, opt => opt.MapFrom(src => src.Location.Address))
				.ForMember(dest => dest.LocationCity, opt => opt.MapFrom(src => src.Location.City))
				.ForMember(dest => dest.LocationPostalCode, opt => opt.MapFrom(src => src.Location.PostalCode))
				.ForMember(dest => dest.StatusName, opt => opt.MapFrom(src => src.Status.StatusName));

			CreateMap<OrderDetail, OrderDetailReponseDTO>()
				.ForMember(dest => dest.ProductSku, opt => opt.MapFrom(src => src.Product.Sku))
				.ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
				.ForMember(dest => dest.ProductDescription, opt => opt.MapFrom(src => src.Product.Description))
				.ForMember(dest => dest.ProductCategoryId, opt => opt.MapFrom(src => src.Product.CategoryId))
				.ForMember(dest => dest.ProductCategoryName, opt => opt.MapFrom(src => src.Product.Category.CategoryName))
				.ForMember(dest => dest.LineTotal, opt => opt.MapFrom(src => (src.Quantity * src.UnitPrice) - src.Discount));
		}
	}
}
