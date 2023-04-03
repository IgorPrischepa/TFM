using Microsoft.AspNetCore.Http;

namespace tfm.api.bll.Services.Contracts
{
    public interface IPhotoFileService
    {
        Task<int> AddAsync(IFormFile formFile, int exampleId);

        Task DeleteAsync(int photoId);
    }
}