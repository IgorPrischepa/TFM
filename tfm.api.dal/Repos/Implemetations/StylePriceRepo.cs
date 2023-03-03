﻿using Microsoft.EntityFrameworkCore;
using tfm.api.dal.Db;
using tfm.api.dal.Entities;
using tfm.api.dal.Repos.Contracts;

namespace tfm.api.dal.Repos.Implemetations
{
    public sealed class StylePriceRepo : IStylePriceRepo
    {
        private readonly ApplicationDbContext _db;

        public StylePriceRepo(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<int> AddAsync(StylePrice stylePrice)
        {
            if (stylePrice is null)
            {
                throw new ArgumentNullException(nameof(stylePrice));
            }

            await _db.StylePrices.AddAsync(stylePrice);

            await _db.SaveChangesAsync();

            return stylePrice.Id;
        }

        public async Task DeleteAsync(int stylePriceid)
        {
            StylePrice? entity = await _db.StylePrices.FirstOrDefaultAsync(_ => _.Id == stylePriceid)
                                ?? throw new NotFoundException($"StylePriceId = {stylePriceid}. Can't find specified item.");

            _db.StylePrices.Remove(entity);

            await _db.SaveChangesAsync();
        }
    }
}