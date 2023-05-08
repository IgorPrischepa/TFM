using AutoMapper;
using tfm.api.bll.Models.User;
using tfm.api.dal.Entities;

namespace tfm.api.bll.MapperProfiles
{
    internal class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserEntity, BaseUserModel>().ReverseMap();
        }
    }
}