using UrediDom.Entities;
using UrediDom.Models;

namespace UrediDom.Data
{
    public class ProductOrderRepository : IProductOrderRepository
    {
        private readonly ProductOrderContext context;

        public ProductOrderRepository(ProductOrderContext context)
        {
            this.context = context;
        }

        public List<ProductOrderDto> GetProductOrder()
        {
            Console.WriteLine(context.productOrder.ToList());
            return context.productOrder.ToList();
        }

        public ProductOrderDto CreateProductOrder(ProductOrderDto productOrder)
        {
            var createdEntity = context.Add(productOrder);
            context.SaveChanges();
            return createdEntity.Entity;
        }

        public ProductOrderDto? GetByOrderId(long productOrderID)
        {
            return context.productOrder.FirstOrDefault(e => e.orderID == productOrderID);
        }

        public ProductOrderDto? GetByProductId(long productOrderID)
        {
            return context.productOrder.FirstOrDefault(e => e.productID == productOrderID);
        }

        public void DeleteByOrderId(long OrderID)
        {
            var productOrder = GetByOrderId(OrderID);

            if (productOrder != null)
            {
                context.Remove(productOrder);
                context.SaveChanges();
            }
        }

        public void DeleteByProductId(long ProductID)
        {
            var productOrder = GetByProductId(ProductID);

            if (productOrder != null)
            {
                context.Remove(productOrder);
                context.SaveChanges();
            }
        }

        public ProductOrderDto UpdateProductOrder(ProductOrderDto order, ProductOrderDto newOrder)
        {
            order.productID = newOrder.productID;
            order.orderID = newOrder.orderID;
            order.quantity = newOrder.quantity;
            order.price = newOrder.price;
            context.SaveChanges();
            return order;
        }
    }
}
