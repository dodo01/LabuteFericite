using System;
using LabuteFericite.WebApi.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LabuteFericite.WebApi.Filters
{
    public class EntityNotFoundExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if(context.Exception is EntityNotFoundException)
            {
                context.ExceptionHandled = true;
                context.Result = new NotFoundResult();
            }
            base.OnException(context);
        }
    }
}
