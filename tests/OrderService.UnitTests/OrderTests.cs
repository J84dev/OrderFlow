using OrderService.Domain;

namespace OrderService.UnitTests;

public class OrderTests
{
    [Fact]
    public void Deve_lancar_excecao_quando_pedido_sem_itens()
    {
        Assert.Throws<ArgumentException>(() =>
            new Order(Guid.NewGuid(), new List<OrderItem>()));
    }

    [Fact]
    public void Deve_calcular_total_corretamente()
    {
        var order = new Order(Guid.NewGuid(), new List<OrderItem>
        {
            new(Guid.NewGuid(), 2, 10m),
            new(Guid.NewGuid(), 1, 5m)
        });

        Assert.Equal(25m, order.Total);
    }
}
