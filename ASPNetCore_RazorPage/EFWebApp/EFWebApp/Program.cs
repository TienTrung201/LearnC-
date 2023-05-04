using EFWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

namespace EFWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddDbContext<MyBlogContext>(option=>{
                string connectionString =builder.Configuration.GetConnectionString("MyBlogContext");
                option.UseSqlServer(connectionString);
            });

                //         builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                // .AddEntityFrameworkStores<MyBlogContext>();
			//đăng ký identity
			
             builder.Services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<MyBlogContext>()
                .AddDefaultTokenProviders();
             

			//đăng ký identity 
			//identity/account/login
			// builder.Services.AddDefaultIdentity<AppUser>()
			// 	.AddEntityFrameworkStores<MyBlogContext>()
			// 	.AddDefaultTokenProviders(); 
            //đăng ký dịch vụ gửi email
            //builder.Services.AddTransient<SendMailService>();// mỗi khi truy vấn sẽ tạo 1 dịch vụ sendmailservice
            builder.Services.AddSingleton<IEmailSender,SendMailService>();// tồn tại suốt quá trình hoạt động ứng dụng
           
            var getMailSetting = builder.Configuration.GetSection("MailSettings");
            // buider.Services.AddOptions();
            builder.Services.Configure<MailSettings>(getMailSetting);

            // Truy cập IdentityOptions
            builder.Services.Configure<IdentityOptions>(options => {
				// Thiết lập về Password
				options.Password.RequireDigit = false; // Không bắt phải có số
				options.Password.RequireLowercase = false; // Không bắt phải có chữ thường
				options.Password.RequireNonAlphanumeric = false; // Không bắt ký tự đặc biệt
				options.Password.RequireUppercase = false; // Không bắt buộc chữ in
				options.Password.RequiredLength = 3; // Số ký tự tối thiểu của password
				options.Password.RequiredUniqueChars = 1; // Số ký tự riêng biệt

				// Cấu hình Lockout - khóa user
				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Khóa 5 phút
				options.Lockout.MaxFailedAccessAttempts = 5; // Thất bại 5 lầ thì khóa
				options.Lockout.AllowedForNewUsers = true;

				// Cấu hình về User.
				options.User.AllowedUserNameCharacters = // các ký tự đặt tên user
					"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
				options.User.RequireUniqueEmail = true;  // Email là duy nhất

				// Cấu hình đăng nhập.
				options.SignIn.RequireConfirmedEmail = true;            // Cấu hình xác thực địa chỉ email (email phải tồn tại)
				options.SignIn.RequireConfirmedPhoneNumber = false;     // Xác thực số điện thoại

			});

			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();//cần 2 cái này identity
            app.UseAuthentication();//

            app.MapRazorPages();

            app.Run();
            // migration code=> database
            /*
                    dotnet ef migrations add databaseName                                                   add migration
                    dotnet ef migrations list  danh sách các phiên bản                                       Get-Migration
                    không chỉnh sửa gì thì V1-V0 không khác nhau
                    dotnet ef migrations add V1

                    dotnet ef migrations remove xóa cái cuối                                                 Remove-Migration

                    dotnet ef database update ---name--  nếu k có name thì lấy cái cuối                     Update-Database 20230312171749_InitMigraion
                    Đổi tên cột thì dữ liệ vẫn giữ nguyên
                    dotnet ef database update ---name-- 

                    dotnet ef database drop -xóa toàn bộ database

                    dotnet ef migrations script lấy tất cả câu lệnh sql
                    dotnet ef migrations script name1 name2

                     dotnet ef migrations script -o tenfile.sql
            */

            /*
			 * CRUD 
              //dotnet aspnet-codegenerator razorpage -m EFWebApp.Article -dc EFWebApp.MyBlogContext -outDir Pages/Blog --useDefaultLayout --referenceScriptLibraries
             */
            /*Identity
             * -Athentication : login logout
             * -Authorition: xác định quyền truy cập
             * - quản lý user
             
             
             */
            // tao giao dien cacs trang razor usser loginlogout cacs kieu
            //dotnet aspnet-codegenerator identity -dc EFWebApp.Models.MyBlogContext
        }
    }
}