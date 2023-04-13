
using Microsoft.EntityFrameworkCore;
using tfm.api.dal.Db;
using tfm.api.dal.Entities;
using tfm.api.dal.Repos.Contracts;

namespace tfm.api.dal.Repos.Implementations
{
    public sealed class RoleRepo : IRolesRepo
    {
        private readonly ApplicationDbContext _db;

        public RoleRepo(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<int> AddAsync(RoleEntity role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }

            await _db.AddAsync(role);
            await _db.SaveChangesAsync();

            return role.Id;
        }

        public async Task<RoleEntity?> FindByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));
            }

            return await _db.Roles.FirstOrDefaultAsync(_ => _.Name == name);
        }
    }
}
