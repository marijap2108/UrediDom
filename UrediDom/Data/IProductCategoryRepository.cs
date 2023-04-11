namespace UrediDom.Data
{
    public interface IProductCategoryRepository
    {
        List<ProductCategory> GetProductCategory();

        ProductCategory CreateProductCategory(ProductCategory productCategory);

        ProductCategory? GetProductCategoryById(long productCategoryID);

        void DeleteProductCategory(long productCategoryID);

        ProductCategory UpdateProductCategory(ProductCategory category, ProductCategory newCategory);
    }
}
