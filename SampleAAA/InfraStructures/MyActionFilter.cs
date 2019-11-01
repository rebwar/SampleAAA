using Microsoft.AspNetCore.Mvc.Filters;
using SampleAAA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAAA.InfraStructures
{
    public class MyActionFilter : IActionFilter
    {
        private readonly ILogger logger;

        public MyActionFilter(ILogger logger)
        {
            this.logger = logger;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            logger.AddLog("MyActionFilter.OnActionExecuted");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            logger.AddLog("MyActionFilter.OnActionExecuting");

        }
    }
}
