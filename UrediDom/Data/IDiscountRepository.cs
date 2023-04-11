namespace UrediDom.Data
{
    public interface IDiscountRepository
    {
        List<Discount> GetDiscount();

        Discount CreateDiscount(Discount discount);

        Discount? GetDiscountById(long discountID);

        void DeleteDiscount(long discountID);

        Discount UpdateDiscount(Discount discount, Discount newDiscount);
    }
}
