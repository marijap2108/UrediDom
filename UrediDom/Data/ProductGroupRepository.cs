using UrediDom.Entities;

namespace UrediDom.Data
{
    public class ProductGroupRepository : IProductGroupRepository
    {
        private readonly ProductGroupContext context;

        public ProductGroupRepository(ProductGroupContext context)
        {
            this.context = context;
        }

        public List<ProductGroup> GetProductGroup()
        {
            Console.WriteLine(context.ProductGroup.ToList());
            return context.ProductGroup.ToList();
        }

        public ProductGroup CreateProductGroup(ProductGroup productGroup)
        {
            var createdEntity = context.Add(productGroup);
            context.SaveChanges();
            return createdEntity.Entity;
        }

        public ProductGroup? GetProductGroupById(long productGroupID)
        {
            return context.ProductGroup.FirstOrDefault(e => e.GroupID == productGroupID);
        }

        public void DeleteProductGroup(long productGroupID)
        {
            var group = GetProductGroupById(productGroupID);

            if (group != null)
            {
                context.Remove(group);
                context.SaveChanges();
            }
        }

        public ProductGroup UpdateProductGroup(ProductGroup group, ProductGroup newGroup)
        {
            group.Description = newGroup.Description;
            context.SaveChanges();
            return group;
        }
    }
}
