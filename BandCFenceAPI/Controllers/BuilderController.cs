using System;
using BandCFenceAPI.Core.Services;
using Microsoft.AspNetCore.Mvc;
using BandCFenceAPI.Core.Models;
using BandCFenceAPI.APIModels;

namespace BandCFenceAPI.Controllers
{
    [Route("api/[controller]")]
    public class BuilderController : Controller
    {
        private readonly IBuilderService _builderService;

        public BuilderController(IBuilderService builderService)
        {
            _builderService = builderService;
        }

        //GET api/builder
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_builderService.GetAll().ToApiModels());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetBuilder", ex.StackTrace);
                return BadRequest(ModelState);
            }
        }

        //GET api/builder/id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_builderService.Get(id).ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetBuilder", ex.StackTrace);
                return BadRequest(ModelState);
            }
        }

        //POST api/builder
        [HttpPost]
        public IActionResult Post([FromBody] Builder builder)
        {
            try
            {
                return Ok(_builderService.Add(builder).ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("PostBuilder", ex.StackTrace);
                return BadRequest(ModelState);
            }
        }

        //PUT api/builder/id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Builder builder)
        {
            try
            {
                var b = _builderService.Update(builder).ToApiModel();

                return Ok(b);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("PutBuilder", ex.StackTrace);
                return BadRequest(ModelState);
            }
        }

        //DELETE api/builder/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _builderService.Remove(id);

                return Ok();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("RemoveBuilder", ex.StackTrace);
                return BadRequest(ModelState);
            }
        }
    }
}
