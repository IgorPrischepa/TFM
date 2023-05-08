using AutoMapper;
using tfm.api.bll.Models.Schedule;
using tfm.api.Dto.Schedule;

namespace tfm.api.ModelProfiles.Schedule
{
    public class AddScheduleProfile : Profile
    {
        public AddScheduleProfile()
        {
            CreateMap<AddScheduleDayDto, AddScheduleDayModel>();
        }
    }
}