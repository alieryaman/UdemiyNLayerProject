using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using UdemiyNLayerProject.API.DTOs;
using UdemiyNLayerProject.Core.Models;
using UdemiyNLayerProject.Web.DTOs;

namespace UdemiyNLayerProject.Web.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();


            CreateMap<Category, CategoryWithProductDto>();
            CreateMap<CategoryWithProductDto, Category>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<ProductWithCategoryDto, Product>();
        }
    }
}
