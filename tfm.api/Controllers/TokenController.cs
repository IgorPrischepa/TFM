using Microsoft.AspNetCore.Mvc;
using tfm.api.bll.DTO;
using tfm.api.bll.Services.Contract;

namespace tfm.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IJWTAuthService _jwtService;
        private readonly ILogger<TokenController> _logger;

        public TokenController(IJWTAuthService jWTAuth, ILogger<TokenController> logger)
        {
            _jwtService = jWTAuth;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUserDto user)
        {
            try
            {
                string token = await _jwtService.GenerateTokenAsync(user);

                _logger.LogInformation("The token has been successfully generated.");
                return Ok(token);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError("{Message}\n{StackTrace}", ex.Message, ex.StackTrace);
                return Unauthorized();
            }
        }
    }
}