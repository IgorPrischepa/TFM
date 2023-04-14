using tfm.api.bll.DTO.Schedule;
using tfm.api.bll.Services.Contracts;
using tfm.api.dal.Entities;
using tfm.api.dal.Repos.Contracts;
using tfm.api.exceptions;

namespace tfm.api.bll.Services.Implementations;

public class ScheduleService : IScheduleService
{
    private readonly IScheduleRepo _schedule;
    private readonly IScheduleBlockerRepo _scheduleBlockers;

    public ScheduleService(IScheduleRepo scheduleRepo, IScheduleBlockerRepo scheduleBlockerRepo)
    {
        _schedule = scheduleRepo;
        _scheduleBlockers = scheduleBlockerRepo;
    }

    public async Task<int> AddAsync(AddScheduleDayDto scheduleDayDto)
    {
        if (scheduleDayDto == null) throw new ArgumentNullException(nameof(scheduleDayDto));

        if (scheduleDayDto.MasterId <= 0)
            throw new ArgumentOutOfRangeException(nameof(scheduleDayDto.MasterId));

        if (await _schedule.IsScheduledAsync(scheduleDayDto.MasterId, scheduleDayDto.DayOfWeek))
        {
            throw new ScheduleAlreadyExistsException("Master already has schedule for this day.");
        }

        if (scheduleDayDto.StartTime >= scheduleDayDto.EndTime)
        {
            throw new InvalidTimePeriodException("Start time can't be after end time.");
        }

        return await _schedule.AddAsync(new ScheduleEntity
        {
            DayOfWeek = scheduleDayDto.DayOfWeek,
            StartTime = scheduleDayDto.StartTime,
            EndTime = scheduleDayDto.EndTime,
            MasterId = scheduleDayDto.MasterId
        });
    }

    public async Task DeleteAsync(int scheduleId)
    {
        if (scheduleId <= 0) throw new ArgumentOutOfRangeException(nameof(scheduleId));

        await _schedule.DeleteAsync(scheduleId);
    }

    public async Task<ShowScheduleDto?> GetAsync(int scheduleId)
    {
        ScheduleEntity? entity = await _schedule.GetAsync(scheduleId);

        if (entity == null)
        {
            return null;
        }

        return new ShowScheduleDto
        {
            Id = entity.Id,
            DayOfWeek = entity.DayOfWeek,
            StartTime = entity.StartTime,
            EndTime = entity.EndTime,
            MasterId = entity.MasterId
        };
    }

    public async Task DeleteBlockerAsync(int scheduleBlockerId)
    {
        if (scheduleBlockerId <= 0) throw new ArgumentOutOfRangeException(nameof(scheduleBlockerId));

        await _scheduleBlockers.DeleteAsync(scheduleBlockerId);
    }

    public async Task<int> AddBlockerAsync(AddScheduleBlockerDto blockerDto)
    {
        if (blockerDto == null) throw new ArgumentNullException(nameof(blockerDto));

        if (blockerDto.MasterId <= 0)
            throw new ArgumentOutOfRangeException(nameof(blockerDto.MasterId));

        if (blockerDto.StartDateTime >= blockerDto.EndDateTime)
        {
            throw new InvalidTimePeriodException("Start time can't be after end time.");
        }

        bool isOverlapped = await _scheduleBlockers.CheckDatesOverlapAsync(blockerDto.StartDateTime,
            blockerDto.EndDateTime,
            blockerDto.MasterId);

        if (isOverlapped)
        {
            throw new DateTimeOverlappedException("There are already date locks in the specified interval.");
        }

        ScheduleBlockerEntity blockerEntity = new ScheduleBlockerEntity
        {
            StartDateTime = blockerDto.StartDateTime,
            EndDateTime = blockerDto.EndDateTime,
            MasterId = blockerDto.MasterId
        };

        if (!string.IsNullOrEmpty(blockerDto.Reason))
        {
            blockerEntity.Reason = blockerDto.Reason;
        }

        return await _scheduleBlockers.AddAsync(blockerEntity);
    }

    public async Task<ShowScheduleBlockerDto?> GetBlockerAsync(int blockerId)
    {
        if (blockerId <= 0) throw new ArgumentOutOfRangeException(nameof(blockerId));

        ScheduleBlockerEntity? blockerEntity = await _scheduleBlockers.GetAsync(blockerId);

        if (blockerEntity == null)
        {
            return null;
        }

        return new ShowScheduleBlockerDto
        {
            Id = blockerEntity.Id,
            StartDateTime = blockerEntity.StartDateTime,
            EndDateTime = blockerEntity.EndDateTime,
            MasterId = blockerEntity.MasterId,
            Reason = blockerEntity.Reason
        };
    }

    public async Task<List<ShowScheduleBlockerDto>> GetMasterBlockersAsync(int masterId)
    {
        if (masterId <= 0) throw new ArgumentOutOfRangeException(nameof(masterId));

        return (await _scheduleBlockers.GetMasterBlockersAsync(masterId)).Select(_ => new ShowScheduleBlockerDto
        {
            Id = _.Id,
            StartDateTime = _.StartDateTime,
            EndDateTime = _.EndDateTime,
            MasterId = _.MasterId,
            Reason = _.Reason
        }).ToList();
    }
}