using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace OData.Locations.Filters
{
    public class ReturnFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Hue");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
