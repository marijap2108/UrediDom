using UrediDom.Entities;
using UrediDom.Models;

namespace UrediDom.Data
{
    public class TypeOfProductRepository : ITypeOfProductRepository
    {
        private readonly TypeOfProductContext context;

        public TypeOfProductRepository(TypeOfProductContext context)
        {
            this.context = context;
        }

        public List<TypeOfProductDto> GetTypeOfProduct()
        {
            Console.WriteLine(context.typeOfProduct.ToList());
            return context.typeOfProduct.ToList();
        }

        public TypeOfProductDto CreateTypeOfProduct(TypeOfProductDto typeOfProduct)
        {
            var createdEntity = context.Add(typeOfProduct);
            context.SaveChanges();
            return createdEntity.Entity;
        }

        public TypeOfProductDto? GetTypeOfProductById(long typeID)
        {
            return context.typeOfProduct.FirstOrDefault(e => e.typeID == typeID);
        }

        public void DeleteTypeOfProduct(long typeID)
        {
            var type = GetTypeOfProductById(typeID);

            if (type != null)
            {
                context.Remove(type);
                context.SaveChanges();
            }
        }

        public TypeOfProductDto UpdateTypeOfProduct(TypeOfProductDto type, TypeOfProductDto newType)
        {
            type.typeName = newType.typeName;
            context.SaveChanges();
            return type;
        }
    }
}
