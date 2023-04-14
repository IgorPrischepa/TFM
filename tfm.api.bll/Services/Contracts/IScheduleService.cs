using tfm.api.bll.DTO.Schedule;

namespace tfm.api.bll.Services.Contracts;

public interface IScheduleService
{
    Task<int> AddAsync(AddScheduleDayDto scheduleDayDto);

    Task DeleteAsync(int scheduleId);

    Task<ShowScheduleDto?> GetAsync(int scheduleId);

    Task DeleteBlockerAsync(int scheduleBlockerId);

    Task<int> AddBlockerAsync(AddScheduleBlockerDto blockerDto);

    Task<ShowScheduleBlockerDto?> GetBlockerAsync(int blockerId);

    Task<List<ShowScheduleBlockerDto>> GetMasterBlockersAsync(int masterId);
}