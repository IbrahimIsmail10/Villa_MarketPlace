using Magic_Villa_VillaApi.Data;
using Magic_Villa_VillaApi.Models;
using Magic_Villa_VillaApi.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Magic_Villa_VillaApi.Controllers
{
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult <VillaDto> GetVillas() {
            return Ok(VillaStore.villaslist);
        }

        
        [HttpGet("{id:int}",Name ="GetVilla")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult GetSpaceficVilla(int id)
        {
            if(id == 0) {
                return BadRequest();            
            }
             var villa = VillaStore.villaslist.FirstOrDefault(u => u.Id == id);
            if(villa == null) { 
                return NotFound();
            }
            return Ok(villa);
        }
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult <VillaDto> CreateVilla([FromBody]VillaDto villa) { 
            if (VillaStore.villaslist.FirstOrDefault(u=>u.Name.ToLower() == villa.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError", "This Villa Already Exist!");
                return BadRequest(ModelState);
            }
            if (villa == null)
            {
                return BadRequest();
            }
            if (villa.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            villa.Id = VillaStore.villaslist.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            VillaStore.villaslist.Add(villa);
            return Ok(villa);   

        }
        [HttpDelete("{id:int}",Name = "DeleteVilla")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteVilla(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var villa = VillaStore.villaslist.FirstOrDefault(u=>u.Id ==id);
            if (villa == null)
            {
                return NotFound();
            }
            VillaStore.villaslist.Remove(villa);
            return NoContent();

        }


    }
}
