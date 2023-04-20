using UrediDom.Entities;
using UrediDom.Models;

namespace UrediDom.Data
{
    public class CategoryProductRepository : ICategoryProductRepository
    {
        private readonly CategoryProductContext context;

        public CategoryProductRepository(CategoryProductContext context)
        {
            this.context = context;
        }

        public List<CategoryProductDto> GetCategoryProduct()
        {
            Console.WriteLine(context.categoryProduct.ToList());
            return context.categoryProduct.ToList();
        }

        public CategoryProductDto CreateCategoryProduct(CategoryProductDto categoryProduct)
        {
            var createdEntity = context.Add(categoryProduct);
            context.SaveChanges();
            return createdEntity.Entity;
        }

        public List<CategoryProductDto> GetByCategoryId(long categoryId)
        {
            return context.categoryProduct.Where(e => e.categoryID == categoryId).ToList();
        }

        public List<CategoryProductDto> GetByProductId(long productId)
        {
            return context.categoryProduct.Where(e => e.productID == productId).ToList();
        }

        public CategoryProductDto? GetCategoryProductByIds(long productId, long categoryId)
        {
            return context.categoryProduct.FirstOrDefault(e => e.productID == productId && e.categoryID == categoryId);
        }

        public void DeleteByCategoryId(long categoryId)
        {
            var categoryProduct = GetByCategoryId(categoryId);

            if (categoryProduct != null)
            {
                context.Remove(categoryProduct);
                context.SaveChanges();
            }
        }

        public void DeleteByProductId(long productId)
        {
            var categoryProduct = GetByCategoryId(productId);

            if (categoryProduct != null)
            {
                context.Remove(categoryProduct);
                context.SaveChanges();
            }
        }

        public void DeleteCategoryProduct(long productId, long categoryId)
        {
            var categoryProduct = GetCategoryProductByIds(productId, categoryId);

            if (categoryProduct != null)
            {
                context.Remove(categoryProduct);
                context.SaveChanges();
            }
        }
    }
}
