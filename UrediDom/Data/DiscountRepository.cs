using UrediDom.Entities;
using UrediDom.Models;

namespace UrediDom.Data
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly DiscountContext context;

        public DiscountRepository(DiscountContext context)
        {
            this.context = context;
        }

        public List<DiscountDto> GetDiscount()
        {
            Console.WriteLine(context.discount.ToList());
            return context.discount.ToList();
        }

        public DiscountDto CreateDiscount(DiscountDto discount)
        {
            var createdEntity = context.Add(discount);
            context.SaveChanges();
            return createdEntity.Entity;
        }

        public DiscountDto? GetDiscountById(long discountID)
        {
            return context.discount.FirstOrDefault(e => e.discountID == discountID);
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

        public DiscountDto UpdateDiscount(DiscountDto discount, DiscountDto newDiscount)
        {
            discount.discountProcent = newDiscount.discountProcent;
            discount.discountName = newDiscount.discountName;
            discount.discountDescription = newDiscount.discountDescription;
            discount.startDay = newDiscount.startDay;
            discount.startMonth = newDiscount.startMonth;
            discount.endDay = newDiscount.endDay;
            discount.endMonth = newDiscount.endMonth;
            context.SaveChanges();
            return discount;
        }
    }
}
