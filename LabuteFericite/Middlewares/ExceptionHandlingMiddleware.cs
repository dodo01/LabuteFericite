using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using LabuteCalatoare.Infrastructure.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace LabuteFericite.WebApi.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private static readonly Dictionary<Type, (Func<Exception, FailureResponse> TransformFunction, bool AppliesToInheritingTypes)> _exceptionResponses = new Dictionary<Type, (Func<Exception, FailureResponse> TransformFunction, bool)>();
        private static bool IsHandled(Exception exception) => _exceptionResponses.Keys.Any(x => x == exception.GetType()) || (_exceptionResponses.Keys.Any(x => x.IsAssignableFrom(exception.GetType())) && _exceptionResponses[_exceptionResponses.Keys.First(x => x.IsAssignableFrom(exception.GetType()))].AppliesToInheritingTypes);
        public static void On<TException>(Func<TException, FailureResponse> responseAction) where TException : Exception => On(responseAction, true);
        public static void On<TException>(Func<TException, FailureResponse> responseAction, bool appliesToInheritingTypes)
            where TException : Exception => _exceptionResponses[typeof(TException)] = ((Func<Exception, FailureResponse>)(x => responseAction((TException)x)), appliesToInheritingTypes);

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
           //_logger = NLogService.GetLogger();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                //logger.Log(LogLevel.Error, ex,$"Exception of type {ex.GetType()} encountered while performing {context.Request.Method} for {context.Request.Path}{context.Request.QueryString} ({ex.Message})");
                if (IsHandled(ex))
                {
                    await HandleExceptionAsync(context, ex);
                }
                else
                {
                    throw;
                }
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.BadRequest;
            FailureResponse result;
            Func<Type, bool> keyPredicate = x => x == ex.GetType();
            if(_exceptionResponses.Keys.Any(keyPredicate))
            {
                result = _exceptionResponses[_exceptionResponses.Keys.First(keyPredicate)].TransformFunction(ex);
            }
            else
            {
                result = _exceptionResponses[(_exceptionResponses.Keys.Where(x => x.IsAssignableFrom(ex.GetType())).First(x => _exceptionResponses[x].AppliesToInheritingTypes))].TransformFunction(ex);
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(result));
        }
    }
}
