using tfm.api.dal.Entities;

namespace tfm.api.dal.Repos.Contracts
{
    public interface IPhotoFileRepo
    {
        Task<int> AddAsync(PhotoFileEntity photoFileEntity);

        Task DeleteAsync(int photoFileId);

        Task<PhotoFileEntity?> GetAsync(int photoId);
    }
}