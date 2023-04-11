namespace UrediDom.Data
{
    public interface IProductOrderRepository
    {
        List<ProductOrder> GetProductOrder();

        ProductOrder CreateProductOrder(ProductOrder productOrder);

        ProductOrder? GetByOrderId(long productOrderID);

        ProductOrder? GetByProductId(long productOrderID);

        void DeleteByOrderId(long OrderID);

        void DeleteByProductId(long ProductID);

        ProductOrder UpdateProductOrder(ProductOrder order, ProductOrder newOrder);
    }
}
