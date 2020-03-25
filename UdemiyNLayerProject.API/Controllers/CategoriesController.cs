using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UdemiyNLayerProject.Core.Services;

namespace UdemiyNLayerProject.API.Controllers
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
        public IActionResult Index()
        {
            return View();
        }
    }
}