using Magic_Villa_Web.Models;
using Magic_Villa_Web.Models.DTO;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagicVilla_Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly IVillaServices _services;
        public VillaController(IVillaServices services)
        {
            _services = services;
        }
        public async Task<ActionResult> IndexVilla()
        {
            List<VillaDto> list = new();
            var response = await _services.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<VillaDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
    }
}
