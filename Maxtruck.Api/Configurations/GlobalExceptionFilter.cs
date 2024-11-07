using Maxtruck.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.ComponentModel.DataAnnotations;

namespace Maxtruck.Api.Configurations
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var statusCode = context.Exception switch
            {
                NotFoundException => StatusCodes.Status404NotFound,

              //  ValidationException => StatusCodes.Status400BadRequest,
              
               // UnauthorizedAccessException => StatusCodes.Status401Unauthorized,

                _ => StatusCodes.Status500InternalServerError
            };

            context.Result = new ObjectResult(new
            {
                error = context.Exception.Message,
                stackTrace = context.Exception.StackTrace
            })
            {
                StatusCode = statusCode
            };
        }
    }
}
