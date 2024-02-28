namespace Domain.Customers;

public interface ICustomerRepository
{
    Task<Customer?> GetCustomerById( CustomerId id);
    Task Add( Customer customer);

}