namespace UrediDom.Data
{
    public interface IOrderRepository
    {
        List<Order> GetOrder();

        Order CreateOrder(Order order);

        Order? GetOrderById(long orderID);

        void DeleteOrder(long orderID);

        Order UpdateOrder(Order order, Order newOrder);
    }
}
