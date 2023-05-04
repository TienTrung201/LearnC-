using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.services.adddbcontext<myblogcontext>(option => {
//    string connectionstring = builder.configuration.getconnectionstring("mycontext");
//    option.usesqlserver(connectionstring);
//});
var app = builder.Build();
//Scaffold-DbContext "Data Source = DESKTOP - 0I9BVNB\TRUNG; Initial Catalog = QLBongDa; Integrated Security = True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
//Scaffold-DbContext "Data Source=DESKTOP-0I9BVNB\TRUNG;Initial Catalog=QLBongDa;Integrated Security=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
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
