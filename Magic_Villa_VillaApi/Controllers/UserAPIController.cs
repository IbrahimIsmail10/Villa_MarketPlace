using AutoMapper;
using Magic_Villa_VillaApi.Logging;
using Magic_Villa_VillaApi.Models;
using Magic_Villa_VillaApi.Models.UserDTO;
using Magic_Villa_VillaApi.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Magic_Villa_VillaApi.Controllers
{
    [Route("api/UserAPI")]
    [ApiController]
    public class UserAPIController : ControllerBase
    {
        protected APIResponse response;
        private readonly IUserRepository db_users;
        public UserAPIController(ILogging logger, IUserRepository dbuser, IMapper mapper)
        {
            db_users = dbuser;
            response = new();
        }

        [HttpPost("Login")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> Login([FromBody] LoginRequestDto login)
        {
            var log = await db_users.Login(login);
            if (log.User == null)
            {
                response.IsSuccess = false;
                response.Status = HttpStatusCode.NotFound;
                response.Result = null;
                response.ErrorMessages = new List<string>() { "Wrong User Name OR Password" };
                return NotFound(response);
            }
            response.IsSuccess = true;
            response.Status = HttpStatusCode.OK;
            response.Result = log;
            return Ok(response);
        }




        [HttpPost("Register")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Registeration([FromBody] RegistrationRequestDto reg)
        {
            bool check = db_users.IsUniqueUser(reg.UserName);
            if (!check)
            {
                response.IsSuccess = false;
                response.Status = HttpStatusCode.BadRequest;
                response.Result = null;
                response.ErrorMessages = new List<string>() { "Invalid UserName!" };
                return BadRequest(response);
            }
            var user = await db_users.Register(reg);
            if (user == null)
            {
                response.IsSuccess = false;
                response.Status = HttpStatusCode.NotFound;
                response.Result = null;
                response.ErrorMessages = new List<string>() { "Wrong Happen In Registration" };
                return NotFound(response);
            }
            response.IsSuccess = true;
            response.Status = HttpStatusCode.OK;
            return Ok(response);
        }

    }
}
