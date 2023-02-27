using Microsoft.Extensions.Logging;
using tfm.api.bll.DTO;
using tfm.api.bll.Services.Contracts;
using tfm.api.dal.Repos.Contracts;
using tfm.api.dal.Entities;

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

        public Task<int> AddAsync(NewStyleDto newStyle)
        {
            if (newStyle is null)
            {
                throw new ArgumentNullException(nameof(newStyle));
            }

            return _styles.AddAsync(new Role() { Name = newStyle.StyleName });
        }

        public Task DeleteAsync(int styleId)
        {
            _logger.LogInformation("Start deleting style.");

            _styles.DeleteAsync(styleId);

            _logger.LogInformation("Style has been deleted.");

            return Task.CompletedTask;
        }
    }
}