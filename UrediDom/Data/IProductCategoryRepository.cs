using UrediDom.Models;

namespace UrediDom.Data
{
    public interface IProductCategoryRepository
    {
        List<ProductCategoryDto> GetProductCategory();

        ProductCategoryDto CreateProductCategory(ProductCategoryDto productCategory);

        ProductCategoryDto? GetProductCategoryById(long productCategoryID);

        void DeleteProductCategory(long productCategoryID);

        ProductCategoryDto UpdateProductCategory(ProductCategoryDto category, ProductCategoryDto newCategory);
    }
}
