﻿using System.ComponentModel.DataAnnotations;

namespace Magic_Villa_Web.Models.DTO
{
    public class VillaNumberDto
    {
        [Required]
        public int VillaNo { get; set; }

        [Required]
        public int VillaID { get; set; }

        public string SpecialDetails { get; set; }
        
    }
}
