using UrediDom.Models;

namespace UrediDom.Data
{
    public interface IDiscountRepository
    {
        List<DiscountDto> GetDiscount();

        DiscountDto CreateDiscount(DiscountDto discount);

        DiscountDto? GetDiscountById(long discountID);

        void DeleteDiscount(long discountID);

        DiscountDto UpdateDiscount(DiscountDto discount, DiscountDto newDiscount);
    }
}
