using Microsoft.AspNetCore.Mvc;
using tfm.api.bll.DTO;
using tfm.api.bll.Services.Contracts;
using tfm.api.Services.Contract;

namespace tfm.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly IJWTAuthService _jwtService;

        public TokenController(IConfiguration config, IUserService userService, IJWTAuthService jWTAuth)
        {
            _configuration = config;
            _userService = userService;
            _jwtService = jWTAuth;
        }

        [HttpPost]
        public async Task<string> Login([FromBody] LoginDto user)
        {
            return await _jwtService.GenerateTokenAsync(user);
        }
    }
}