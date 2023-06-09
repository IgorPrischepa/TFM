﻿using tfm.api.bll.Models.User;

namespace tfm.api.bll.Services.Contracts
{
    public interface IUserService
    {
        Task RegisterUserAsync(AddUserModel user);

        Task DeleteAsync(int userId);

        Task<BaseUserModel?> GetUserAsync(string userEmail, string password);
    }
}