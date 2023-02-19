using tfm.api.bll.DTO;

namespace tfm.api.Services.Contract
{
    public interface IJWTAuthService
    {
        /// <summary>
        /// Generate JWT token for user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<string> GenerateTokenAsync(LoginDto user);
    }
}
