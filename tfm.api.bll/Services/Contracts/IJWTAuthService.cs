using tfm.api.bll.Models.User;

namespace tfm.api.bll.Services.Contract
{
    public interface IJWTAuthService
    {
        Task<string> GenerateTokenAsync(LoginUserModel user);
    }
}
