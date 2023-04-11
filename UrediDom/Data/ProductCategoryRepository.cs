using UrediDom.Entities;
using UrediDom.Models;

namespace UrediDom.Data
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly ProductCategoryContext context;

        public ProductCategoryRepository(ProductCategoryContext context)
        {
            this.context = context;
        }

        public List<ProductCategory> GetProductCategory()
        {
            Console.WriteLine(context.ProductCategory.ToList());
            return context.ProductCategory.ToList();
        }

        public ProductCategory CreateProductCategory(ProductCategory productCategory)
        {
            var createdEntity = context.Add(productCategory);
            context.SaveChanges();
            return createdEntity.Entity;
        }

        public ProductCategory? GetProductCategoryById(long productCategoryID)
        {
            return context.ProductCategory.FirstOrDefault(e => e.CategoryID == productCategoryID);
        }

        public void DeleteProductCategory(long productCategoryID)
        {
            var category = GetProductCategoryById(productCategoryID);

            if (category != null)
            {
                context.Remove(category);
                context.SaveChanges();
            }
        }

        public ProductCategory UpdateProductCategory(ProductCategory category, ProductCategory newCategory)
        {
            category.Category = newCategory.Category;
            category.ValueCat = newCategory.ValueCat;
            context.SaveChanges();
            return category;
        }
    }
}
