using AutoMapper;
using tfm.api.bll.Models.Master;
using tfm.api.Dto.Master;

namespace tfm.api.ModelProfiles.Master
{
    public class AddExampleMasterProfile : Profile
    {
        public AddExampleMasterProfile()
        {
            CreateMap<AddMasterExampleDto, AddMasterExampleModel>();
        }
    }
}