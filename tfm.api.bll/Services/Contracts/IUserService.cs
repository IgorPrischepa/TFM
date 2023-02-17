using tfm.api.bll.DTO;

namespace tfm.api.bll.Services.Contracts
{
    public interface IUserService
    {
        /// <summary>
        /// Register new user
        /// </summary>
        /// <param name="user">User data object</param>
        /// <returns></returns>
        Task RegisterAsync(UserDto user);

        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="userId">User id</param>
        /// <returns></returns>
        Task DeleteAsync(int userId);
    }
}