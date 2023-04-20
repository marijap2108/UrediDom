using UrediDom.Models;

namespace UrediDom.Data
{
    public interface IProductOrderRepository
    {
        List<ProductOrderDto> GetProductOrder();

        ProductOrderDto CreateProductOrder(ProductOrderDto productOrder);

        ProductOrderDto? GetByOrderId(long productOrderID);

        ProductOrderDto? GetByProductId(long productOrderID);

        void DeleteByOrderId(long OrderID);

        void DeleteByProductId(long ProductID);

        ProductOrderDto UpdateProductOrder(ProductOrderDto order, ProductOrderDto newOrder);
    }
}
