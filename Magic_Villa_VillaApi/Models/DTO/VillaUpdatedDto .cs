 using System.ComponentModel.DataAnnotations;

namespace Magic_Villa_VillaApi.Models.DTO
{
    public class VillaUpdatedDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Details { get; set; }
        [Required]
        public double Rate { get; set; }
        [Required]

        public int Occupency { get; set; }
        [Required]

        public int sqfit { get; set; }

        public string? ImageUrl { get; set; } 
        public string? ImageLocalPath { get; set; }
        public IFormFile? Image { get; set; }

        public string Amenity { get; set; }
    }
}
