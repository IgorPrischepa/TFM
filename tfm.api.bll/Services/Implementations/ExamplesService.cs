using AutoMapper;
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
        private readonly IMapper _mapper;

        public ExamplesService(IExamplesRepo examplesRepo, IMapper mapper)
        {
            _examples = examplesRepo ?? throw new ArgumentNullException(nameof(examplesRepo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<int> AddAsync(ExampleModel exampleEntity)
        {
            if (exampleEntity is null)
            {
                throw new ArgumentNullException(nameof(exampleEntity));
            }

            return await _examples.AddAsync(_mapper.Map<ExampleEntity>(exampleEntity));
        }

        public async Task<int> CountAsync(int masterId, int styleId)
        {
            return await _examples.CountAsync(masterId, styleId);
        }

        public async Task<ExampleModel?> GetAsync(int exampleId)
        {
            ExampleEntity? example = await _examples.GetAsync(exampleId);

            if (example == null) return null;

            return _mapper.Map<ExampleModel>(example);
        }

        public async Task DeleteAsync(int exampleId)
        {
            if (exampleId <= 0) throw new ArgumentOutOfRangeException(nameof(exampleId));

            await _examples.DeleteAsync(exampleId);
        }

        public async Task AttachPhotoAsync(int exampleId, int photoId)
        {
            ExampleEntity? example = await _examples.GetAsync(exampleId)
                ?? throw new NotFoundException($"Can't find example with id = {photoId}");

            example.PhotoFileId = photoId;

            await _examples.UpdateAsync(example);
        }
    }
}