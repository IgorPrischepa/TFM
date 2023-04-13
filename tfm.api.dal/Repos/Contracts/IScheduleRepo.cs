using tfm.api.dal.Entities;

namespace tfm.api.dal.Repos.Contracts;

public interface IScheduleRepo
{
    Task<int> AddAsync(ScheduleEntity schedule);

    Task DeleteAsync(int id);

    Task<ScheduleEntity?> GetAsync(int id);
}