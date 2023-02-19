using tfm.api.dal.Entities;

namespace tfm.api.dal.Repos.Contracts
{
    public interface IRolesRepo
    {
        /// <summary>
        /// Create a new role.
        /// </summary>
        /// <param name="role"></param>
        /// <returns>If success return role Id.</returns>
        Task<int> AddAsync(Role role);

        /// <summary>
        /// Find role by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns><see cref="Role"/></returns>
        Task<Role?> FindByNameAsync(string name);
    }
}