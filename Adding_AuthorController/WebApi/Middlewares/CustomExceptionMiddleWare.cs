using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using WebApi.Service;

namespace WebApi.Middlewares
{
    
    public class CustomExceptionMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _LoggerService;
        public CustomExceptionMiddleWare( RequestDelegate next, ILoggerService loggerService)
        {
            _next = next;
            _LoggerService = loggerService;
        }
        public async Task Invoke(HttpContext context)
        {

            var watch = Stopwatch.StartNew();
            try
            {
            string message = " [Request] HTTP" + context.Request.Method + context.Request.Path;
           _LoggerService.Write(message);
            await _next(context); //Bir sonraki middleWare cagırmıs oluyoruz.
            watch.Stop();
            message = " [Request] HTTP"+context.Request.Method + "-" + "responded : "+ context.Response.StatusCode + " in "+watch.Elapsed.TotalMilliseconds + "ms";
           _LoggerService.Write(message); 

            }
            catch(Exception ex)
            {
                 watch.Stop();
                 await HandleException(context,ex, watch);
            }
          
        }
        private Task HandleException(HttpContext context, Exception ex, Stopwatch watch)
        {
            context.Response.ContentType ="application/json";
            context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            
            string message = "[Error] HTTP" + context.Request.Method +" - " + context.Response.StatusCode + "Error Message" +ex.Message+ " in "+watch.Elapsed.TotalMilliseconds ;
            _LoggerService.Write(message);
          
           var result = JsonConvert.SerializeObject(new {error =ex.Message}, Formatting.None);
           return  context.Response.WriteAsync(result);
        }
    }
    public static class CustomExceptionMiddleWareExtension
    {
        public static IApplicationBuilder UseCustomExceptionMiddleWare( this IApplicationBuilder builder )
        {
            return builder.UseMiddleware<CustomExceptionMiddleWare>();
        }
    }
}