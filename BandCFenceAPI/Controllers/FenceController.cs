using System;
using System.Security.Claims;
using BandCFenceAPI.APIModels;
using BandCFenceAPI.Core.Models;
using BandCFenceAPI.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BandCFenceAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class FenceController : Controller
    {
        private readonly IFenceService _fenceService;

        public FenceController(IFenceService fenceService)
        {
            _fenceService = fenceService;
        }

        private string CurrentUserId
        {
            get
            {
                return User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            }
        }

        //GET api/fences
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var fence = _fenceService.GetAll().ToApiModels();

                return Ok(fence);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetFence", ex.StackTrace);
                return BadRequest(ModelState);
            }
        }

        //GET api/fences/id
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var fence = _fenceService.Get(id);

                return Ok(fence.ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetId", ex.StackTrace);
                return BadRequest(ModelState);
            }
        }

        //GET api/fence/feet/{feetOfFence}
        [AllowAnonymous]
        [HttpGet("api/fence/feet/{feetOfFence}")]
        public IActionResult GetFeet(int feetOfFence)
        {
            try
            {
                var fence = _fenceService.GetFeet(feetOfFence).ToApiModels();

                return Ok(fence);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetFeet", ex.StackTrace);
                return BadRequest(ModelState);
            }
        }

        //GET api/fences/address
        //[AllowAnonymous]
        //[HttpGet("{address}")]
        //public IActionResult Get(Fence address)
        //{
        //    try
        //    {
        //        var fence = _fenceService.GetAddress(address.Address);

        //        return Ok(fence.ToApiModel());
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError("GetAddress", ex.Message);
        //        return BadRequest(ModelState);
        //    }
        //}

        //POST api/fence
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post([FromBody] FenceModel fence)
        {
            try
            {
                _fenceService.Add(fence.ToDomainModel());
                return Ok();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("PostFence", ex.StackTrace);
                return BadRequest(ModelState);
            }
        }

        //PUT api/fences/id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Fence fenceModel)
        {
            try
            {
                var f = _fenceService.Update(fenceModel).ToApiModel();

                return Ok(f);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("UpdateFence", ex.StackTrace);
                return BadRequest(ModelState);
            }
        }

        //DELETE api/fences/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _fenceService.Remove(id);

                return Ok();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DeleteFence", ex.StackTrace);
                return BadRequest(ModelState);
            }
        }
    }
}
