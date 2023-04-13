using tfm.api.bll.DTO.Style;

namespace tfm.api.bll.Services.Contracts
{
    public interface IStyleService
    {
        Task<int> AddAsync(AddStyleDto newStyle);

        Task DeleteAsync(int styleId);
    }
}
