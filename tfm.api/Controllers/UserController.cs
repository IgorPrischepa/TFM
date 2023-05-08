using AutoMapper;
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
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] AddUserDto user)
        {
            try
            {
                _logger.LogInformation("User registration start");

                await _userService.RegisterUserAsync(_mapper.Map<AddUserModel>(user));

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
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
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