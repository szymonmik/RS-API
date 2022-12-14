using Microsoft.AspNetCore.Mvc;
using RS_API.Entities;
using RS_API.Models;
using RS_API.Services;

namespace RS_API.Controllers;

[Route("api/order")]
[ApiController]
public class OrderController : ControllerBase
{
	private readonly IOrderService _orderService;

	public OrderController(IOrderService orderService)
	{
		_orderService = orderService;
	}

	[HttpPost]
	public ActionResult Create([FromBody] CreateOrderDto dto)
	{
		var orderId = _orderService.CreateOrder(dto);

		return Ok(orderId);
	}
	
	[HttpGet("{orderId}")]
	public ActionResult<IEnumerable<OrderDto>> Get([FromRoute] int orderId)
	{
		var order = _orderService.GetOrder(orderId);

		return Ok(order);
	}

	[HttpGet]
	public ActionResult<IEnumerable<OrderDto>> GetAll()
	{
		var orders = _orderService.GetOrders();

		return Ok(orders);
	}

	[HttpPut("{orderId}")]
	public ActionResult Update([FromRoute] int orderId, [FromBody] OrderStatus orderStatus)
	{
		_orderService.ChangeOrderStatus(orderId, orderStatus);

		return NoContent();
	}

	[HttpDelete("{orderId}")]
	public ActionResult Delete([FromRoute] int orderId)
	{
		_orderService.DeleteOrder(orderId);

		return NoContent();
	}
}