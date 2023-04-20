using UrediDom.Entities;
using UrediDom.Models;

namespace UrediDom.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext context;

        public CustomerRepository(CustomerContext context)
        {
            this.context = context;
        }

        public List<CustomerDto> GetCustomer()
        {
            Console.WriteLine(context.customer.ToList());
            return context.customer.ToList();
        }

        public CustomerDto CreateCustomer(CustomerDto customer)
        {
            var createdEntity = context.Add(customer);
            context.SaveChanges();
            return createdEntity.Entity;
        }

        public CustomerDto? GetCustomerById(long customerID)
        {
            return context.customer.FirstOrDefault(e => e.customerID == customerID);
        }

        public void DeleteCustomer(long customerID)
        {
            var customer = GetCustomerById(customerID);

            if (customer != null)
            {
                context.Remove(customer);
                context.SaveChanges();
            }
        }

        public CustomerDto UpdateCustomer(CustomerDto customer, CustomerDto newCustomer)
        {
            customer.address = newCustomer.address;
            context.SaveChanges();
            return customer;
        }
    }
}
