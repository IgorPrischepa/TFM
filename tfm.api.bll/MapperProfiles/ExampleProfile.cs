using AutoMapper;
using tfm.api.bll.Models.Example;
using tfm.api.bll.Models.Master;
using tfm.api.dal.Entities;

namespace tfm.api.bll.MapperProfiles
{
    internal class ExampleProfile : Profile
    {
        public ExampleProfile()
        {
            CreateMap<ExampleModel, ExampleEntity>().ReverseMap();
            CreateMap<AddMasterExampleModel, ExampleModel>()
                .ForMember(dest => dest.MasterId, opt => opt.MapFrom(src => src.MasterId))
                .ForMember(dest => dest.StyleId, opt => opt.MapFrom(src => src.StyleId))
                .ForMember(dest => dest.ShortDescription, opt => opt.MapFrom(src => src.ShortDescription));
            CreateMap<ExampleModel, ShowExampleModel>();
        }
    }
}