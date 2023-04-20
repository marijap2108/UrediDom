using UrediDom.Models;

namespace UrediDom.Data
{
    public interface ICustomerRepository
    {
        List<CustomerDto> GetCustomer();

        CustomerDto CreateCustomer(CustomerDto customer);

        CustomerDto? GetCustomerById(long customerID);

        void DeleteCustomer(long customerID);

        CustomerDto UpdateCustomer(CustomerDto customer, CustomerDto newCustomer);
    }
}
