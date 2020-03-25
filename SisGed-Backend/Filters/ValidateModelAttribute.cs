using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SisGed_Backend.Filters
{
    public class ValidateModelAttribute: ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext context)
        {

        }
        
    }
}
