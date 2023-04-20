using UrediDom.Models;

namespace UrediDom.Data
{
    public interface IOrderRepository
    {
        List<OrderDto> GetOrder();

        OrderDto CreateOrder(OrderDto order);

        OrderDto? GetOrderById(long orderID);

        void DeleteOrder(long orderID);

        OrderDto UpdateOrder(OrderDto order, OrderDto newOrder);
    }
}
