using Microsoft.Extensions.Logging;
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
        private readonly ILogger<UserService> _logger;
        private readonly IRolesRepo _rolesRepo;

        public UserService(IUserRepo userRepo, IRolesRepo rolesRepo, ILogger<UserService> logger)
        {
            _userRepo = userRepo;
            _logger = logger;
            _rolesRepo = rolesRepo;
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
            const string baseRole = "Customer";

            _logger.LogInformation("Start registration for a new user.");

            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            // create Only customers

            User newUser = new()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                PasswordHash = BC.HashPassword(user.Password)
            };

            _logger.LogInformation("New user is ready. Add roles");


            newUser.Roles ??= new List<Role>();

            Role? customerRole = await _rolesRepo.FindByNameAsync(baseRole);

            if (customerRole == null)
            {
                _logger.LogCritical("Role can't be finded. Create new custemer impossible.");
                throw new Exception($"Role: {baseRole}, can't be finded.");
            }

            newUser.Roles.Add(customerRole);

            _logger.LogInformation("Roles applied successfully.");

            await _userRepo.AddAsync(newUser);

            _logger.LogInformation("User has been created successfully.");
        }
    }
}