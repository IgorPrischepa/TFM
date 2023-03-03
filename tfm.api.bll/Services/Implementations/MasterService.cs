using tfm.api.bll.DTO;
using tfm.api.bll.Services.Contracts;
using tfm.api.dal.Entities;
using tfm.api.dal.Repos.Contracts;
using tfm.api.exceptions;

namespace tfm.api.bll.Services.Implementations
{
    public sealed class MasterService : IMasterService
    {
        private readonly IUserRepo _users;
        private readonly IMasterRepo _masters;
        private readonly IStyleRepo _styles;
        private readonly IStylePriceRepo _stylePrices;

        public MasterService(IUserRepo userService,
                            IMasterRepo masterRepo,
                            IStylePriceRepo stylePrice,
                            IStyleRepo styleRepo)
        {
            _users = userService;
            _masters = masterRepo;
            _styles = styleRepo;
            _stylePrices = stylePrice;
        }

        public async Task<int> AddNewAsync(int id)
        {
            User? user = await _users.FindByIdAsync(id)
                            ?? throw new ArgumentException("Invalid user id.");

            return await _masters.AddNewAsync(user);
        }

        public async Task AddPriceAsync(AddMasterPriceDto newMasterPrice)
        {
            Style? targetStyle = await _styles.GetAsync(newMasterPrice.StyleId)
                            ?? throw new NotFoundException($"Style didn't finded. Check value = {newMasterPrice.StyleId}");

            Master? targetMaster = await _masters.GetAsync(newMasterPrice.MasterId)
                            ?? throw new NotFoundException($"Master didn't finded. Check value = {newMasterPrice.MasterId}");

            StylePrice stylePrice = new()
            {
                Master = targetMaster,
                Style = targetStyle,
                Price = newMasterPrice.Price
            };

            await _stylePrices.AddAsync(stylePrice);
        }

        public async Task BlockAsync(int masterId)
        {
            await _masters.BlockAsync(masterId);
        }

        public async Task DeleteAsync(int masterId)
        {
            await _masters.DeleteAsync(masterId);
        }

        public async Task DeletePriceAsync(int stylePriceId)
        {
            if (stylePriceId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(stylePriceId));
            }

            await _stylePrices.DeleteAsync(stylePriceId);
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