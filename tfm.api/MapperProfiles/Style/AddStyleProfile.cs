using AutoMapper;
using tfm.api.bll.Models.Style;
using tfm.api.Dto.Style;

namespace tfm.api.ModelProfiles.Style
{
    public class AddStyleProfile : Profile
    {
        public AddStyleProfile()
        {
            CreateMap<AddStyleDto, AddStyleModel>();
        }
    }
}