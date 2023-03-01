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

        public StyleController(IStyleService styleService)
        {
            _styles = styleService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] NewStyleDto newStyle)
        {
            return Ok(await _styles.AddAsync(newStyle));
        }

        [HttpDelete("Delete/{id:min(1)}")]
        public async Task<IActionResult> DeleteAsync([FromQuery] int styleId)
        {
            await _styles.DeleteAsync(styleId);
            return Ok();
        }
    }
}