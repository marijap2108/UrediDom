using UrediDom.Models;

namespace UrediDom.Data
{
    public interface ITypeOfProductRepository
    {
        List<TypeOfProductDto> GetTypeOfProduct();

        TypeOfProductDto CreateTypeOfProduct(TypeOfProductDto typeOfProduct);

        TypeOfProductDto? GetTypeOfProductById(long typeID);

        void DeleteTypeOfProduct(long typeID);

        TypeOfProductDto UpdateTypeOfProduct(TypeOfProductDto type, TypeOfProductDto newType);
    }
}
