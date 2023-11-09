using Magic_Villa_VillaApi.Models.DTO;

namespace Magic_Villa_VillaApi.Data
{
    public static class VillaStore
    {
        public static List<VillaDto> villaslist = new List<VillaDto>()
        {
            new VillaDto { Id = 1,Name="Pool View"},
            new VillaDto { Id = 2,Name="Sea View"}
        };
    }
}
