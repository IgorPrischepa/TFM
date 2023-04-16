using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using tfm.api.bll.Services.Contracts;
using tfm.api.dal.Entities;
using tfm.api.dal.Repos.Contracts;
using tfm.api.exceptions;

namespace tfm.api.bll.Services.Implementations
{
    internal sealed class PhotoFileService : IPhotoFileService
    {
        private readonly IPhotoFileRepo _photos;
        private readonly string _basePath;

        public PhotoFileService(IPhotoFileRepo photoFileRepo, IConfiguration configuration)
        {
            _photos = photoFileRepo;
            _basePath = Path.Combine(Environment.CurrentDirectory, configuration.GetValue<string>("PathToFiles"));

            if (!Directory.Exists(_basePath))
            {
                Directory.CreateDirectory(_basePath);
            }
        }

        public async Task<int> AddAsync(IFormFile formFile, int exampleId)
        {
            if (formFile == null || formFile.Length == 0)
                throw new ArgumentNullException(nameof(formFile), "No file is selected or the file is empty.");

            string endFileName = Path.Combine(_basePath, Path.GetRandomFileName());

            // Save the file to the server
            await using (var stream = new FileStream(endFileName, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }

            try
            {
                return await _photos.AddAsync(new PhotoFileEntity()
                {
                    FilePath = endFileName,
                    ExampleId = exampleId
                });
            }
            catch (Exception)
            {
                File.Delete(endFileName);
                throw;
            }
        }

        public async Task DeleteAsync(int photoId)
        {
            PhotoFileEntity? photoFileEntity = await _photos.GetAsync(photoId);

            if (photoFileEntity != null)
            {
                if (File.Exists(photoFileEntity.FilePath))
                {
                    File.Delete(photoFileEntity.FilePath);
                }

                await _photos.DeleteAsync(photoId);
            }
        }

        public async Task<string> GetBase64Async(int photoId)
        {
            PhotoFileEntity? photoFileEntity = await _photos.GetAsync(photoId);

            if (photoFileEntity == null)
            {
                throw new NotFoundException("Can't find image with id {photoId}");
            }

            try
            {
                byte[] fileContent = await File.ReadAllBytesAsync(photoFileEntity.FilePath);
                return Convert.ToBase64String(fileContent);
            }
            catch (Exception ex)
            {
                throw new FileLoadException($"Error occurred while reading file '{photoFileEntity.FilePath}'. {ex.Message}");
            }
        }
    }
}