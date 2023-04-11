namespace UrediDom.Data
{
    public interface IProductGroupRepository
    {
        List<ProductGroup> GetProductGroup();

        ProductGroup CreateProductGroup(ProductGroup productGroup);

        ProductGroup? GetProductGroupById(long productGroupID);

        void DeleteProductGroup(long productGroupID);

        ProductGroup UpdateProductGroup(ProductGroup group, ProductGroup newGroup);
    }
}
