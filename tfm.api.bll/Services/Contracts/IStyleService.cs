using tfm.api.bll.Models.Style;

namespace tfm.api.bll.Services.Contracts
{
    public interface IStyleService
    {
        Task<int> AddAsync(AddStyleModel newStyle);

        Task DeleteAsync(int styleId);
    }
}
