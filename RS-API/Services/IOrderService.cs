using RS_API.Entities;
using RS_API.Models;

namespace RS_API.Services;

public interface IOrderService
{
	IEnumerable<OrderDto> GetOrders();
	OrderDto GetOrder(int orderId);
	int CreateOrder(CreateOrderDto dto);
	void ChangeOrderStatus(int orderId, OrderStatus orderStatus);
	void DeleteOrder(int orderId);
}