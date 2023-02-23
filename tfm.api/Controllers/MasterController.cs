using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tfm.api.bll.Services.Contracts;

namespace tfm.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private readonly IMasterService _masterService;

        public MasterController(IMasterService masterService)
        {
            _masterService = masterService;
        }


        [Authorize(Policy = "Admin")]
        [HttpPost("Add/{userId:min(1)}")]
        public async Task<IActionResult> AddMasterAsync(int userId)
        {
            try
            {
                return Ok(await _masterService.AddNewAsync(userId));
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete("Delete/{userId:min(1)}")]
        public async Task<IActionResult> DeleteMasterAsync(int userId)
        {
            try
            {
                await _masterService.DeleteAsync(userId);
                return Ok();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
        }
    }
}