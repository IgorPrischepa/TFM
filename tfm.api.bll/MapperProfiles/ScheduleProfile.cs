using AutoMapper;
using tfm.api.bll.Models.Schedule;
using tfm.api.dal.Entities;

namespace tfm.api.bll.MapperProfiles
{
    internal class ScheduleProfile : Profile
    {
        public ScheduleProfile()
        {
            CreateMap<ScheduleEntity, ShowScheduleModel>().ReverseMap();
            CreateMap<AddScheduleBlockerModel, ScheduleBlockerEntity>().ReverseMap();
        }
    }
}