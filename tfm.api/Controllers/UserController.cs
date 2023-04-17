using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tfm.api.bll.Models.User;
using tfm.api.bll.Services.Contracts;
using tfm.api.Dto.User;

namespace tfm.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] AddUserDto user)
        {
            try
            {
                _logger.LogInformation("User registration start");

                await _userService.RegisterUserAsync(new AddUserModel
                {
                    Email = user.Email,
                    FirstName = user.FirstName,
                    MiddleName = user.MiddleName,
                    LastName = user.LastName,
                    Password = user.Password
                });

                _logger.LogInformation("User has been registered");

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message}{NewLine}{StackTrace}", ex.Message, Environment.NewLine, ex.StackTrace);
            }
            
            return BadRequest();
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete("Delete/{id:min(1)}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                _logger.LogInformation("User deleting start");

                await _userService.DeleteAsync(id);

                _logger.LogInformation("User has been deleted");

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message}{NewLine}{StackTrace}", ex.Message, Environment.NewLine, ex.StackTrace);
            }
            
            return BadRequest();
        }
    }
}