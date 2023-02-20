using tfm.api.bll.DTO;

namespace tfm.api.bll.Services.Contracts
{
    public interface IUserService
    {
        Task RegisterUserAsync(NewUserDto user);
        /// Register new user
        /// </summary>
        /// <param name="user">User data object</param>
        /// <returns></returns>
        Task RegisterAsync(UserDto user);

        Task DeleteAsync(int userId);

        Task<UserDTO?> GetUserAsync(string userEmail, string password);
    }
}