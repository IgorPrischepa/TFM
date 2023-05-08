using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tfm.api.bll.Models.Example;
using tfm.api.bll.Models.Master;
using tfm.api.bll.Services.Contracts;
using tfm.api.Dto.Master;

namespace tfm.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private readonly IMasterService _masterService;
        private readonly ILogger<MasterController> _logger;
        private readonly IMapper _mapper;

        public MasterController(IMasterService masterService, IMapper mapper, ILogger<MasterController> logger)
        {
            _masterService = masterService;
            _logger = logger;
            _mapper = mapper;
        }

        [Authorize(Policy = "Admin")]
        [HttpPost("Add/{userId:min(1)}")]
        public async Task<IActionResult> AddMasterAsync([FromRoute] int userId)
        {
            try
            {
                var masterId = await _masterService.AddNewAsync(userId);
                return Ok(masterId.ToString());
            }
            catch (ArgumentException ex)
            {
                _logger.LogError("{Message}{StackTrace}", ex.Message, ex.StackTrace);
            }

            return BadRequest();
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete("Delete/{userId:min(1)}")]
        public async Task<IActionResult> DeleteMasterAsync([FromRoute] int userId)
        {
            try
            {
                await _masterService.DeleteAsync(userId);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                _logger.LogError("{Message}{StackTrace}", ex.Message, ex.StackTrace);
            }

            return BadRequest();
        }

        [Authorize(Policy = "Master")]
        [HttpPost("AddPrice")]
        public async Task<IActionResult> AddPriceAsync([FromBody] AddMasterPriceDto masterPrice)
        {
            try
            {
                await _masterService.AddPriceAsync(_mapper.Map<AddMasterPriceModel>(masterPrice));

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message}{StackTrace}", ex.Message, ex.StackTrace);
            }

            return BadRequest();
        }

        [Authorize(Policy = "Master")]
        [HttpDelete("DeletePrice/{stylePrice:min(1)}")]
        public async Task<IActionResult> DeletePriceAsync([FromRoute] int stylePrice)
        {
            try
            {
                await _masterService.DeletePriceAsync(stylePrice);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message}{StackTrace}", ex.Message, ex.StackTrace);
            }

            return BadRequest();
        }

        [Authorize(Policy = "Master")]
        [HttpPost("AddExample"), DisableRequestSizeLimit]
        public async Task<IActionResult> AddExampleAsync([FromForm] AddMasterExampleDto masterExample)
        {
            try
            {
                if (masterExample.ExamplePhoto.Length == 0)
                {
                    return BadRequest("No file is selected or the file is empty.");
                }

                await _masterService.AddExampleAsync(_mapper.Map<AddMasterExampleModel>(masterExample));

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message}{StackTrace}", ex.Message, ex.StackTrace);
            }

            return BadRequest();
        }

        [Authorize(Policy = "ExampleEditor")]
        [HttpDelete("DeleteExample/{exampleId:min(1)}")]
        public async Task<IActionResult> DeleteExampleAsync([FromRoute] int exampleId)
        {
            try
            {
                await _masterService.DeleteExampleAsync(exampleId);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message}{StackTrace}", ex.Message, ex.StackTrace);
            }

            return BadRequest();
        }

        [Authorize(Policy = "PublicData")]
        [HttpGet("GetExample/{exampleId:min(1)}")]
        public async Task<IActionResult> GetExampleAsync([FromRoute] int exampleId)
        {
            try
            {
                ShowExampleModel? example = await _masterService.GetExampleAsync(exampleId);

                return Ok(example);
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message}{StackTrace}", ex.Message, ex.StackTrace);
            }

            return BadRequest();
        }
    }
}