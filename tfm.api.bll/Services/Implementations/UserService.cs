using tfm.api.bll.DTO;
using tfm.api.bll.Services.Contracts;
using tfm.api.dal.Entities;
using tfm.api.dal.Repos.Contracts;
using BC = BCrypt.Net.BCrypt;

namespace tfm.api.bll.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task DeleteAsync(int userId)
        {
            if (userId < 0)
            {
                throw new ArgumentOutOfRangeException("UserId can't be less than zero.");
            }

            await _userRepo.DeleteAsync(userId);
        }

        public async Task<UserDTO?> GetUserAsync(string userEmail, string password)
        {
            User? targetUser = await _userRepo.FindByEmailAsync(userEmail);

            if (targetUser == null)
            {
                return null;
            }

            if (!BC.Verify(password, targetUser.PasswordHash))
            {
                return null;
            };

            return new UserDTO()
            {
                Email = targetUser.Email,
                FirstName = targetUser.FirstName,
                MiddleName = targetUser.MiddleName,
                LastName = targetUser.LastName,
                Roles = targetUser.Roles.Select(_ => _.Name).ToArray(),
            };
        }

        public async Task RegisterUserAsync(NewUserDto user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            // create Only customers
            await _userRepo.AddAsync(new User()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                PasswordHash = BC.HashPassword(user.Password)
            });
        }
    }
}