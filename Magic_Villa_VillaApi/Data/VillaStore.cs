using Magic_Villa_VillaApi.Models.DTO;

namespace Magic_Villa_VillaApi.Data
{
    public static class VillaStore
    {
        public static List<VillaDto> villaslist = new List<VillaDto>()
        {
            new VillaDto { Id = 1,Name="Pool View",Occupency = 3,sqfit = 100},
            new VillaDto { Id = 2,Name="Sea View",Occupency = 4, sqfit = 300}
        };
    }
}
