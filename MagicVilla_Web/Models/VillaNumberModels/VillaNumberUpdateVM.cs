using Magic_Villa_Web.Models.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MagicVilla_Web.Models.VillaNumberModels
{
    public class VillaNumberUpdateVM
    {
        
        public VillaNumberUpdatedDto VillaNumber { get; set; }
        
        [ValidateNever]
        public IEnumerable<SelectListItem> villalist { get; set; }

        public VillaNumberUpdateVM()
        {
            VillaNumber = new VillaNumberUpdatedDto();
        }
    }
}
