using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tfm.api.bll.DTO;
using tfm.api.bll.Services.Contracts;

namespace tfm.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class StyleController : ControllerBase
    {
        private readonly IStyleService _styles;
        private readonly ILogger<StyleController> _logger;

        public StyleController(IStyleService styleService, ILogger<StyleController> logger)
        {
            _styles = styleService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] AddStyleDto newStyle)
        {
            _logger.LogInformation("Add new style executing.");

            await _styles.AddAsync(newStyle);

            _logger.LogInformation("New style has been added.");

            return Ok();
        }

        [HttpDelete("Delete/{id:min(1)}")]
        public async Task<IActionResult> DeleteAsync([FromQuery] int styleId)
        {
            _logger.LogInformation("Style is being deleted.");

            await _styles.DeleteAsync(styleId);

            _logger.LogInformation("Styel has been deleted.");

            return Ok();
        }
    }
}