using tfm.api.bll.Models.Example;
using tfm.api.bll.Services.Contracts;
using tfm.api.dal.Entities;
using tfm.api.dal.Repos.Contracts;
using tfm.api.exceptions;

namespace tfm.api.bll.Services.Implementations
{
    internal sealed class ExamplesService : IExamplesService
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

        public async Task<ExampleDto?> GetAsync(int exampleId)
        {
            ExampleEntity? example = await _examples.GetAsync(exampleId);

            if (example == null) return null;

            return new ExampleDto()
            {
                MasterId = example.MasterId,
                StyleId = example.StyleId,
                PhotoFileId = example.PhotoFileId,
                ShortDescription = example.ShortDescription,
                Id = example.Id
            };
        }

        public async Task DeleteAsync(int exampleId)
        {
            if (exampleId <= 0) throw new ArgumentOutOfRangeException(nameof(exampleId));

            await _examples.DeleteAsync(exampleId);
        }

        public async Task AttachPhotoAsync(int exampleId, int photoId)
        {
            ExampleEntity? example = await _examples.GetAsync(exampleId);

            if (example == null) throw new NotFoundException($"Can't find example with id = {photoId}");

            example.PhotoFileId = photoId;

            await _examples.UpdateAsync(example);
        }
    }
}