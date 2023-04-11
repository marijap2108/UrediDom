namespace UrediDom.Data
{
    public interface ICategoryProductRepository
    {
        List<CategoryProduct> GetCategoryProduct();

        CategoryProduct CreateCategoryProduct(CategoryProduct categoryProduct);

        List<CategoryProduct> GetByCategoryId(long categoryId);

        List<CategoryProduct> GetByProductId(long productId);

        CategoryProduct? GetCategoryProductByIds(long productId, long categoryId);

        void DeleteByCategoryId(long categoryId);

        void DeleteByProductId(long productId);

        void DeleteCategoryProduct(long productId, long categoryId);
    }
}
