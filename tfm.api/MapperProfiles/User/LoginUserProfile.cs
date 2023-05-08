using AutoMapper;
using tfm.api.bll.Models.User;
using tfm.api.Dto.User;

namespace tfm.api.ModelProfiles.User
{
    public class LoginUserProfile : Profile
    {
        public LoginUserProfile()
        {
            CreateMap<LoginUserDto, LoginUserModel>();
        }
    }
}