using UrediDom.Models;

namespace UrediDom.Data
{
    public interface IProductGroupRepository
    {
        List<ProductGroupDto> GetProductGroup();

        ProductGroupDto CreateProductGroup(ProductGroupDto productGroup);

        ProductGroupDto? GetProductGroupById(long productGroupID);

        void DeleteProductGroup(long productGroupID);

        ProductGroupDto UpdateProductGroup(ProductGroupDto group, ProductGroupDto newGroup);
    }
}
