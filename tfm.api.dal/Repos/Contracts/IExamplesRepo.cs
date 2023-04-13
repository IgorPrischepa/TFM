using tfm.api.dal.Entities;

namespace tfm.api.dal.Repos.Contracts
{
    public interface IExamplesRepo
    {
        Task<int> AddAsync(ExampleEntity exampleEntity);
        
        Task<int> CountAsync(int masterId, int styleId);
        
        Task DeleteAsync(int id);
        
        Task<ExampleEntity?> GetAsync(int exampleId);
        
        Task UpdateAsync(ExampleEntity example);
    }
}