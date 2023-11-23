using AutoMapper;
using AutoMapper.Configuration.Conventions;
using Magic_Villa_Web.Models;
using Magic_Villa_Web.Models.DTO;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MagicVilla_Web.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly IVillaNumberServices _services;
        private readonly IMapper _mapper;
        public VillaNumberController(IVillaNumberServices services,IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }
        public async Task<ActionResult> IndexVillaNumber()
        {
            List<VillaNumberDto> list = new();
            var response = await _services.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<VillaNumberDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
        public async Task<ActionResult> CreateVillaNumber()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateVillaNumber(VillaNumberCreatedDto model)
        {
            if (ModelState.IsValid)
            {
                 var response = await _services.CreateAsync<APIResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexVillaNumber));
                }

            }
            return View(model);
        }
		public async Task<ActionResult> UpdateVillaNumber(int villaNum)
		{
				var response = await _services.GetAsync<APIResponse>(villaNum);
				if (response != null && response.IsSuccess)
				{
                    VillaNumberDto dto = JsonConvert.DeserializeObject<VillaNumberDto>(Convert.ToString(response.Result));
                VillaNumberUpdatedDto model = _mapper.Map<VillaNumberUpdatedDto>(dto);

					return View(model); 
				
				}

			return NotFound();
		}
		[HttpPost]
        [ValidateAntiForgeryToken]
		public async Task<ActionResult> UpdateVillaNumber(VillaNumberUpdatedDto model)
		{
            if (ModelState.IsValid)
            {
                var response = await _services.UpdateAsync<APIResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexVillaNumber));
                }
            }

			return View(model);
		}
		public async Task<ActionResult> DeleteVillaNumber(int villaNum)
		{
			var response = await _services.GetAsync<APIResponse>(villaNum);
			if (response != null && response.IsSuccess)
			{
				VillaNumberDto dto = JsonConvert.DeserializeObject<VillaNumberDto>(Convert.ToString(response.Result));

				return View(dto);
			}

			return NotFound();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> DeleteVillaNumber(VillaNumberDto model) 
        { 
			var response = await _services.RemoveAsync<APIResponse>(model.VillaNo);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(IndexVillaNumber));
            }

			return View(model);
		}
	}
}
