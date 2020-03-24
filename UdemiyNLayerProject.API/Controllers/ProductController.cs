using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemiyNLayerProject.API.DTOs;
using UdemiyNLayerProject.API.Filters;
using UdemiyNLayerProject.Core.Models;
using UdemiyNLayerProject.Core.Services;

namespace UdemiyNLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;


        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;


        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var product= await _productService.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<ProductDto>>(product));
        }



        [HttpGet("{id}")]
        //[ServiceFilter(typeof(NotFoundFilter))]
        public async Task<IActionResult> GetBdId(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            return Ok(_mapper.Map<ProductDto>(product));



        }
       
        [HttpPost]

        public  async Task<IActionResult> Save(ProductDto productDto)
        {
            var newproduct = await _productService.AddAsync(_mapper.Map<Product>(productDto));
            return Created(string.Empty,_mapper.Map<Product>(newproduct));
        }




        
        [HttpPut]

        public  IActionResult Update(ProductDto productDto)
        {
            var newproduct = _productService.Update(_mapper.Map<Product>(productDto));
            return NoContent();
        }

        [HttpDelete("{id}")]

        [ServiceFilter(typeof(NotFoundFilter))]
        public IActionResult Deletee(int id)
        {
            var product = _productService.GetByIdAsync(id).Result;
            _productService.Remove(product); ;
            return NoContent();
        }



        [HttpGet("{id}/category")]

        public async Task<IActionResult> GetWithCategoryById(int id)
        {
            var product = await _productService.GetWithCategoryByIdAsync(id);
            return Ok(_mapper.Map<ProductWithCategoryDto>(product));
        }






    }
}