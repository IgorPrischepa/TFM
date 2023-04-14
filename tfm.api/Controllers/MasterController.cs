using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tfm.api.bll.DTO.Example;
using tfm.api.bll.DTO.Master;
using tfm.api.bll.Services.Contracts;

namespace tfm.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private readonly IMasterService _masterService;
        private readonly ILogger<MasterController> _logger;

        public MasterController(IMasterService masterService, ILogger<MasterController> logger)
        {
            _masterService = masterService;
            _logger = logger;
        }

        [Authorize(Policy = "Admin")]
        [HttpPost("Add/{userId:min(1)}")]
        public async Task<IActionResult> AddMasterAsync(int userId)
        {
            try
            {
                var masterId = await _masterService.AddNewAsync(userId);
                return Ok(masterId.ToString());
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
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
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return BadRequest();
            }
        }

        [Authorize(Policy = "Master")]
        [HttpPost("AddPrice")]
        public async Task<IActionResult> AddPriceAsync(AddMasterPriceDto masterPrice)
        {
            try
            {
                await _masterService.AddPriceAsync(masterPrice);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return BadRequest();
            }
        }

        [Authorize(Policy = "Master")]
        [HttpDelete("DeletePrice")]
        public async Task<IActionResult> DeletePriceAsync(int stylePrice)
        {
            try
            {
                await _masterService.DeletePriceAsync(stylePrice);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return BadRequest();
            }
        }

        [Authorize(Policy = "Master")]
        [HttpPost("AddExample"), DisableRequestSizeLimit]
        public async Task<IActionResult> AddExampleAsync([FromForm] AddMasterExampleDto masterExample)
        {
            try
            {
                if (masterExample.ExamplePhoto == null || (masterExample.ExamplePhoto.Length == 0))
                {
                    return BadRequest("No file is selected or the file is empty.");
                }

                await _masterService.AddExampleAsync(masterExample);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return BadRequest();
            }
        }

        [Authorize(Policy = "ExampleEditor")]
        [HttpDelete("DeleteExample")]
        public async Task<IActionResult> DeleteExampleAsync(int exampleId)
        {
            try
            {
                if (exampleId <= 0)
                {
                    return BadRequest();
                }

                await _masterService.DeleteExampleAsync(exampleId);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return BadRequest();
            }
        }

        [Authorize(Policy = "PublicData")]
        [HttpGet("GetExample")]
        public async Task<IActionResult> GetExampleAsync(int exampleId)
        {
            try
            {
                if (exampleId <= 0)
                {
                    return BadRequest();
                }

                ShowExampleDto? example = await _masterService.GetExampleAsync(exampleId);

                return Ok(example);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return BadRequest();
            }
        }
    }
}