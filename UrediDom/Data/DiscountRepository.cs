using UrediDom.Entities;

namespace UrediDom.Data
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly DiscountContext context;

        public DiscountRepository(DiscountContext context)
        {
            this.context = context;
        }

        public List<Discount> GetDiscount()
        {
            Console.WriteLine(context.Discount.ToList());
            return context.Discount.ToList();
        }

        public Discount CreateDiscount(Discount discount)
        {
            var createdEntity = context.Add(discount);
            context.SaveChanges();
            return createdEntity.Entity;
        }

        public Discount? GetDiscountById(long discountID)
        {
            return context.Discount.FirstOrDefault(e => e.DiscountID == discountID);
        }

        public void DeleteDiscount(long discountID)
        {
            var discount = GetDiscountById(discountID);

            if (discount != null)
            {
                context.Remove(discount);
                context.SaveChanges();
            }
        }

        public Discount UpdateDiscount(Discount discount, Discount newDiscount)
        {
            discount.DiscountProcent = newDiscount.DiscountProcent;
            discount.DiscountName = newDiscount.DiscountName;
            discount.DiscountDescription = newDiscount.DiscountDescription;
            discount.StartDay = newDiscount.StartDay;
            discount.StartMonth = newDiscount.StartMonth;
            discount.EndDay = newDiscount.EndDay;
            discount.EndMonth = newDiscount.EndMonth;
            context.SaveChanges();
            return discount;
        }
    }
}
