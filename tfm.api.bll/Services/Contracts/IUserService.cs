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
        Task RegisterUserAsync(NewUserDto user);

        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="userId">User id</param>
        /// <returns></returns>
        Task DeleteAsync(int userId);

        /// <summary>
        /// Tries to find a user who is equal to provide an email address and password.
        /// </summary>
        /// <param name="userEmail"></param>
        /// <param name="password"></param>
        /// <returns>If finded  returns <see cref="UserDTO"></see>, otherwise null</returns>
        Task<UserDTO?> GetUserAsync(string userEmail, string password);
    }
}