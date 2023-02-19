using Microsoft.AspNetCore.Mvc;
using tfm.api.bll.DTO;
using tfm.api.Services.Contract;

namespace tfm.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IJWTAuthService _jwtService;

        public TokenController(IJWTAuthService jWTAuth)
        {
            _jwtService = jWTAuth;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto user)
        {
            string token = await _jwtService.GenerateTokenAsync(user);

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}