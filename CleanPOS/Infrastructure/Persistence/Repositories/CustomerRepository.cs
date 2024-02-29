using Domain.Customers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repostories;


public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _dbContext;
    public CustomerRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        
    }
    public async Task Add(Customer customer) => await _dbContext.Customers.AddAsync(customer);
    
    public async Task<Customer?> GetCustomerById(CustomerId id) => await _dbContext.Customers.SingleOrDefaultAsync( c => c.Id == id);
    
}