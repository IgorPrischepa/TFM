using AutoMapper;
using tfm.api.bll.Models.Style;
using tfm.api.dal.Entities;

namespace tfm.api.bll.MapperProfiles
{
    internal class StyleProfile : Profile
    {
        public StyleProfile()
        {
            CreateMap<AddStyleModel, RoleEntity>();
        }
    }
}