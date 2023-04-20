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

        public List<ProductCategoryDto> GetProductCategory()
        {
            Console.WriteLine(context.productCategory.ToList());
            return context.productCategory.ToList();
        }

        public ProductCategoryDto CreateProductCategory(ProductCategoryDto productCategory)
        {
            var createdEntity = context.Add(productCategory);
            context.SaveChanges();
            return createdEntity.Entity;
        }

        public ProductCategoryDto? GetProductCategoryById(long productCategoryID)
        {
            return context.productCategory.FirstOrDefault(e => e.categoryID == productCategoryID);
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

        public ProductCategoryDto UpdateProductCategory(ProductCategoryDto category, ProductCategoryDto newCategory)
        {
            category.category = newCategory.category;
            category.valueCat = newCategory.valueCat;
            context.SaveChanges();
            return category;
        }
    }
}
