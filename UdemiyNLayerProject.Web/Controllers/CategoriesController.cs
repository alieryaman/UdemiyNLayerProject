using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UdemiyNLayerProject.API.DTOs;
using UdemiyNLayerProject.Core.Models;
using UdemiyNLayerProject.Core.Services;
//using UdemiyNLayerProject.Web.DTOs;

namespace UdemiyNLayerProject.Web.Controllers
{
    public class CategoriesController : Controller
    {


        private readonly ICategoryService _categoriyService;
        private readonly IMapper _mapper;


        public CategoriesController(ICategoryService categoriyService, IMapper mapper)
        {

            _categoriyService = categoriyService;
            _mapper = mapper;



        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoriyService.GetAllAsync();

            return View(_mapper.Map<IEnumerable<API.DTOs.CategoryDto>>(categories));
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {

            await _categoriyService.AddAsync(_mapper.Map<Category>(categoryDto));
            return RedirectToAction("Index");
        }


        public IActionResult Update(int id)
        {
            var category = _categoriyService.GetByIdAsync(id);

            return View(_mapper.Map<CategoryDto>(category));
        }
        [HttpPost]
        public IActionResult Update(CategoryDto categoryDto)
        {

             _categoriyService.Update(_mapper.Map<Category>(categoryDto));
            return RedirectToAction("Index");
        }


    }
}