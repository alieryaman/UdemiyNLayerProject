using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemiyNLayerProject.Web.DTOs;
//using UdemiyNLayerProject.API.DTOs;

namespace UdemiyNLayerProject.Web.Filters
{
    public class ValidationFilters:ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                ErrorDto errorDto = new ErrorDto();
                errorDto.Status = 400;
                IEnumerable<ModelError> modelErrors = context.ModelState.Values.SelectMany(v=>v.Errors);

                modelErrors.ToList().ForEach(x =>
                {
                    errorDto.Erors.Add(x.ErrorMessage);


                });

                context.Result = new RedirectToActionResult("Error","Home",errorDto);

            }
        }


    }
}
