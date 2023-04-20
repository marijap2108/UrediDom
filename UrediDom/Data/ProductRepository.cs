using UrediDom.Entities;
using UrediDom.Models;

namespace UrediDom.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext context;

        public ProductRepository(ProductContext context)
        {
            this.context = context;
        }

        public List<ProductDto> GetProduct()
        {
            Console.WriteLine(context.product.ToList());
            return context.product.ToList();
        }

        public ProductDto CreateProduct(ProductDto product)
        {
            var createdEntity = context.Add(product);
            context.SaveChanges();
            return createdEntity.Entity;
        }

        public ProductDto? GetProductById(long productID)
        {
            return context.product.FirstOrDefault(e => e.productID == productID);
        }

        public void DeleteProduct(long productID)
        {
            var product = GetProductById(productID);

            if (product != null)
            {
                context.Remove(product);
                context.SaveChanges();
            }
        }

        public ProductDto UpdateProduct(ProductDto product, ProductDto newProduct)
        {
            product.productName = newProduct.productName;
            product.price = newProduct.price;
            product.description = newProduct.description;
            product.quantity = newProduct.quantity;
            product.typeID = newProduct.typeID;
            product.groupID = newProduct.groupID;
            context.SaveChanges();
            return product;
        }
    }
}
