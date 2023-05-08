using AutoMapper;
using tfm.api.bll.Models.Schedule;
using tfm.api.bll.Services.Contracts;
using tfm.api.dal.Entities;
using tfm.api.dal.Repos.Contracts;
using tfm.api.exceptions;

namespace tfm.api.bll.Services.Implementations
{
    internal sealed class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepo _schedule;
        private readonly IScheduleBlockerRepo _scheduleBlockers;
        private readonly IMapper _mapper;

        public ScheduleService(IScheduleRepo scheduleRepo, IMapper mapper, IScheduleBlockerRepo scheduleBlockerRepo)
        {
            _schedule = scheduleRepo;
            _scheduleBlockers = scheduleBlockerRepo;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(AddScheduleDayModel scheduleDayModel)
        {
            if (await _schedule.IsScheduledAsync(scheduleDayModel.MasterId, scheduleDayModel.DayOfWeek))
            {
                throw new ScheduleAlreadyExistsException("Master already has schedule for this day.");
            }

            if (scheduleDayModel.StartTime >= scheduleDayModel.EndTime)
            {
                throw new InvalidTimePeriodException("Start time can't be after end time.");
            }

            return await _schedule.AddAsync(new ScheduleEntity
            {
                DayOfWeek = scheduleDayModel.DayOfWeek,
                StartTime = scheduleDayModel.StartTime,
                EndTime = scheduleDayModel.EndTime,
                MasterId = scheduleDayModel.MasterId
            });
        }

        public async Task DeleteAsync(int scheduleId)
        {
            if (scheduleId <= 0) throw new ArgumentOutOfRangeException(nameof(scheduleId));

            await _schedule.DeleteAsync(scheduleId);
        }

        public async Task<ShowScheduleModel?> GetAsync(int scheduleId)
        {
            ScheduleEntity? entity = await _schedule.GetAsync(scheduleId);

            if (entity == null)
            {
                return null;
            }

            return _mapper.Map<ShowScheduleModel>(entity);
        }

        public async Task DeleteBlockerAsync(int scheduleBlockerId)
        {
            await _scheduleBlockers.DeleteAsync(scheduleBlockerId);
        }

        public async Task<int> AddBlockerAsync(AddScheduleBlockerModel blockerModel)
        {
            if (blockerModel.StartDateTime >= blockerModel.EndDateTime)
            {
                throw new InvalidTimePeriodException("Start time can't be after end time.");
            }

            bool isOverlapped = await _scheduleBlockers.CheckDatesOverlapAsync(blockerModel.StartDateTime,
                blockerModel.EndDateTime,
                blockerModel.MasterId);

            if (isOverlapped)
            {
                throw new DateTimeOverlappedException("There are already date locks in the specified interval.");
            }

            ScheduleBlockerEntity blockerEntity = _mapper.Map<ScheduleBlockerEntity>(blockerModel);

            if (!string.IsNullOrEmpty(blockerModel.Reason))
            {
                blockerEntity.Reason = blockerModel.Reason;
            }

            return await _scheduleBlockers.AddAsync(blockerEntity);
        }

        public async Task<ShowScheduleBlockerModel?> GetBlockerAsync(int blockerId)
        {
            ScheduleBlockerEntity? blockerEntity = await _scheduleBlockers.GetAsync(blockerId);

            if (blockerEntity == null)
            {
                return null;
            }

            return _mapper.Map<ShowScheduleBlockerModel>(blockerEntity);
        }

        public async Task<List<ShowScheduleBlockerModel>> GetMasterBlockersAsync(int masterId)
        {
            return (await _scheduleBlockers.GetMasterBlockersAsync(masterId)).Select(_ => _mapper.Map<ShowScheduleBlockerModel>(_))
                                                                             .ToList();
        }
    }
}