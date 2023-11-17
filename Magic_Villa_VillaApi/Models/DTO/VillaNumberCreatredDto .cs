using System.ComponentModel.DataAnnotations;

namespace Magic_Villa_VillaApi.Models.DTO
{
    public class VillaNumberCreatedDto
    {
        [Required]
        public int VillaNo { get; set; }
        public string SpcialDetails { get; set; }
    }
}
