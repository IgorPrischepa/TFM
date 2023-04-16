using Microsoft.EntityFrameworkCore;
using tfm.api.dal.Db;
using tfm.api.dal.Entities;
using tfm.api.dal.Repos.Contracts;

namespace tfm.api.dal.Repos.Implementations;

public class CustomerRepo : ICustomerRepo
{
    private readonly ApplicationDbContext _db;

    public CustomerRepo(ApplicationDbContext dbContext)
    {
        _db = dbContext;
    }

    public async Task<int> AddAsync(CustomerEntity customer)
    {
        if (customer == null) throw new ArgumentNullException(nameof(customer));

        await _db.AddAsync(customer);

        await _db.SaveChangesAsync();

        return customer.Id;
    }

    public async Task DeleteAsync(int id)
    {
        if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));

        CustomerEntity? entity = await _db.Customers.FirstOrDefaultAsync(_ => _.Id == id);

        if (entity == null) throw new ArgumentNullException(nameof(entity));

        _db.Customers.Remove(entity);

        await _db.SaveChangesAsync();
    }

    public async Task<CustomerEntity?> FindByIdAsync(int id)
    {
        return await _db.Customers.FirstOrDefaultAsync(_ => _.Id == id);
    }
}