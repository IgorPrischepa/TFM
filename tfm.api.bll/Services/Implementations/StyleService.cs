using AutoMapper;
using Microsoft.Extensions.Logging;
using tfm.api.bll.Models.Style;
using tfm.api.bll.Services.Contracts;
using tfm.api.dal.Entities;
using tfm.api.dal.Repos.Contracts;

namespace tfm.api.bll.Services.Implementations
{
    internal sealed class StyleService : IStyleService
    {
        private readonly IStyleRepo _styles;
        private readonly ILogger<StyleService> _logger;
        private readonly IMapper _mapper;

        public StyleService(IStyleRepo styleRepo, IMapper mapper, ILogger<StyleService> logger)
        {
            _styles = styleRepo;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(AddStyleModel newStyle)
        {
            return await _styles.AddAsync(_mapper.Map<StyleEntity>(newStyle));
        }

        public async Task DeleteAsync(int styleId)
        {
            _logger.LogInformation("Start deleting style");

            await _styles.DeleteAsync(styleId);

            _logger.LogInformation("Style has been deleted");
        }
    }
}