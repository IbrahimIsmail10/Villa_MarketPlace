using System.ComponentModel.DataAnnotations;

namespace Magic_Villa_VillaApi.Models.DTO
{
    public class VillaNumberCreatedDto
    {
        [Required]
        public int VillaNo { get; set; }

        [Required]
        public int VillaID { get; set; }

        public string SpecialDetails { get; set; }
    }
}
