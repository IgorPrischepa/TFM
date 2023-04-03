using tfm.api.bll.Services.Contracts;
using tfm.api.dal.Entities;
using tfm.api.dal.Repos.Contracts;

namespace tfm.api.bll.Services.Implementations
{
    public sealed class ExamplesService : IExamplesService
    {
        private readonly IExamplesRepo _examples;

        public ExamplesService(IExamplesRepo examplesRepo)
        {
            _examples = examplesRepo ?? throw new ArgumentNullException(nameof(examplesRepo));
        }

        public async Task<int> AddAsync(ExampleEntity exampleEntity)
        {
            if (exampleEntity is null)
            {
                throw new ArgumentNullException(nameof(exampleEntity));
            }

            return await _examples.AddAsync(exampleEntity);
        }

        public async Task<int> CountAsync(int masterId, int styleId)
        {
            return await _examples.CountAsync(masterId, styleId);
        }
    }
}