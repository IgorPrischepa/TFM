using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tfm.api.bll.Models.Style;
using tfm.api.bll.Services.Contracts;
using tfm.api.Dto.Style;

namespace tfm.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class StyleController : ControllerBase
    {
        private readonly IStyleService _styles;
        private readonly ILogger<StyleController> _logger;
        private readonly IMapper _mapper;

        public StyleController(IStyleService styleService, IMapper mapper, ILogger<StyleController> logger)
        {
            _styles = styleService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] AddStyleDto newStyle)
        {
            _logger.LogInformation("Add new style executing");

            await _styles.AddAsync(_mapper.Map<AddStyleModel>(newStyle));

            _logger.LogInformation("New style has been added");

            return Ok();
        }

        [HttpDelete("Delete/{id:min(1)}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            _logger.LogInformation("Style is being deleted");

            await _styles.DeleteAsync(id);

            _logger.LogInformation("Style has been deleted");

            return Ok();
        }
    }
}