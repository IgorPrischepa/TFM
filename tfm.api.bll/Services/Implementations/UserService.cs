﻿using Microsoft.Extensions.Logging;
using tfm.api.bll.Models.User;
using tfm.api.bll.Services.Contracts;
using tfm.api.dal.Entities;
using tfm.api.dal.Repos.Contracts;
using BC = BCrypt.Net.BCrypt;

namespace tfm.api.bll.Services.Implementations
{
    internal sealed class UserService : IUserService
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
            await _userRepo.DeleteAsync(userId);
        }

        public async Task<BaseUserModel?> GetUserAsync(string userEmail, string password)
        {
            UserEntity? targetUser = await _userRepo.FindByEmailAsync(userEmail);

            if (targetUser == null)
            {
                return null;
            }

            if (!BC.Verify(password, targetUser.PasswordHash))
            {
                return null;
            }

            return new BaseUserModel()
            {
                Email = targetUser.Email,
                FirstName = targetUser.FirstName,
                MiddleName = targetUser.MiddleName,
                LastName = targetUser.LastName,
                Roles = targetUser.Roles.Select(_ => _.Name).ToArray(),
            };
        }

        public async Task RegisterUserAsync(AddUserModel user)
        {
            _logger.LogInformation("Start registration for a new user");

            UserEntity newUser = new()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                PasswordHash = BC.HashPassword(user.Password)
            };

            _logger.LogInformation("New user is ready. Add roles");

            RoleEntity? customerRole = await _rolesRepo.FindByNameAsync(Constants.CustomerRoleName);

            if (customerRole == null)
            {
                _logger.LogCritical("Role not found. Create new customer impossible");
                throw new Exception($"Role: {Constants.CustomerRoleName}, not found.");
            }

            newUser.Roles.Add(customerRole);

            _logger.LogInformation("Roles applied successfully");

            await _userRepo.AddAsync(newUser);

            _logger.LogInformation("User has been created successfully");
        }
    }
}