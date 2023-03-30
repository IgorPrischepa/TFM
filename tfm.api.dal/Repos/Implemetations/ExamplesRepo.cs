using Microsoft.EntityFrameworkCore;
using tfm.api.dal.Db;
using tfm.api.dal.Entities;
using tfm.api.dal.Repos.Contracts;

namespace tfm.api.dal.Repos.Implemetations
{
    public sealed class ExamplesRepo : IExamplesRepo
    {
        private readonly ApplicationDbContext _db;

        public ExamplesRepo(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }
        public async Task<int> AddAsync(ExampleEntity exampleEntity)
        {
            if (exampleEntity is null)
            {
                throw new ArgumentNullException(nameof(exampleEntity));
            }

            await _db.Examples.AddAsync(exampleEntity);
            await _db.SaveChangesAsync();

            return exampleEntity.Id;
        }

        public async Task DeleteAsync(int Id)
        {
            ExampleEntity? example = await _db.Examples.FirstOrDefaultAsync(_ => _.Id == Id);

            if (example != null)
            {
                _db.Examples.Remove(example);
                await _db.SaveChangesAsync();
            }
        }
    }
}