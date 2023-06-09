﻿using Microsoft.EntityFrameworkCore;
using tfm.api.dal.Db;
using tfm.api.dal.Entities;
using tfm.api.dal.Repos.Contracts;

namespace tfm.api.dal.Repos.Implementation
{
    public sealed class PhotoFileRepo : IPhotoFileRepo
    {
        private readonly ApplicationDbContext _db;

        public PhotoFileRepo(ApplicationDbContext dbContext)
        {
            _db = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<int> AddAsync(ImageFileEntity photoFileEntity)
        {
            if (photoFileEntity is null)
            {
                throw new ArgumentNullException(nameof(photoFileEntity));
            }

            await _db.AddAsync(photoFileEntity);
            await _db.SaveChangesAsync();

            return photoFileEntity.Id;
        }

        public async Task DeleteAsync(int photoFileId)
        {
            ImageFileEntity? photoFile = await _db.PhotoFiles.FirstOrDefaultAsync(_ => _.Id == photoFileId);

            if (photoFile != null)
            {
                _db.Remove(photoFile);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<ImageFileEntity?> GetAsync(int photoId)
        {
            return await _db.PhotoFiles.FirstOrDefaultAsync(_ => _.Id == photoId);
        }
    }
}