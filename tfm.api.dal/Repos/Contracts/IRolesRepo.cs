using tfm.api.dal.Entities;

namespace tfm.api.dal.Repos.Contracts
{
    public interface IRolesRepo
    {
        Task<int> AddAsync(Role role);

        Task<Role?> FindByNameAsync(string name);
    }
}