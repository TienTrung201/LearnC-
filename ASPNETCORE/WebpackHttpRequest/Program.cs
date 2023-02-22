var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

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

app.UseEndpoints(endpoint =>
{
    endpoint.MapGet("/", async context =>
    {

        var mennu = HtmlHelper.MenuTop(
                HtmlHelper.DefaultMenuTopItems(), context.Request
            );
        var html = HtmlHelper.HtmlDocument("Hello tientrung !", mennu + HtmlHelper.HtmlTrangchu());
        await context.Response.WriteAsync(html);
    });
    endpoint.MapGet("/RequestInfo", async context =>
    {
        var mennu = HtmlHelper.MenuTop(
                 HtmlHelper.DefaultMenuTopItems(), context.Request
             );
        var info = RequestProcess.RequestInfo(context.Request);
        var html = HtmlHelper.HtmlDocument("Hello, !", mennu + info);

        await context.Response.WriteAsync(html);
    });
    endpoint.MapGet("/Endcodeing", async context =>
    {
        await context.Response.WriteAsync("Endcodeing");
    });
    endpoint.MapGet("/Json", async context =>
    {
        string Json = RequestProcess.GetJson();
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(Json);
    });
    endpoint.MapGet("/Cookies/{*action}", async context =>
    {
        var mennu = HtmlHelper.MenuTop(
                  HtmlHelper.DefaultMenuTopItems(), context.Request
              );
        var action = context.Request.Path;// nếu có giá trị thì lấy không có thì là read
        var mesage = "";
        //var info = RequestProcess.RequestInfo(context.Request);
        if (action == "/Coockies/write")
        {
            context.Response.Cookies.Append("Maspalo", "0336237176");
        }
        else
        {
           
            var listcokie = context.Request.Cookies.Select((header) => $"{header.Key}: {header.Value}".HtmlTag("li"));
            mesage  = string.Join("", listcokie).HtmlTag("ul");

        }
        var huongdan = "<a href=\"/Cookies/read\">doc Coockies</a><br/><a href=\"/Cookies/Write\">ghi Coockies</a>\"";
        var html = HtmlHelper.HtmlDocument("Coockue, !"+action, mennu+ huongdan+ mesage);
        await context.Response.WriteAsync(html);

    });
});
app.UseAuthorization();
// /
app.MapRazorPages();

app.Run();
