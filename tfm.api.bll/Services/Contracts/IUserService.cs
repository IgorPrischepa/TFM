using tfm.api.bll.DTO.User;

namespace tfm.api.bll.Services.Contracts
{
    public interface IUserService
    {
        Task RegisterUserAsync(AddUserDto user);

        Task DeleteAsync(int userId);

        Task<BaseUserDto?> GetUserAsync(string userEmail, string password);
    }
}