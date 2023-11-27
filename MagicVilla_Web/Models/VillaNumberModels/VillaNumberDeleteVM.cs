using Magic_Villa_Web.Models.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MagicVilla_Web.Models.VillaNumberModels
{
    public class VillaNumberDeleteVM
    {
        
        public VillaNumberDto VillaNumber { get; set; }
        
        [ValidateNever]
        public IEnumerable<SelectListItem> villalist { get; set; }

        public VillaNumberDeleteVM()
        {
            VillaNumber = new VillaNumberDto();
        }
    }
}
