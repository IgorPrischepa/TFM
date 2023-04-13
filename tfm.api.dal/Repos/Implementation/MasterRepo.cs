using Microsoft.EntityFrameworkCore;
using tfm.api.dal.Db;
using tfm.api.dal.Entities;
using tfm.api.dal.Repos.Contracts;

namespace tfm.api.dal.Repos.Implementations
{
    public class MasterRepo : IMasterRepo
    {
        private readonly ApplicationDbContext _db;

        public MasterRepo(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<int> AddNewAsync(UserEntity user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            MasterEntity newMaster = new()
            {
                User = user,
                Avatar = Array.Empty<byte>()
            };

            await _db.Masters.AddAsync(newMaster);

            await _db.SaveChangesAsync();

            return newMaster.Id;
        }

        public async Task BlockAsync(int masterId)
        {
            MasterEntity? targetMaster = _db.Masters.FirstOrDefault(_ => _.Id == masterId)
                                         ?? throw new ArgumentException($"nameof(masterId) invalid.");

            targetMaster.IsBlocked = true;
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int masterId)
        {
            MasterEntity? targetMaster = _db.Masters.FirstOrDefault(_ => _.Id == masterId)
                                        ?? throw new ArgumentException($"nameof(masterId) invalid.");

            _db.Masters.Remove(targetMaster);
            await _db.SaveChangesAsync();
        }

        public async Task<MasterEntity?> GetAsync(int masterId)
        {
            return await _db.Masters.FirstOrDefaultAsync(_ => _.Id == masterId);
        }

        public async Task<bool> IsBlockedAsync(int masterId)
        {
            return (await _db.Masters.AsNoTracking().FirstAsync(_ => _.Id == masterId)).IsBlocked;
        }

        public async Task UnblockAsync(int masterId)
        {
            MasterEntity? targetMaster = _db.Masters.FirstOrDefault(_ => _.Id == masterId)
                                        ?? throw new ArgumentException($"nameof(masterId) invalid.");

            targetMaster.IsBlocked = false;
            await _db.SaveChangesAsync();
        }
    }
}