namespace UrediDom.Data
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomer();

        Customer CreateCustomer(Customer customer);

        Customer? GetCustomerById(long customerID);

        void DeleteCustomer(long customerID);

        Customer UpdateCustomer(Customer customer, Customer newCustomer);
    }
}
