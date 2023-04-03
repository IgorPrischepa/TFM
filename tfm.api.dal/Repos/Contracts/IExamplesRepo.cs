﻿using tfm.api.dal.Entities;

namespace tfm.api.dal.Repos.Contracts
{
    public interface IExamplesRepo
    {
        Task<int> AddAsync(ExampleEntity exampleEntity);
        Task<int> CountAsync(int masterId, int styleId);
        Task DeleteAsync(int Id);
    }
}