using Microsoft.EntityFrameworkCore;
using tfm.api.dal.Db;
using tfm.api.dal.Entities;
using tfm.api.dal.Repos.Contracts;
using tfm.api.exceptions;

namespace tfm.api.dal.Repos.Implementation
{
    public sealed class StylePriceRepo : IStylePriceRepo
    {
        private readonly ApplicationDbContext _db;

        public StylePriceRepo(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<int> AddAsync(StylePriceEntity stylePrice)
        {
            if (stylePrice is null)
            {
                throw new ArgumentNullException(nameof(stylePrice));
            }

            await _db.StylePrices.AddAsync(stylePrice);

            await _db.SaveChangesAsync();

            return stylePrice.Id;
        }

        public async Task DeleteAsync(int stylePriceId)
        {
            if (stylePriceId <= 0) throw new ArgumentOutOfRangeException(nameof(stylePriceId));
            
            StylePriceEntity? entity = await _db.StylePrices.FirstOrDefaultAsync(_ => _.Id == stylePriceId)
                                       ?? throw new NotFoundException($"StylePriceId = {stylePriceId}. Can't find specified item.");

            _db.StylePrices.Remove(entity);

            await _db.SaveChangesAsync();
        }

        public async Task<bool> IsExistAsync(int masterId, int styleId)
        {
            if (masterId <= 0) throw new ArgumentOutOfRangeException(nameof(masterId));
            
            return await _db.StylePrices.AnyAsync(_ => _.MasterId == masterId && _.StyleId == styleId);
        }
    }
}