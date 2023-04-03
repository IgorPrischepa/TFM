using tfm.api.dal.Entities;

namespace tfm.api.dal.Repos.Contracts
{
    public interface IStylePriceRepo
    {
        Task<int> AddAsync(StylePriceEntity stylePrice);

        Task DeleteAsync(int stylePriceid);

        Task<bool> IsExistAsync(int masterId, int styleId);
    }
}