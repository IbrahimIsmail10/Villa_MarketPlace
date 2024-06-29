using System.ComponentModel.DataAnnotations;

namespace Magic_Villa_Web.Models.DTO
{
    public class VillaDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Details { get; set; }
        [Required]
        public double Rate { get; set; }
        public  int Occupency { get; set; }
        public int sqfit { get; set; }
        public string ImageUrl { get; set; }
        public string? ImageLocalPath { get; set; }
        public string Amenity { get; set; }
    }
}
