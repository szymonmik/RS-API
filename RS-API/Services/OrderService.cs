using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using RS_API.Attributes;
using RS_API.Entities;
using RS_API.Exceptions;
using RS_API.Models;

namespace RS_API.Services;

public class OrderService : IOrderService
{
	private readonly StoreDbContext _dbContext;
	private readonly IMapper _mapper;

	public OrderService(StoreDbContext dbContext, IMapper mapper)
	{
		_dbContext = dbContext;
		_mapper = mapper;
	}
	
	public IEnumerable<OrderDto> GetOrders()
	{
		var orders = _dbContext.Orders
			.Include(x => x.OrderRecords)
			.ThenInclude(x => x.Record)
			.ToList();

		var ordersDto = _mapper.Map<List<OrderDto>>(orders);
		
		return ordersDto;
	}

	public OrderDto GetOrder(int orderId)
	{
		var order = _dbContext.Orders
			.Include(x => x.OrderRecords)
			.ThenInclude(x => x.Record)
			.FirstOrDefault(x => x.Id == orderId);

		if (order is null)
		{
			throw new NotFoundException("Order not found");
		}

		var orderDto = _mapper.Map<OrderDto>(order);

		return orderDto;
	}

	public int CreateOrder(CreateOrderDto dto)
	{
		//var order = _mapper.Map<Order>(dto);

		var order = new Order()
		{
			Country = dto.Country,
			TaxRate = dto.Country.GetAttributeOfType<TaxAttribute>().Tax,
		};

		_dbContext.Orders.Add(order);
		
		_dbContext.SaveChanges();

		var orderList = new List<OrderRecord>();

		foreach (var orderRecordDto in dto.OrderRecords)
		{
			var orderRecord = new OrderRecord()
			{
				OrderId = order.Id,
				RecordId = orderRecordDto.RecordId,
				Quantity = orderRecordDto.Quantity
			};
			orderList.Add(orderRecord);
			
		}
		_dbContext.OrderRecords.AddRange(orderList);
		_dbContext.SaveChanges();
		
		return order.Id;
	}

	public void ChangeOrderStatus(int orderId, OrderStatus orderStatus)
	{
		var order = _dbContext.Orders.FirstOrDefault(x => x.Id == orderId);

		if (order is null)
		{
			throw new NotFoundException("Order not found");
		}

		_dbContext.Orders.Update(order);

		order.OrderStatus = orderStatus;

		_dbContext.SaveChanges();
	}

	public void DeleteOrder(int orderId)
	{
		var order = _dbContext.Orders.FirstOrDefault(x => x.Id == orderId);

		if (order is null)
		{
			throw new NotFoundException("Order not found");
		}

		_dbContext.Remove(order);
		
		_dbContext.SaveChanges();
	}
}