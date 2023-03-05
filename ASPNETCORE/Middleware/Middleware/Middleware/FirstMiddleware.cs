using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Middleware.Middleware
{
    public class FirstMiddleware
    {
        private readonly RequestDelegate _next;
        public FirstMiddleware(RequestDelegate next) {
            _next=next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
           // Console.WriteLine(context.Request.Path);
            await context.Response.WriteAsync("day la firstmiddeware url "+ context.Request.Path+ "\n");
            context.Items.Add("dataFirstMi",$"{context.Request.Path}");
            await _next(context);// chuyển nhiệm vụ phía sau
        }
    }
}
