using tfm.api.dal.Entities;

namespace tfm.api.dal.Repos.Contracts
{
    public interface IUserRepo
    {
        Task<int> AddAsync(User user);

        Task UpdateAsync(User user);

        Task DeleteAsync(User user);

        Task DeleteAsync(int userId);

        Task<User?> FindByEmailAsync(string email);

        Task<User?> FindByIdAsync(int Id);
    }
}