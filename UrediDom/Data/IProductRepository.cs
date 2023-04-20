using UrediDom.Models;

namespace UrediDom.Data
{
    public interface IProductRepository
    {
        List<ProductDto> GetProduct();

        ProductDto CreateProduct(ProductDto product);

        ProductDto? GetProductById(long productID);

        void DeleteProduct(long productID);

        ProductDto UpdateProduct(ProductDto product, ProductDto newProduct);
    }
}
