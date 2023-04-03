using tfm.api.dal.Entities;

namespace tfm.api.bll.Services.Contracts
{
    public interface IExamplesService
    {
        Task<int> AddAsync(ExampleEntity exampleEntity);

        Task<int> CountAsync(int masterId, int styleId);
    }
}