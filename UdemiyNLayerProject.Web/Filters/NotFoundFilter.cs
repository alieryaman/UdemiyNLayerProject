using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using UdemiyNLayerProject.API.DTOs;
using UdemiyNLayerProject.Core.Services;
using UdemiyNLayerProject.Web.DTOs;

namespace UdemiyNLayerProject.Web.Filters
{
    public class NotFoundFilter:ActionFilterAttribute
    {
        private readonly ICategoryService _categoryservice;

        public NotFoundFilter(ICategoryService categoryservice)
        {
            _categoryservice = categoryservice;
        }


        public override  async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();
            var product = await _categoryservice.GetByIdAsync(id);

            if (product !=null)
            {
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();
                
                errorDto.Erors.Add($"  {id} olan category bulnmamıştır");

                context.Result = new NotFoundObjectResult(errorDto);

            }







        }


    }
}
