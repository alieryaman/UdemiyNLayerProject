using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemiyNLayerProject.Core.Repostories;
using UdemiyNLayerProject.Core.Services;

namespace UdemiyNLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoriyService;
        

        public CategoryController(ICategoryService categoriyService)
        {
            _categoriyService = categoriyService;
           
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            /// var categories = await _categoriyService.GetAllAsync();
            var categories = await _categoriyService.GetAllAsync();
            return Ok(categories);
        }

    }


}