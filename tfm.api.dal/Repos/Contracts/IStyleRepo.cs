using tfm.api.dal.Entities;

namespace tfm.api.dal.Repos.Contracts
{
    public interface IStyleRepo
    {
        Task<int> AddAsync(StyleEntity newStyle);

        Task DeleteAsync(int roleId);

        Task<StyleEntity?> GetAsync(int id);
    }
}