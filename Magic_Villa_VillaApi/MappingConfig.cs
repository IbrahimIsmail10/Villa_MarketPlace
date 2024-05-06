using AutoMapper;
using Magic_Villa_VillaApi.Models;
using Magic_Villa_VillaApi.Models.DTO;
using Magic_Villa_VillaApi.Models.UserDTO;

namespace Magic_Villa_VillaApi
{
    public class MappingConfig  : Profile
    {
        public MappingConfig() 
        {
            CreateMap<Villa, VillaDto>().ReverseMap();
            
            CreateMap<Villa, VillaCreatedDto>().ReverseMap();
            CreateMap<Villa, VillaUpdatedDto>().ReverseMap();

            CreateMap<VillaNumber, VillaNumberDto>().ReverseMap();
            CreateMap<VillaNumber, VillaNumberCreatedDto>().ReverseMap();
            CreateMap<VillaNumber, VillaNumberUpdatedDto>().ReverseMap();
            CreateMap<ApplicationUser, UserDto>().ReverseMap();


        }
    }
}
