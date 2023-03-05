using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Middleware.Middleware
{
    public class SecondMiddleware:IMiddleware
    {
        /*
         url: /xxx.html
        - Khong goi meddleware phía sau
        - bạn khong được truy cập
        - Header - secondMiddlewareeeeeeeeee: bạn khong duoc truy cao
        ur; !=...
        - heatder -... : bạn dduocj truy cập
        - chuyen httpcontext cho middleware phia sau
         */
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.Path == "/xxx.html")
            {
                context.Response.Headers.Add("secondmiddleware", "ban k duoc truy cao");
                var dataFromFirst = context.Items["dataFirstMi"];
                if(dataFromFirst != null)
                {
                    await context.Response.WriteAsync((string)dataFromFirst);

                }
                await context.Response.WriteAsync("Ban khong duoc truy cap");

            }
            else
            {
                var dataFromFirst = context.Items["dataFirstMi"];
                if (dataFromFirst != null)
                {
                    await context.Response.WriteAsync("URL: "+(string)dataFromFirst);

                }
                context.Response.Headers.Add("secondmiddleware", "ban duoc truy cao");
                await next(context);
            }

        }
    }
}
