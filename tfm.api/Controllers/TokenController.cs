using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using tfm.api.bll.Models.User;
using tfm.api.bll.Services.Contract;
using tfm.api.Dto.User;

namespace tfm.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IJWTAuthService _jwtService;
        private readonly ILogger<TokenController> _logger;
        private readonly IMapper _mapper;

        public TokenController(IJWTAuthService jwtAuth, IMapper mapper, ILogger<TokenController> logger)
        {
            _jwtService = jwtAuth;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUserDto user)
        {
            try
            {
                string token = await _jwtService.GenerateTokenAsync(_mapper.Map<LoginUserModel>(user));

                _logger.LogInformation("The token has been successfully generated");

                return Ok(token);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError("{Message}\n{StackTrace}", ex.Message, ex.StackTrace);
            }

            return Unauthorized();
        }
    }
}