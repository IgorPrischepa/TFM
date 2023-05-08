using AutoMapper;
using tfm.api.bll.Models.User;
using tfm.api.Dto.User;

namespace tfm.api.ModelProfiles.User
{
    public class AddUserProfile : Profile
    {
        public AddUserProfile()
        {
            CreateMap<AddUserDto, AddUserModel>();
        }
    }
}
