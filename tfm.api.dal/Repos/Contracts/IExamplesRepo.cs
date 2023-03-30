using tfm.api.dal.Entities;

namespace tfm.api.dal.Repos.Contracts
{
    public interface IExamplesRepo
    {
        Task<int> AddAsync(ExampleEntity exampleEntity);

        Task DeleteAsync(int Id);
    }
}