using tfm.api.dal.Entities;

namespace tfm.api.dal.Repos.Contracts
{
    public interface IUserRepo
    {
        Task<int> AddAsync(UserEntity user);

        Task UpdateAsync(UserEntity user);

        Task DeleteAsync(UserEntity user);

        Task DeleteAsync(int userId);

        Task<UserEntity?> FindByEmailAsync(string email);

        Task<UserEntity?> FindByIdAsync(int Id);
    }
}