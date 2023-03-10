using InitProject.Models;
using InitProject.Service;
using Microsoft.AspNetCore.Mvc.Razor;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ProductService>();
builder.Services.Configure<RazorViewEngineOptions>(options => {
    options.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);
});
builder.Services.AddSingleton<PlanetService>();
var app = builder.Build();

builder.Services.AddControllersWithViews();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseStatusCodePages(

);
app.UseRouting();
app.UseEndpoints(endPoint=>{
    endPoint.MapGet("/hello",async context=>{
        await context.Response.WriteAsync("helo đây là trung");
    });
});
app.UseAuthorization();
//MapControllerRoute
//MapControllers
//MapDefaultControllerRoute
//MapAreaControllerRoute


app.MapControllers();// cho phép truy cập qua các route

app.MapControllerRoute(
    name: "first",
    pattern: "{url:regex(^((xemsanpham)|(viewproduct))$)}/{id:range(2,4)}",
    defaults: new {
    
        controller="First",
        action="ViewProduct"
    }
    
    );
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=index}/{id?}");
/*
app.MapControllerRoute(
    name: "firstRoute",
    pattern: "start/{controller=First}/{action=Index}/{id?}");
*/
app.Run (async (HttpContext context) => {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync ("Trang này lỗi r đừng truy cập nữa");
            });
app.Run();
