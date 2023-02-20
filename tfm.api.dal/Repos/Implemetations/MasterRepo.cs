using Microsoft.EntityFrameworkCore;
using tfm.api.dal.Db;
using tfm.api.dal.Entities;
using tfm.api.dal.Repos.Contracts;

namespace tfm.api.dal.Repos.Implemetations
{
    public class MasterRepo : IMasterRepo
    {
        private readonly ApplicationDbContext _db;

        public MasterRepo(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<int> AddNewAsync(User user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            Master newMaster = new()
            {
                User = user
            };

            await _db.Masters.AddAsync(newMaster);

            return newMaster.Id;
        }

        public async Task BlockAsync(int masterId)
        {
            Master? targetMaster = _db.Masters.FirstOrDefault(_ => _.Id == masterId);

            if (targetMaster != null)
            {
                targetMaster.IsBlocked = true;
                await _db.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int masterId)
        {
            Master? targetMaster = _db.Masters.FirstOrDefault(_ => _.Id == masterId);

            if (targetMaster != null)
            {
                _db.Masters.Remove(targetMaster);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<bool> IsBlockedAsync(int masterId)
        {
            return await _db.Masters.AsNoTracking().Where(_ => _.Id == masterId).Select(_ => _.IsBlocked).FirstAsync();
        }

        public async Task UnblockAsync(int masterId)
        {
            Master? targetMaster = _db.Masters.FirstOrDefault(_ => _.Id == masterId);

            if (targetMaster != null)
            {
                targetMaster.IsBlocked = false;
                await _db.SaveChangesAsync();
            }
        }
    }
}