using tfm.api.bll.DTO;

namespace tfm.api.bll.Services.Contracts
{
    public interface IUserService
    {
        Task RegisterUserAsync(NewUserDto user);

        Task DeleteAsync(int userId);

        Task<UserDto?> GetUserAsync(string userEmail, string password);
    }
}