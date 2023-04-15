using Microsoft.EntityFrameworkCore;
using tfm.api.dal.Db;
using tfm.api.dal.Entities;
using tfm.api.dal.Repos.Contracts;

namespace tfm.api.dal.Repos.Implementation
{
    public sealed class StyleRepo : IStyleRepo
    {
        private readonly ApplicationDbContext _db;

        public StyleRepo(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<int> AddAsync(RoleEntity newStyle)
        {
            if (newStyle is null)
            {
                throw new ArgumentNullException(nameof(newStyle));
            }

            await _db.AddAsync(newStyle);

            await _db.SaveChangesAsync();

            return newStyle.Id;
        }

        public async Task DeleteAsync(int roleId)
        {
            if (roleId < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(roleId), roleId, "Role id can't be less or equal zero {}");
            }

            RoleEntity? entity = await _db.Roles.FirstOrDefaultAsync(_ => _.Id == roleId);

            if (entity != null)
            {
                _db.Roles.Remove(entity);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<StyleEntity?> GetAsync(int id)
        {
            return await _db.Styles.FirstOrDefaultAsync(_ => _.Id == id);
        }
    }
}