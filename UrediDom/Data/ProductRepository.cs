using Microsoft.EntityFrameworkCore;
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

        public List<ProductDto> GetProduct(QueryParams queryParams)
        {
            if (queryParams.SortDirection == "asc")
            {
                return context.product.OrderBy(e => EF.Property<ProductDto>(e, queryParams.Sort ?? "productID")).Skip(queryParams.Step ?? 0).Take(9).ToList();
            }

            return context.product.OrderByDescending(e => EF.Property<ProductDto>(e, queryParams.Sort ?? "productID")).Skip(queryParams.Step ?? 0).Take(9).ToList();
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

        public List<ProductDto>? GetProductByType(long typeID, QueryParams queryParams)
        {
            if (queryParams.SortDirection == "asc")
            {
                return context.product.Where(e => e.typeID == typeID).OrderBy(e => EF.Property<ProductDto>(e, queryParams.Sort ?? "productID")).Skip(queryParams.Step ?? 0).Take(9).ToList();
            }

            return context.product.Where(e => e.typeID == typeID).OrderByDescending(e => EF.Property<ProductDto>(e, queryParams.Sort ?? "productID")).Skip(queryParams.Step ?? 0).Take(9).ToList();
        }
    }
}
