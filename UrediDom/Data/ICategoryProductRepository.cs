using UrediDom.Models;

namespace UrediDom.Data
{
    public interface ICategoryProductRepository
    {
        List<CategoryProductDto> GetCategoryProduct();

        CategoryProductDto CreateCategoryProduct(CategoryProductDto categoryProduct);

        List<CategoryProductDto> GetByCategoryId(long categoryId);

        List<CategoryProductDto> GetByProductId(long productId);

        CategoryProductDto? GetCategoryProductByIds(long productId, long categoryId);

        void DeleteByCategoryId(long categoryId);

        void DeleteByProductId(long productId);

        void DeleteCategoryProduct(long productId, long categoryId);
    }
}
