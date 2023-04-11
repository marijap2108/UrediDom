using UrediDom.Entities;

namespace UrediDom.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext context;

        public CustomerRepository(CustomerContext context)
        {
            this.context = context;
        }

        public List<Customer> GetCustomer()
        {
            Console.WriteLine(context.Customer.ToList());
            return context.Customer.ToList();
        }

        public Customer CreateCustomer(Customer customer)
        {
            var createdEntity = context.Add(customer);
            context.SaveChanges();
            return createdEntity.Entity;
        }

        public Customer? GetCustomerById(long customerID)
        {
            return context.Customer.FirstOrDefault(e => e.CustomerID == customerID);
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

        public Customer UpdateCustomer(Customer customer, Customer newCustomer)
        {
            customer.Address = newCustomer.Address;
            context.SaveChanges();
            return customer;
        }
    }
}
