using tfm.api.dal.Entities;

namespace tfm.api.dal.Repos.Contracts
{
    public interface IUserRepo
    {
        Task<int> AddAsync(User user);

        Task UpdateAsync(User user);

        Task DeleteAsync(User user);

        Task DeleteAsync(int userId);

        /// <summary>
        /// Tries to find a user who is equal to provided an email.
        /// <param name="email"></param>
        /// <returns>If finded  returns <see cref="User"></see>, otherwise null</returns>
        Task<User?> FindByEmailAsync(string email);
    }
}