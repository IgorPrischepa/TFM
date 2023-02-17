using tfm.api.dal.Entities;

namespace tfm.api.dal.Repos.Contracts
{
    public interface IUserRepo
    {
        /// <summary>
        /// Add new user and save to DB
        /// </summary>
        /// <param name="user"></param>
        /// <returns>User Id if successfull</returns>
        Task<int> AddAsync(User user);

        /// <summary>
        /// Update data in User
        /// </summary>
        /// <param name="user">Object with modified data</param>
        /// <returns></returns>
        Task UpdateAsync(User user);

        /// <summary>
        /// Delete specified user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task DeleteAsync(User user);

        /// <summary>
        /// Delete user by Id
        /// </summary>
        /// <param name="userId">Target user</param>
        /// <returns></returns>
        Task DeleteAsync(int userId);
    }
}
