using UrediDom.Entities;
using UrediDom.Models;

namespace UrediDom.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext context;

        public OrderRepository(OrderContext context)
        {
            this.context = context;
        }

        public List<OrderDto> GetOrder()
        {
            Console.WriteLine(context.order.ToList());
            return context.order.ToList();
        }

        public OrderDto CreateOrder(OrderDto order)
        {
            order.dateOfOrder = DateTime.Now;
            var createdEntity = context.Add(order);
            context.SaveChanges();
            return createdEntity.Entity;
        }

        public OrderDto? GetOrderById(long orderID)
        {
            return context.order.FirstOrDefault(e => e.orderID == orderID);
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

        public OrderDto UpdateOrder(OrderDto order, OrderDto newOrder)
        {
            order.dateOfOrder = newOrder.dateOfOrder;
            order.amount = newOrder.amount;
            order.customerID = newOrder.customerID;
            order.repairmanID = newOrder.repairmanID;
            context.SaveChanges();
            return order;
        }
    }
}
