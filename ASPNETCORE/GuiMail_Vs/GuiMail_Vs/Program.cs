using GuiMail_Vs.MailUtils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
// var a= builder.Configuration.GetSection("MailSettings:Mail").Value;
// Console.WriteLine(a);
builder.Services.AddOptions();
builder.Services.AddTransient<SendMailService>();
var getMailSetting = builder.Configuration.GetSection("MailSettings");
builder.Services.Configure<MailSettings>(getMailSetting);

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
app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", async context =>
    {
        await context.Response.WriteAsync("hello");
    });
    endpoints.MapGet("/TestSendEmail", async context =>
    {
        var message = await MailUtils.SendMail("tientrung14122001@gmail.com", "tientrung14122012@gmail.com", "Test", "Xin chao tao tesst");
        await context.Response.WriteAsync(message);
    });
    endpoints.MapGet("/TestSendGmail", async context =>
    {
        var message = await MailUtils.SendGmail("tientrung14122001@gmail.com", "tientrung14122012@gmail.com", "Test", "Xin chao tao tesst", "tientrung14122001@gmail.com", "uzowovptiimmsjkd");
        await context.Response.WriteAsync(message);
    });

    endpoints.MapGet("/SendMailService", async context =>
    {
        var getSenmailService = context.RequestServices.GetService<SendMailService>();
        var mailContent = new MailContent
        {
            To = "bikini7meo@gmail.com",
            Subject = "Test",
            Body = "<p><strong>Xin chào Tien trung test</strong></p>"
        };
        var message = await getSenmailService.SendMail(mailContent);
        await context.Response.WriteAsync(message);
    });
    //dotnet add package MailKit
    // dotnet add package MimeKit
    //Install - Package MimeKit

});
app.UseAuthorization();

app.MapRazorPages();

app.Run();
