using AutoMapper;
using tfm.api.bll.Models.Schedule;
using tfm.api.Dto.Schedule;

namespace tfm.api.ModelProfiles.Schedule
{
    public class AddScheduleBlockerProfile : Profile
    {
        public AddScheduleBlockerProfile()
        {
            CreateMap<AddScheduleBlockerDto, AddScheduleBlockerModel>();
        }
    }
}