using UrediDom.Models;

namespace UrediDom.Data
{
    public interface IOrderRepository
    {
        List<OrderDto> GetOrder();

        OrderDto CreateOrder(OrderDto order);

        OrderDto? GetOrderById(long orderID);

        OrderDto? GetOrderByIntent(string intent);

        void DeleteOrder(long orderID);

        OrderDto UpdateOrder(OrderDto order, OrderDto newOrder);
    }
}
