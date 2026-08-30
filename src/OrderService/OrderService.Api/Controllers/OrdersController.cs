using Microsoft.AspNetCore.Mvc;
using OrderService.Domain;
using OrderService.Infrastructure;

namespace OrderService.Api.Controllers;

[ApiController]
[Route("orders")]
public class OrdersController(OrderDbContext db) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderRequest request)
    {
        var order = new Order(request.CustomerId,
            request.Items.Select(i => new OrderItem(i.ProductId, i.Quantity, i.UnitPrice)).ToList());

        db.Orders.Add(order);
        await db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var order = await db.Orders.FindAsync(id);
        return order is null ? NotFound() : Ok(order);
    }
}

public record CreateOrderRequest(Guid CustomerId, List<CreateOrderItemRequest> Items);
public record CreateOrderItemRequest(Guid ProductId, int Quantity, decimal UnitPrice);