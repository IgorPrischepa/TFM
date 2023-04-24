using tfm.api.dal.Entities;

namespace tfm.api.dal.Repos.Contracts
{
    public interface IPhotoFileRepo
    {
        Task<int> AddAsync(ImageFileEntity imageFileEntity);

        Task DeleteAsync(int photoFileId);

        Task<ImageFileEntity?> GetAsync(int photoId);
    }
}