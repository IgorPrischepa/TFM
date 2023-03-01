using tfm.api.dal.Entities;

namespace tfm.api.dal.Repos.Contracts
{
    public interface IStylePriceRepo
    {
        Task<int> AddAsync(StylePrice stylePrice);

        Task DeleteAsync(int stylePriceid);
    }
}