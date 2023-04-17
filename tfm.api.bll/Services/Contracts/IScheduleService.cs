using tfm.api.bll.Models.Schedule;

namespace tfm.api.bll.Services.Contracts;

public interface IScheduleService
{
    Task<int> AddAsync(AddScheduleDayModel scheduleDayModel);

    Task DeleteAsync(int scheduleId);

    Task<ShowScheduleDto?> GetAsync(int scheduleId);

    Task DeleteBlockerAsync(int scheduleBlockerId);

    Task<int> AddBlockerAsync(AddScheduleBlockerModel blockerModel);

    Task<ShowScheduleBlockerDto?> GetBlockerAsync(int blockerId);

    Task<List<ShowScheduleBlockerDto>> GetMasterBlockersAsync(int masterId);
}