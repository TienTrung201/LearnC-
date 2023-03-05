using Microsoft.AspNetCore.Builder;

namespace Middleware.Middleware
{
    public static class UseFirstMiddlewareMethod
    {
        public static void UseFirstMiddleware(this IApplicationBuilder app) { 
            app.UseMiddleware<FirstMiddleware>();
        }
    }
}
