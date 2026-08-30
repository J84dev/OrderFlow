namespace OrderService.Domain;

public enum OrderStatus { Created, Confirmed, Cancelled }

public class Order
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid CustomerId { get; private set; }
    public OrderStatus Status { get; private set; } = OrderStatus.Created;
    public List<OrderItem> Items { get; private set; } = new();
    public decimal Total => Items.Sum(i => i.UnitPrice * i.Quantity);

    private Order() { }

    public Order(Guid customerId, List<OrderItem> items)
    {
        if (items is null || items.Count == 0)
        {
            throw new ArgumentException("Pedido precisa de pelo menos um item.");
        }
        
        CustomerId = customerId;
        Items = items;
    }
}

public record OrderItem(Guid ProductId, int Quantity, decimal UnitPrice);