using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemiyNLayerProject.API.DTOs;
using UdemiyNLayerProject.Core.Models;
using UdemiyNLayerProject.Core.Repostories;
using UdemiyNLayerProject.Core.Services;

namespace UdemiyNLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoriyService;
        private readonly IMapper _mapper;


        public CategoryController(ICategoryService categoriyService, IMapper mapper)
        {
            _categoriyService = categoriyService;
            _mapper = mapper;


        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            /// var categories = await _categoriyService.GetAllAsync();
            var categories = await _categoriyService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }



        [HttpGet("{id}")]

        public async Task<IActionResult> GetBdId(int id)
        {
            var category = await _categoriyService.GetByIdAsync(id);
            return Ok(_mapper.Map<CategoryDto>(category));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto categoryDto)
        {
            var newCategory = await _categoriyService.AddAsync(_mapper.Map<Category>(categoryDto));
            return Created(string.Empty, _mapper.Map<CategoryDto>(newCategory));
        }

        [HttpPut]
        public IActionResult Update(CategoryDto categoryDto)
        {

            var category = _categoriyService.Update(_mapper.Map<Category>(categoryDto));

            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _categoriyService.GetByIdAsync(id).Result;
            _categoriyService.Remove(category);
            return NoContent();
        }


        [HttpGet("{id}/{products}")]

        public async Task<IActionResult> GetwithProducById (int id)
        {


            var category = await _categoriyService.GetWithProductByIdAsync(id);
            return Ok(_mapper.Map<CategoryWithProductDto>(category));
        
        }

    
    }


}