using AutoMapper;
using Magic_Villa_VillaApi.Data;
using Magic_Villa_VillaApi.Logging;
using Magic_Villa_VillaApi.Models;
using Magic_Villa_VillaApi.Models.DTO;
using Magic_Villa_VillaApi.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Magic_Villa_VillaApi.Controllers
{
    [Route("api/VillaNumberAPI")]
    [ApiController]
    public class VillaNumberAPIController : ControllerBase
    {
        protected APIResponse response;
        private readonly ILogging _logger;
        private readonly IVillaNumberRepository villaNumber;
        private readonly IVillaRepository _dbvilla;
        private readonly IMapper _mapper;
        public VillaNumberAPIController(ILogging logger,IVillaNumberRepository dbvillaNumber, IVillaRepository dbvilla, IMapper mapper)
        {
            _logger = logger;    
             villaNumber = dbvillaNumber;
            _mapper = mapper;
            _dbvilla = dbvilla;
            response = new ();
        }


        [HttpGet]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(200)]
        public async Task<ActionResult <APIResponse>> GetVillasNumber() {
            IEnumerable <VillaNumber> villalist = await villaNumber.GetAllAsync(includeProperties:"Villa");
            _logger.Log("Get All Villas!","");
            response.Result = _mapper.Map<List<VillaNumberDto>>(villalist);
            response.Status = HttpStatusCode.OK;
            return Ok(response);
        }

        
        [HttpGet("{id:int}",Name = "GetVillaNumber")]

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<APIResponse>> GetVillaNumber(int id)
        {
            if(id == 0) {
                _logger.Log("Invalid Villa Number!", "error");
                response.Status = HttpStatusCode.BadRequest;
                response.ErrorMessages = new List<string>() {"Invaild Id "};
                response.IsSuccess = false;
                return BadRequest(response);            
            }
            var villa = await villaNumber.GetAsync(u => u.VillaNo == id);
            if(villa == null) { 
                response.Status = HttpStatusCode.NotFound;
                response.ErrorMessages = new List<string>() { "The Villa Not Found" };
                response.IsSuccess = false;
                return response;
            }
            response.Result = _mapper.Map<VillaNumberDto>(villa);
            response.Status = HttpStatusCode.OK;
            return Ok(response);
        }


        [HttpPost]
        [Authorize(Roles = "admin")]

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult <APIResponse>> CreateVillaNumber([FromBody]VillaNumberCreatedDto createdvilla) {
            if (await villaNumber.GetAsync(u => u.VillaNo == createdvilla.VillaNo) != null)
            {
                ModelState.AddModelError("ErrorMessages", "This Villa Already Exist!");
                return BadRequest(ModelState);
            }
            if (createdvilla == null)
            {
                return BadRequest();
            }
            if (await _dbvilla.GetAsync(u=>u.Id == createdvilla.VillaID) == null)
            {
                ModelState.AddModelError("ErrorMessages", "Villa ID is Invalid!");
                return BadRequest(ModelState);
            }
            VillaNumber model = _mapper.Map<VillaNumber>(createdvilla);
            await villaNumber.CreateAsync(model);
            VillaNumberDto result = _mapper.Map<VillaNumberDto>(model);
            response.Result = result;
            response.Status = HttpStatusCode.OK;
            return Ok(response);   

        }


        [HttpDelete("{id:int}",Name = "DeleteVillaNumber")]
        [Authorize(Roles = "admin")]

        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<APIResponse>> DeleteVillaNumber(int id)
        {
            if(id == 0)
            {
                response.Status = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                return BadRequest(response);
            }
            var villa = await villaNumber.GetAsync(u=>u.VillaNo ==id);
            if (villa == null)
            {
                response.Status = HttpStatusCode.NotFound;
                response.IsSuccess = false;
                return NotFound(response);
               
            }
            await villaNumber.RemoveAsync(villa);
            response.Status = HttpStatusCode.NoContent;
            return Ok(response);
            
        }


        [HttpPut("{id:int}", Name = "UpdateVillaNumber")]
        [Authorize(Roles = "admin")]

        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Villa>> UpdateVillaNumber(int id, [FromBody] VillaNumberUpdatedDto updateddto)
        {
            if (id != updateddto.VillaNo || updateddto == null)
            {
                return BadRequest();
            }
            if (await _dbvilla.GetAsync(u => u.Id == updateddto.VillaID) == null)
            {
                ModelState.AddModelError("ErrorMessages", "Villa ID is Invalid!");
                return BadRequest(ModelState);
            }
            VillaNumber model = _mapper.Map<VillaNumber>(updateddto);
            var villa = await villaNumber.UpdateAsync(model);
            VillaNumberDto result = _mapper.Map<VillaNumberDto>(villa);

            return Ok(result);
        }



        [Authorize(Roles = "admin")]

        [HttpPatch("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Villa>> PatchUpdateVillaNumber(int id, JsonPatchDocument<VillaNumberUpdatedDto> dto)
        {
            if (id == 0 || dto == null)
            {
                return BadRequest();
            }
            var villa = await villaNumber.GetAsync(u => u.VillaNo == id,tracking:false);
            if (villa == null)
            {
                return BadRequest();
            }
            // _mapper.map<Destenation>(source).
            VillaNumberUpdatedDto villaDto = _mapper.Map<VillaNumberUpdatedDto>(villa);
           //VillaUpdatedDto villaDto = new VillaUpdatedDto() {
           //     Id = villa.Id,
           //     Name = villa.Name,
           //     Occupency = villa.Occupency,
           //     Details = villa.Details,
           //     Rate = villa.Rate,
           //     Amenity = villa.Amenity,
           //     ImageUrl = villa.ImageUrl,
           //     sqfit = villa.Sqfit
           // };
            dto.ApplyTo(villaDto, ModelState);
            VillaNumber model = _mapper.Map<VillaNumber>(villaDto);
            if (!ModelState.IsValid) { 
                return BadRequest();
            }

          var x = await villaNumber.UpdateAsync(model);
          VillaNumberDto res = _mapper.Map<VillaNumberDto>(x);

            return Ok(res) ;
        }

        }
}
