using Microsoft.Extensions.Logging;
using tfm.api.bll.DTO;
using tfm.api.bll.Services.Contracts;
using tfm.api.dal.Entities;
using tfm.api.dal.Repos.Contracts;

namespace tfm.api.bll.Services.Implementations
{
    public sealed class StyleService : IStyleService
    {
        private readonly IStyleRepo _styles;
        private readonly ILogger<StyleService> _logger;

        public StyleService(IStyleRepo styleRepo, ILogger<StyleService> logger)
        {
            _styles = styleRepo;
            _logger = logger;
        }

        public async Task<int> AddAsync(AddStyleDto newStyle)
        {
            if (newStyle is null)
            {
                throw new ArgumentNullException(nameof(newStyle));
            }

            return await _styles.AddAsync(new RoleEntity() { Name = newStyle.StyleName });
        }

        public async Task DeleteAsync(int styleId)
        {
            _logger.LogInformation("Start deleting style.");

            await _styles.DeleteAsync(styleId);

            _logger.LogInformation("Style has been deleted.");
        }
    }
}