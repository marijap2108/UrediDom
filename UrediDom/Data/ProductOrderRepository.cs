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

        public List<ProductOrder> GetProductOrder()
        {
            Console.WriteLine(context.ProductOrder.ToList());
            return context.ProductOrder.ToList();
        }

        public ProductOrder CreateProductOrder(ProductOrder productOrder)
        {
            var createdEntity = context.Add(productOrder);
            context.SaveChanges();
            return createdEntity.Entity;
        }

        public ProductOrder? GetByOrderId(long productOrderID)
        {
            return context.ProductOrder.FirstOrDefault(e => e.OrderID == productOrderID);
        }

        public ProductOrder? GetByProductId(long productOrderID)
        {
            return context.ProductOrder.FirstOrDefault(e => e.ProductID == productOrderID);
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

        public ProductOrder UpdateProductOrder(ProductOrder order, ProductOrder newOrder)
        {
            order.ProductID = newOrder.ProductID;
            order.OrderID = newOrder.OrderID;
            order.Quantity = newOrder.Quantity;
            order.Price = newOrder.Price;
            context.SaveChanges();
            return order;
        }
    }
}
