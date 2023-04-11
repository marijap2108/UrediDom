using UrediDom.Entities;

namespace UrediDom.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext context;

        public OrderRepository(OrderContext context)
        {
            this.context = context;
        }

        public List<Order> GetOrder()
        {
            Console.WriteLine(context.Order.ToList());
            return context.Order.ToList();
        }

        public Order CreateOrder(Order order)
        {
            var createdEntity = context.Add(order);
            context.SaveChanges();
            return createdEntity.Entity;
        }

        public Order? GetOrderById(long orderID)
        {
            return context.Order.FirstOrDefault(e => e.OrderID == orderID);
        }

        public void DeleteOrder(long orderID)
        {
            var order = GetOrderById(orderID);

            if (order != null)
            {
                context.Remove(order);
                context.SaveChanges();
            }
        }

        public Order UpdateOrder(Order order, Order newOrder)
        {
            order.DateOfOrder = newOrder.DateOfOrder;
            order.Amount = newOrder.Amount;
            order.CustomerID = newOrder.CustomerID;
            order.RepairmanID = newOrder.RepairmanID;
            context.SaveChanges();
            return order;
        }
    }
}
