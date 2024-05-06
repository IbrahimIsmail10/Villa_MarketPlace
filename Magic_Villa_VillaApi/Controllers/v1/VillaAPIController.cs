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
using System.Text.Json;

namespace Magic_Villa_VillaApi.Controllers.v1
{
    [Route("api/v{version:apiVersion}/VillaAPI")]
    [ApiController]
    [ApiVersion("1.0")]
    public class VillaAPIController : ControllerBase
    {
        protected APIResponse response;
        private readonly ILogging _logger;
        private readonly IVillaRepository db_villa;
        private readonly IMapper _mapper;
        public VillaAPIController(ILogging logger, IVillaRepository dbvilla, IMapper mapper)
        {
            _logger = logger;
            db_villa = dbvilla;
            _mapper = mapper;
            response = new();
        }


        // [Authorize(Roles = "admin")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ResponseCache(Duration = 30)]
        public async Task<ActionResult<APIResponse>> GetVillas([FromQuery(Name = "Occupency Filter")] int? occupency,
            [FromQuery(Name = "Search")] string search, int pagesize = 0, int pagenumber = 1)
        {
            IEnumerable<Villa> villalist;
            if (occupency > 0)
            {
                villalist = await db_villa.GetAllAsync(u => u.Occupency == occupency, pagesize: pagesize, pagenumber: pagenumber);
            }
            else
            {
                villalist = await db_villa.GetAllAsync();
            }
            if (search != null)
            {
                villalist = villalist.Where(u => u.Name.ToLower().Contains(search.ToLower()));
            }
            //adding pagination to the header of response 
            Pagination pag = new Pagination() { PageSize = pagesize, PageNumber = pagenumber };
            Response.Headers.Add("X_Pagination", JsonSerializer.Serialize(pag));
            _logger.Log("Get All Villas!", "");
            response.Result = _mapper.Map<List<VillaDto>>(villalist);
            response.Status = HttpStatusCode.OK;
            return Ok(response);
        }


        [HttpGet("{id:int}", Name = "GetVilla")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ResponseCache(CacheProfileName = "Default30")]
        public async Task<ActionResult<APIResponse>> GetSpaceficVilla(int id)
        {
            if (id == 0)
            {
                _logger.Log("Invalid ID!", "error");
                response.Status = HttpStatusCode.BadRequest;
                response.ErrorMessages = new List<string>() { "Invaild Id " };
                response.IsSuccess = false;
                return BadRequest(response);
            }
            var villa = await db_villa.GetAsync(u => u.Id == id);
            if (villa == null)
            {
                response.Status = HttpStatusCode.NotFound;
                response.ErrorMessages = new List<string>() { "The Villa Not Found" };
                response.IsSuccess = false;
                return response;
            }
            response.Result = villa;
            response.Status = HttpStatusCode.OK;
            return Ok(response);
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<APIResponse>> CreateVilla([FromBody] VillaCreatedDto createdvilla)
        {
            if (await db_villa.GetAsync(u => u.Name.ToLower() == createdvilla.Name.ToLower()) != null)
            {
                ModelState.AddModelError("ErrorMessages", "This Villa Already Exist!");
                return BadRequest(ModelState);
            }
            if (createdvilla == null)
            {
                return BadRequest();
            }
            Villa model = _mapper.Map<Villa>(createdvilla);
            await db_villa.CreateAsync(model);
            response.Result = model;
            response.Status = HttpStatusCode.OK;
            return Ok(response);

        }


        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<APIResponse>> DeleteVilla(int id)
        {
            if (id == 0)
            {
                response.Status = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                return BadRequest(response);
            }
            var villa = await db_villa.GetAsync(u => u.Id == id);
            if (villa == null)
            {
                response.Status = HttpStatusCode.NotFound;
                response.IsSuccess = false;
                return NotFound(response);

            }
            await db_villa.RemoveAsync(villa);
            response.Status = HttpStatusCode.NoContent;
            return Ok(response);

        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Villa>> UpdateVilla(int id, [FromBody] VillaUpdatedDto updateddto)
        {
            if (id != updateddto.Id || updateddto == null)
            {
                return BadRequest();
            }
            Villa model = _mapper.Map<Villa>(updateddto);
            var villa = await db_villa.UpdateAsync(model);
            return Ok(villa);
        }



        [HttpPatch("{id:int}")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Villa>> PatchUpdateVilla(int id, JsonPatchDocument<VillaUpdatedDto> dto)
        {
            if (id == 0 || dto == null)
            {
                return BadRequest();
            }
            var villa = await db_villa.GetAsync(u => u.Id == id, tracking: false);
            if (villa == null)
            {
                return BadRequest();
            }
            // _mapper.map<Destenation>(source).
            VillaUpdatedDto villaDto = _mapper.Map<VillaUpdatedDto>(villa);
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
            Villa model = _mapper.Map<Villa>(villaDto);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var x = await db_villa.UpdateAsync(model);
            return Ok(x);
        }

    }
}
