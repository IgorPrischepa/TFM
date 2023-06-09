﻿using tfm.api.dal.Entities;

namespace tfm.api.dal.Repos.Contracts
{
    public interface IMasterRepo
    {
        Task<int> AddNewAsync(UserEntity user);

        Task DeleteAsync(int masterId);

        Task<bool> IsBlockedAsync(int masterId);

        Task BlockAsync(int masterId);

        Task UnblockAsync(int masterId);

        Task<MasterEntity?> GetAsync(int masterId);
    }
}