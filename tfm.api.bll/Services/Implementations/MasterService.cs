using tfm.api.bll.Services.Contracts;
using tfm.api.dal.Entities;
using tfm.api.dal.Repos.Contracts;

namespace tfm.api.bll.Services.Implementations
{
    public sealed class MasterService : IMasterService
    {
        private readonly IUserRepo _users;
        private readonly IMasterRepo _masters;

        public MasterService(IUserRepo userService, IMasterRepo masterRepo)
        {
            _users = userService;
            _masters = masterRepo;
        }

        public async Task<int> AddNewAsync(int id)
        {
            User? user = await _users.FindByIdAsync(id);

            if (user == null)
            {
                throw new ArgumentException("Invalid user id.");
            }

            return await _masters.AddNewAsync(user);
        }

        public async Task BlockAsync(int masterId)
        {
            await _masters.BlockAsync(masterId);
        }

        public async Task DeleteAsync(int masterId)
        {
            await _masters.DeleteAsync(masterId);
        }

        public Task<bool> IsBlockedAsync(int masterId)
        {
            return _masters.IsBlockedAsync(masterId);
        }

        public async Task UnblockAsync(int masterId)
        {
            await _masters.UnblockAsync(masterId);
        }
    }
}