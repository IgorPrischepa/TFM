using Microsoft.AspNetCore.Mvc;
using tfm.api.bll.DTO;
using tfm.api.bll.Services.Contracts;

namespace tfm.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost("/Register")]
        public async Task<IActionResult> RegisterAsync(UserDto user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            try
            {
                await _userService.RegisterAsync(user);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, Environment.NewLine, ex.StackTrace);

                return BadRequest();
            }
        }

        [HttpDelete("/Delete")]
        public async Task<IActionResult> DeleteAsync(int userId)
        {
            if (userId < 0)
            {
                return BadRequest();
            }
            try
            {
                await _userService.DeleteAsync(userId);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, Environment.NewLine, ex.StackTrace);

                return BadRequest();
            }
        }
    }
}