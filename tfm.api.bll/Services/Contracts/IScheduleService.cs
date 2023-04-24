using tfm.api.bll.Models.Schedule;

namespace tfm.api.bll.Services.Contracts;

public interface IScheduleService
{
    Task<int> AddAsync(AddScheduleDayModel scheduleDayModel);

    Task DeleteAsync(int scheduleId);

    Task<ShowScheduleModel?> GetAsync(int scheduleId);

    Task DeleteBlockerAsync(int scheduleBlockerId);

    Task<int> AddBlockerAsync(AddScheduleBlockerModel blockerModel);

    Task<ShowScheduleBlockerModel?> GetBlockerAsync(int blockerId);

    Task<List<ShowScheduleBlockerModel>> GetMasterBlockersAsync(int masterId);
}