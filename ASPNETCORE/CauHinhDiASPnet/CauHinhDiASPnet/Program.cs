using Microsoft.AspNetCore.Http;
using System.Text;
using Microsoft.Extensions.Options;

namespace CauHinhDiASPnet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddTransient<TestOptionsMiddleware>();
            builder.Services.AddSingleton<ProducNames>();

            builder.Services.AddOptions();// kích hoạt các option
            var testOption= builder.Configuration.GetSection("TestOption");

            builder.Services.Configure<TestOption>(testOption);// tham số khởi tạo Iconfiguration là section đọc dc trong file
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseMiddleware<TestOptionsMiddleware>();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapGet("/",async context =>
                {
                    await context.Response.WriteAsync("Hello world");
                });
                endpoint.MapGet("/Showoption",async context =>
                {
                //\    var testOption= context.RequestServices.GetService<IOptions<TestOption>>();
                //     //var configuration= context.RequestServices.GetService<Iconfiguration>();
                //     //IConfiguration có nhiệm vụ nạp các cấu hình trong file appsetting.json 
                //  //   var testOption = configuration.GetSection("TestOption").Get<TestOption>();
                   

              
                //     var stringBuilder = new StringBuilder();
                //     stringBuilder.Append("TestOption\n");
                //     stringBuilder.Append("option1: "+ testOption.Value.opt1);
                //     stringBuilder.Append($"\noption2 K1: {testOption.Value.opt2.k2}");
                     
                    await context.Response.WriteAsync("showoption 1");
                });
            });
            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}