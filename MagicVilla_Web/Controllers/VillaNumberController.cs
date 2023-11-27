using AutoMapper;
using AutoMapper.Configuration.Conventions;
using Magic_Villa_Web.Models;
using Magic_Villa_Web.Models.DTO;
using MagicVilla_Web.Models.VillaNumberModels;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;
using Utility;

namespace MagicVilla_Web.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly IVillaNumberServices _services;
        private readonly IVillaServices _villaservices;

        private readonly IMapper _mapper;
        public VillaNumberController(IVillaNumberServices services,IMapper mapper, IVillaServices villaservices)
        {
            _services = services;
            _mapper = mapper;
            _villaservices = villaservices;
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
            VillaNumberCreateVM villanumber = new();
            var response = await _villaservices.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                    villanumber.villalist = JsonConvert.DeserializeObject<List<VillaDto>>
                                            (Convert.ToString(response.Result)).Select(i => new SelectListItem
                                            {
                                                Text = i.Name,
                                                Value = i.Id.ToString()
                                            });   
            }
            return View(villanumber);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateVillaNumber(VillaNumberCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var respone =await _services.CreateAsync<APIResponse>(model.VillaNumber);
                if (respone != null && respone.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexVillaNumber));
                }
                else
                {
                    if(respone.ErrorMessages.Count >0)
                    {
                        ModelState.AddModelError("ErrorMessages", respone.ErrorMessages.FirstOrDefault());
                    }
                }

            }
            var resp = await _villaservices.GetAllAsync<APIResponse>();
            if (resp != null && resp.IsSuccess)
            {
                model.villalist = JsonConvert.DeserializeObject<List<VillaDto>>
                                        (Convert.ToString(resp.Result)).Select(i => new SelectListItem
                                        {
                                            Text = i.Name,
                                            Value = i.Id.ToString()
                                        });
            }
            return View(model);
        }
        public async Task<ActionResult> UpdateVillaNumber(int villaNum)
        {
            VillaNumberUpdateVM villanumber = new();
            var response1 = await _villaservices.GetAllAsync<APIResponse>();
            if (response1 != null && response1.IsSuccess)
            {
                villanumber.villalist = JsonConvert.DeserializeObject<List<VillaDto>>
                                        (Convert.ToString(response1.Result)).Select(i => new SelectListItem
                                        {
                                            Text = i.Name,
                                            Value = i.Id.ToString()
                                        });
            }
            var response = await _services.GetAsync<APIResponse>(villaNum);
            if (response != null && response.IsSuccess)
            {
                villanumber.VillaNumber = JsonConvert.DeserializeObject<VillaNumberUpdatedDto>(Convert.ToString(response.Result));
                return View(villanumber);

            }

            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateVillaNumber(VillaNumberUpdateVM model)
        {
            if (ModelState.IsValid)
            {
                var response = await _services.UpdateAsync<APIResponse>(model.VillaNumber);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexVillaNumber));
                }
                else
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        ModelState.AddModelError("ErrorMessages", response.ErrorMessages.FirstOrDefault());
                    }
                }
            }
            return View(model);
        }



        public async Task<ActionResult> DeleteVillaNumber(int villaNum)
        {
            VillaNumberDeleteVM villanumber = new();
            var response1 = await _villaservices.GetAllAsync<APIResponse>();
            if (response1 != null && response1.IsSuccess)
            {
                villanumber.villalist = JsonConvert.DeserializeObject<List<VillaDto>>
                                        (Convert.ToString(response1.Result)).Select(i => new SelectListItem
                                        {
                                            Text = i.Name,
                                            Value = i.Id.ToString()
                                        });
            }
            var response = await _services.GetAsync<APIResponse>(villaNum);
            if (response != null && response.IsSuccess)
            {
                VillaNumberDto model = JsonConvert.DeserializeObject<VillaNumberDto>(Convert.ToString(response.Result));
                villanumber.VillaNumber = model;
                return View(villanumber);

            }

            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteVillaNumber(VillaNumberDeleteVM model)
        {
            var response = await _services.RemoveAsync<APIResponse>(model.VillaNumber.VillaNo);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(IndexVillaNumber));
            }

            return View(model);
        }
    }
}
