using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tfm.api.bll.Models.Schedule;
using tfm.api.bll.Services.Contracts;
using tfm.api.Dto.Schedule;

namespace tfm.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;
        private readonly ILogger<ScheduleController> _logger;
        private readonly IMapper _mapper;

        public ScheduleController(IScheduleService scheduleService, IMapper mapper, ILogger<ScheduleController> logger)
        {
            _scheduleService = scheduleService;
            _logger = logger;
            _mapper = mapper;
        }

        [Authorize(Policy = "Master")]
        [HttpPost("AddScheduleDay")]
        public async Task<IActionResult> AddScheduleDayAsync([FromBody] AddScheduleDayDto addScheduleDayModel)
        {
            try
            {
                int scheduleId = await _scheduleService.AddAsync(_mapper.Map<AddScheduleDayModel>(addScheduleDayModel));

                return Ok(scheduleId.ToString());
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message}\n{StackTrace}", ex.Message, ex.StackTrace);
            }

            return BadRequest();
        }

        [Authorize(Policy = "Master")]
        [HttpPost("AddScheduleBlocker")]
        public async Task<IActionResult> AddScheduleBlockerAsync([FromBody] AddScheduleBlockerDto addScheduleBlockerDto)
        {
            try
            {
                int scheduleId = await _scheduleService.AddBlockerAsync(_mapper.Map<AddScheduleBlockerModel>(addScheduleBlockerDto));

                return Ok(scheduleId.ToString());
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message}\n{StackTrace}", ex.Message, ex.StackTrace);
            }

            return BadRequest();
        }

        [Authorize(Policy = "Master")]
        [HttpDelete("DeleteScheduleBlocker/{id:min(1)}")]
        public async Task<IActionResult> DeleteScheduleBlockerAsync([FromRoute] int id)
        {
            try
            {
                await _scheduleService.DeleteBlockerAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message}\n{StackTrace}", ex.Message, ex.StackTrace);
            }

            return BadRequest();
        }

        [Authorize(Policy = "Master")]
        [HttpGet("GetBlocker/{id:min(1)}")]
        public async Task<IActionResult> GetBlockerAsync([FromRoute] int id)
        {
            try
            {
                ShowScheduleBlockerModel? blockerDto = await _scheduleService.GetBlockerAsync(id);
                return Ok(blockerDto);
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message}\n{StackTrace}", ex.Message, ex.StackTrace);
            }

            return BadRequest();
        }

        [Authorize(Policy = "Master")]
        [HttpGet("GetMasterBlockers/{id:min(1)}")]
        public async Task<IActionResult> GetMasterBlockersAsync([FromRoute] int id)
        {
            try
            {
                List<ShowScheduleBlockerModel> blockersDto = await _scheduleService.GetMasterBlockersAsync(id);
                return Ok(blockersDto);
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message}\n{StackTrace}", ex.Message, ex.StackTrace);
            }

            return BadRequest();
        }

        [Authorize(Policy = "Master")]
        [HttpGet("GetScheduleDay/{id:min(1)}")]
        public async Task<IActionResult> GetScheduleDayAsync([FromRoute] int id)
        {
            try
            {
                ShowScheduleModel? blockersDto = await _scheduleService.GetAsync(id);
                return Ok(blockersDto);
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message}\n{StackTrace}", ex.Message, ex.StackTrace);
            }

            return BadRequest();
        }

        [Authorize(Policy = "Master")]
        [HttpDelete("DeleteSchedule/{id:min(1)}")]
        public async Task<IActionResult> DeleteScheduleAsync([FromRoute] int id)
        {
            try
            {
                await _scheduleService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message}\n{StackTrace}", ex.Message, ex.StackTrace);
            }

            return BadRequest();
        }
    }
}