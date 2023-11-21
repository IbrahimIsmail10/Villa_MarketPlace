using AutoMapper;
using Magic_Villa_Web.Models.DTO;

namespace MagicVilla_Web.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {

            CreateMap<VillaDto, VillaCreatedDto>().ReverseMap();
            CreateMap<VillaDto, VillaUpdatedDto>().ReverseMap();

            CreateMap<VillaNumberDto, VillaNumberCreatedDto>().ReverseMap();
            CreateMap<VillaNumberDto, VillaNumberUpdatedDto>().ReverseMap();

        }
    }
}
