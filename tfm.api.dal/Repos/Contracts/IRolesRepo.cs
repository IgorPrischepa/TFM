using tfm.api.dal.Entities;

namespace tfm.api.dal.Repos.Contracts
{
    public interface IRolesRepo
    {
        Task<int> AddAsync(RoleEntity role);

        Task<RoleEntity?> FindByNameAsync(string name);
    }
}