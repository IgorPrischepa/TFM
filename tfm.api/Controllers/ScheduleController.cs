using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tfm.api.bll.DTO.Schedule;
using tfm.api.bll.Services.Contracts;

namespace tfm.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;
        private readonly ILogger<ScheduleController> _logger;

        public ScheduleController(IScheduleService scheduleService, ILogger<ScheduleController> logger)
        {
            _scheduleService = scheduleService;
            _logger = logger;
        }

        [Authorize(Policy = "Master")]
        [HttpPost("AddScheduleDay")]
        public async Task<IActionResult> AddScheduleDayAsync(AddScheduleDayDto addScheduleDayDto)
        {
            if (addScheduleDayDto == null) throw new ArgumentNullException(nameof(addScheduleDayDto));

            try
            {
                int scheduleId = await _scheduleService.AddAsync(addScheduleDayDto);
                return Ok(scheduleId.ToString());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return BadRequest();
            }
        }

        [Authorize(Policy = "Master")]
        [HttpPost("AddScheduleBlocker")]
        public async Task<IActionResult> AddScheduleBlockerAsync(AddScheduleBlockerDto addScheduleBlockerDto)
        {
            if (addScheduleBlockerDto == null) throw new ArgumentNullException(nameof(addScheduleBlockerDto));

            try
            {
                int scheduleId = await _scheduleService.AddBlockerAsync(addScheduleBlockerDto);
                return Ok(scheduleId.ToString());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return BadRequest();
            }
        }

        [Authorize(Policy = "Master")]
        [HttpDelete("DeleteScheduleBlocker")]
        public async Task<IActionResult> DeleteScheduleBlockerAsync(int blockerId)
        {
            try
            {
                await _scheduleService.DeleteBlockerAsync(blockerId);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return BadRequest();
            }
        }

        [Authorize(Policy = "Master")]
        [HttpGet("GetBlocker")]
        public async Task<IActionResult> GetBlockerAsync(int blockerId)
        {
            try
            {
                ShowScheduleBlockerDto? blockerDto = await _scheduleService.GetBlockerAsync(blockerId);
                return Ok(blockerDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return BadRequest();
            }
        }

        [Authorize(Policy = "Master")]
        [HttpGet("GetMasterBlockers")]
        public async Task<IActionResult> GetMasterBlockersAsync(int masterId)
        {
            try
            {
                List<ShowScheduleBlockerDto> blockersDto = await _scheduleService.GetMasterBlockersAsync(masterId);
                return Ok(blockersDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return BadRequest();
            }
        }

        [Authorize(Policy = "Master")]
        [HttpGet("GetScheduleDay")]
        public async Task<IActionResult> GetScheduleDayAsync(int scheduleId)
        {
            try
            {
                ShowScheduleDto? blockersDto = await _scheduleService.GetAsync(scheduleId);
                return Ok(blockersDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return BadRequest();
            }
        }

        [Authorize(Policy = "Master")]
        [HttpDelete("DeleteSchedule")]
        public async Task<IActionResult> DeleteScheduleAsync(int scheduleId)
        {
            try
            {
                await _scheduleService.DeleteAsync(scheduleId);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return BadRequest();
            }
        }
    }
}