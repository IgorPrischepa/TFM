using tfm.api.dal.Entities;

namespace tfm.api.dal.Repos.Contracts;

public interface ICustomerRepo
{
    public Task<int> AddAsync(CustomerEntity customer);

    public Task DeleteAsync(int id);

    public Task<CustomerEntity?> FindByIdAsync(int id);
}