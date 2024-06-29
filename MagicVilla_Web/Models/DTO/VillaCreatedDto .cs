using System.ComponentModel.DataAnnotations;

namespace Magic_Villa_Web.Models.DTO
{
    public class VillaCreatedDto
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Details { get; set; }
        [Required]
        public double Rate { get; set; }
        [Required]
        public  int Occupency { get; set; }
        [Required]
        public int sqfit { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile? Image { get; set; }

        public string Amenity { get; set; }
    }
}
