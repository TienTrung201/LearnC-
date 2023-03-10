using Microsoft.EntityFrameworkCore;
using RazorpageWebapp;

namespace EF_Webapp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<MyBlogContext>(option=>{
                string connectionString =builder.Configuration.GetConnectionString("MyBlogContext");
                option.UseSqlServer(connectionString);
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
             // migration code=> database
            /*
                    dotnet ef migrations add databaseName
                    dotnet ef migrations list  danh sách các phiên bản
                    không chỉnh sửa gì thì V1-V0 không khác nhau
                    dotnet ef migrations add V1

                    dotnet ef migrations remove xóa cái cuối

                    dotnet ef database update ---name--  nếu k có name thì lấy cái cuối
                    Đổi tên cột thì dữ liệ vẫn giữ nguyên
                    dotnet ef database update ---name-- 

                    dotnet ef database drop -xóa toàn bộ database

                    dotnet ef migrations script lấy tất cả câu lệnh sql
                    dotnet ef migrations script name1 name2

                     dotnet ef migrations script -o tenfile.sql
            */
        }
    }
}