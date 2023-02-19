using tfm.api.bll.DTO;

namespace tfm.api.Services.Contract
{
    public interface IJWTAuthService
    {
        Task<string> GenerateTokenAsync(LoginUserDto user);
    }
}
