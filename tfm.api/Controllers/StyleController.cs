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

        public StyleController(IStyleService styleService, ILogger<StyleController> logger)
        {
            _styles = styleService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] AddStyleDto newStyle)
        {
            _logger.LogInformation("Add new style executing");

            await _styles.AddAsync(new AddStyleModel()
            {
                StyleName = newStyle.StyleName
            });

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