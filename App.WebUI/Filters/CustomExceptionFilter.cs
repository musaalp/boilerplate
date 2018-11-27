using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace App.WebUI.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
        }
    }
}
