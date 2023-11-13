using Magic_Villa_VillaApi.Data;
using Magic_Villa_VillaApi.Logging;
using Magic_Villa_VillaApi.Models;
using Magic_Villa_VillaApi.Models.DTO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Magic_Villa_VillaApi.Controllers
{
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        private readonly ILogging _logger;
        private readonly ApplicationDbContext _db;
        public VillaAPIController(ILogging logger,ApplicationDbContext db)
        {
            _logger = logger;    
            _db = db;
        }


        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult <VillaDto>> GetVillas() {
            _logger.Log("Get All Villas!","");
            return Ok(await _db.villas.ToListAsync());
        }

        
        [HttpGet("{id:int}",Name ="GetVilla")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> GetSpaceficVilla(int id)
        {
            if(id == 0) {
                _logger.Log("Invalid ID!", "error");
                return BadRequest();            
            }
            var villa = await _db.villas.FirstOrDefaultAsync(u => u.Id == id);
            if(villa == null) { 
                return NotFound();
            }
            return Ok(villa);
        }


        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult <VillaDto>> CreateVilla([FromBody]VillaCreatedDto villa) { 
            if (await _db.villas.FirstOrDefaultAsync(u=>u.Name.ToLower() == villa.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError", "This Villa Already Exist!");
                return BadRequest(ModelState);
            }
            if (villa == null)
            {
                return BadRequest();
            }
             Villa model = new Villa(){
                 Name = villa.Name,
                 Occupency = villa.Occupency,
                 Sqfit = villa.sqfit,
                 ImageUrl = villa.ImageUrl,
                 Amenity = villa.Amenity,
                 Details = villa.Details,
                 Rate = villa.Rate
             
             };
            await _db.villas.AddAsync(model);
            await _db.SaveChangesAsync();
            return Ok(model);   

        }


        [HttpDelete("{id:int}",Name = "DeleteVilla")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteVilla(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var villa = await _db.villas.FirstOrDefaultAsync(u=>u.Id ==id);
            if (villa == null)
            {
                return NotFound();
            }
            _db.villas.Remove(villa);
            await _db.SaveChangesAsync();
            return NoContent();
        }


        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateVilla(int id, [FromBody] VillaUpdatedDto dto)
        {
            if (id != dto.Id || dto == null)
            {
                return BadRequest();
            }
            Villa model = new Villa() {
                Id = dto.Id,
                Name = dto.Name,
                Occupency = dto.Occupency,
                Sqfit = dto.sqfit,
                ImageUrl = dto.ImageUrl,
                Amenity = dto.Amenity,
                Details = dto.Details,
                Rate = dto.Rate
            };

            _db.villas.Update(model);
            await _db.SaveChangesAsync();
            return NoContent();
        }



        [HttpPatch("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PatchUpdateVilla(int id, JsonPatchDocument<VillaUpdatedDto> dto)
        {
            if (id == 0 || dto == null)
            {
                return BadRequest();
            }
            var villa = await _db.villas.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
            if (villa == null)
            {
                return BadRequest();
            }
            VillaUpdatedDto villaDto = new VillaUpdatedDto() {
                Id = villa.Id,
                Name = villa.Name,
                Occupency = villa.Occupency,
                Details = villa.Details,
                Rate = villa.Rate,
                Amenity = villa.Amenity,
                ImageUrl = villa.ImageUrl,
                sqfit = villa.Sqfit
            
            
            };
            dto.ApplyTo(villaDto, ModelState);
            Villa model = new Villa()
            {
                Id = villaDto.Id,
                Name = villaDto.Name,
                Occupency = villaDto.Occupency,
                Sqfit = villaDto.sqfit,
                ImageUrl = villaDto.ImageUrl,
                Amenity = villaDto.Amenity,
                Details = villaDto.Details,
                Rate = villaDto.Rate

            };
            if (!ModelState.IsValid) { 
                return BadRequest();
            }

            _db.villas.Update(model);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        }
}
