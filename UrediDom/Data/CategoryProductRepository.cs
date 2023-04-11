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

        public List<CategoryProduct> GetCategoryProduct()
        {
            Console.WriteLine(context.CategoryProduct.ToList());
            return context.CategoryProduct.ToList();
        }

        public CategoryProduct CreateCategoryProduct(CategoryProduct categoryProduct)
        {
            var createdEntity = context.Add(categoryProduct);
            context.SaveChanges();
            return createdEntity.Entity;
        }

        public List<CategoryProduct> GetByCategoryId(long categoryId)
        {
            return context.CategoryProduct.Where(e => e.CategoryID == categoryId).ToList();
        }

        public List<CategoryProduct> GetByProductId(long productId)
        {
            return context.CategoryProduct.Where(e => e.ProductID == productId).ToList();
        }

        public CategoryProduct? GetCategoryProductByIds(long productId, long categoryId)
        {
            return context.CategoryProduct.FirstOrDefault(e => e.ProductID == productId && e.CategoryID == categoryId);
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
