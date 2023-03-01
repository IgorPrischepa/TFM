using tfm.api.bll.DTO;

namespace tfm.api.bll.Services.Contracts
{
    public interface IStyleService
    {
        Task<int> AddAsync(NewStyleDto newStyle);

        Task DeleteAsync(int styleId);
    }
}
