using tfm.api.dal.Entities;

namespace tfm.api.dal.Repos.Contracts;

public interface IScheduleBlockerRepo
{
    Task<int> AddAsync(ScheduleBlockerEntity blockerEntity);

    Task DeleteAsync(int id);

    Task<ScheduleBlockerEntity?> GetAsync(int id);

    Task<bool> CheckDatesOverlapAsync(DateTime startDate, DateTime endDate, int masterId);
    Task<List<ScheduleBlockerEntity>> GetMasterBlockersAsync(int masterId);
}