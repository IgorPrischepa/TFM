using Microsoft.EntityFrameworkCore;
using tfm.api.dal.Db;
using tfm.api.dal.Entities;
using tfm.api.dal.Repos.Contracts;

namespace tfm.api.dal.Repos.Implemetations
{
    public sealed class UserRepo : IUserRepo
    {
        private readonly ApplicationDbContext _db;

        public UserRepo(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<int> AddAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            return user.Id;
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

        public async Task<User?> FindByEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException(nameof(email));
            }

            return await _db.Users.Include(_ => _.Roles).FirstOrDefaultAsync(_ => _.Email == email);
        }

        public async Task<User?> FindByIdAsync(int Id)
        {
            return await _db.Users.Include(_ => _.Roles).FirstOrDefaultAsync(_ => _.Id == Id);
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