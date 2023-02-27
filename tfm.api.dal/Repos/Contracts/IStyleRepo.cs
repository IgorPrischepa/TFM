using tfm.api.dal.Entities;

namespace tfm.api.dal.Repos.Contracts
{
    public interface IStyleRepo
    {
        Task<int> AddAsync(Role newStyle);

        Task DeleteAsync(int roleId);
    }
}