using AutoMapper;
using AutoMapper.Configuration.Conventions;
using Magic_Villa_Web.Models;
using Magic_Villa_Web.Models.DTO;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using Utility;

namespace MagicVilla_Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly IVillaServices _services;
        private readonly IMapper _mapper;
        public VillaController(IVillaServices services,IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> IndexVilla()
        {
            List<VillaDto> list = new();
            var response = await _services.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<VillaDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
        [Authorize(Roles ="admin")]
        public async Task<ActionResult> CreateVilla()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateVilla(VillaCreatedDto model)
        {
            if (ModelState.IsValid)
            {
                 var response = await _services.CreateAsync<APIResponse>(model, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Villa Created Successfully!";
                    return RedirectToAction(nameof(IndexVilla));
                }

            }
            TempData["error"] = "Error Encountered!";

            return View(model);
        }

        [Authorize(Roles = "admin")]
        public async Task<ActionResult> UpdateVilla(int villaId)
		{
				var response = await _services.GetAsync<APIResponse>(villaId, HttpContext.Session.GetString(SD.SessionToken));
				if (response != null && response.IsSuccess)
				{
                    VillaDto dto = JsonConvert.DeserializeObject<VillaDto>(Convert.ToString(response.Result));
                VillaUpdatedDto model = _mapper.Map<VillaUpdatedDto>(dto);

					return View(model); 
				
				}

			return NotFound();
		}
        
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
		public async Task<ActionResult> UpdateVilla(VillaUpdatedDto model)
		{
            if (ModelState.IsValid)
            {
                var response = await _services.UpdateAsync<APIResponse>(model, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Villa Updated Successfully!";

                    return RedirectToAction(nameof(IndexVilla));
                }
            }
            TempData["error"] = "Error Encountered!";


            return View(model);
		}

        [Authorize(Roles = "admin")]
        public async Task<ActionResult> DeleteVilla(int villaId)
		{
			var response = await _services.GetAsync<APIResponse>(villaId, HttpContext.Session.GetString(SD.SessionToken));
			if (response != null && response.IsSuccess)
			{
				VillaDto dto = JsonConvert.DeserializeObject<VillaDto>(Convert.ToString(response.Result));

				return View(dto);
			}

			return NotFound();
		}

        [Authorize(Roles = "admin")]
        [HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> DeleteVilla(VillaDto model) 
        { 
			var response = await _services.RemoveAsync<APIResponse>(model.Id, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Villa Deleted Successfully!";
                return RedirectToAction(nameof(IndexVilla));
            }
            TempData["error"] = "Error Encountered!";


            return View(model);
		}
	}
}
