using AutoMapper;
using RS_API.Entities;
using RS_API.Models;

namespace RS_API;

public class AppMappingProfile : Profile
{
	public AppMappingProfile()
	{
		CreateMap<Record, RecordDto>()
			.ForMember(m => m.Genre, opt => opt.MapFrom(r => r.Genre))
			.ForMember(m => m.Format, opt => opt.MapFrom(r => r.Format));

		CreateMap<Order, OrderDto>()
			.ForMember(m => m.Country, opt => opt.MapFrom(o => o.Country))
			.ForMember(m => m.OrderRecords, opt => opt.MapFrom(o => o.OrderRecords.Select(or => or.Record)));

		CreateMap<CreateRecordDto, Record>();

		CreateMap<CreateOrderDto, Order>();

		CreateMap<OrderRecordDto, OrderRecord>();
	}
}