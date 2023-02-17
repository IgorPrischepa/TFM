﻿using Microsoft.EntityFrameworkCore;
using tfm.api.dal.Db;
using tfm.api.dal.Entities;
using tfm.api.dal.Repos.Contracts;

namespace tfm.api.dal.Repos.Implemetations
{
    public class UserRepo : IUserRepo
    {
        private readonly ApplicationDbContext _db;

        public UserRepo(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<int> AddAsync(User user)
        {
            if (user != null)
            {
                await _db.Users.AddAsync(user);
                await _db.SaveChangesAsync();
                return user.Id;
            }
            return 0;
        }

        public async Task DeleteAsync(User user)
        {
            if (user != null)
            {
                _db.Users.Remove(user);
                await _db.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int userId)
        {
            if (userId > 0)
            {
                User? targetUser = await _db.Users.FirstOrDefaultAsync(_ => _.Id == userId);
                if (targetUser != null)
                {
                    _db.Remove(targetUser);
                    await _db.SaveChangesAsync();
                }
            }
        }

        public async Task UpdateAsync(User user)
        {
            if (user != null)
            {
                _db.Users.Update(user);
                await _db.SaveChangesAsync();
            }
        }
    }
}