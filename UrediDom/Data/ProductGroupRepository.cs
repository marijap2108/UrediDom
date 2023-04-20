using UrediDom.Entities;
using UrediDom.Models;

namespace UrediDom.Data
{
    public class ProductGroupRepository : IProductGroupRepository
    {
        private readonly ProductGroupContext context;

        public ProductGroupRepository(ProductGroupContext context)
        {
            this.context = context;
        }

        public List<ProductGroupDto> GetProductGroup()
        {
            Console.WriteLine(context.productGroup.ToList());
            return context.productGroup.ToList();
        }

        public ProductGroupDto CreateProductGroup(ProductGroupDto productGroup)
        {
            var createdEntity = context.Add(productGroup);
            context.SaveChanges();
            return createdEntity.Entity;
        }

        public ProductGroupDto? GetProductGroupById(long productGroupID)
        {
            return context.productGroup.FirstOrDefault(e => e.groupID == productGroupID);
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

        public ProductGroupDto UpdateProductGroup(ProductGroupDto group, ProductGroupDto newGroup)
        {
            group.description = newGroup.description;
            context.SaveChanges();
            return group;
        }
    }
}
