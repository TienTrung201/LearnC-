# ASP.NET CORE MVC

## 1. Đối với các trang Razor

- Vẫn có thể truy cập trực tiếp đến các
  trang Razor page:

```cs
builder.Services.AddRazorPages();
app.MapRazorPages();
```

## 2. Đối với Controller

### Route

    pattern: "{controller=Home}/{action=Index}/{id?}"
    => url: /{controller}/{action}/{id?}
    - Nếu không chỉ định thì mặc định controller và action là:
    url: /Home/Index

    Trong đó:
    - Controller: là lớp kế thừa từ Microsoft.AspNetCore.Mvc.Controller

    - Action: là phương thức trong Controller

### Controller có đầy đủ các thông tin của HTTP giống như Page Model:

    - this.HttpContext
    - this.Request
    - this.Response
    - this.RouteData

    - this.User
    - this.ModelState
    - this.ViewData
    - this.ViewBag
    - this.Url  -> (Url helper)
    - this.TempData

### Inject các dịch vụ qua phương thức khởi tạo

    - Inject logger để sử dụng thay vì Console.Writeline
    Ilogger<Controller> logger

    - Sử dụng với nhiều cấp độ logger:
    logger.LogInformation("")
    logger.LogWarning("")
    logger.LogError("")
    logger.LogDebug("")
    logger.LogCritical("")

### Action

- Là một phương thức public có thể trả về
  bất cứ kiểu dữ liệu gì (kể cả void), nội dung trả về từ
  action sẽ được tự động convert thành chuỗi và trả về
  cho client

    - Kiểu trả về | Phương thức
    ---
    - ContentResult | Content()
    - EmptyResult | new EmptyResult()
    - FileResult | File()
    - ForbidResult | Forbid()
    - JsonResult | Json()
    - LocalRedirectResult | LocalRedirect()
    - RedirectResult | Redirect()
    - RedirectToActionResult | RedirectToAction()
    - RedirectToPageResult | RedirectToRoute()
    - RedirectToRouteResult | RedirectToPage()
    - PartialViewResult | PartialView()
    - ViewComponentResult | ViewComponent()
    - StatusCodeResult | StatusCode()
    - ViewResult | View() **

    => Các ví dụ về kiểu trả về trong FirstController

- Với ViewResult
    - Nếu truyền ViewName là đường dẫn thì có thể lưu View
      ở bất cứ thư mục nào trong project
      View(ViewName)
    - Truyền Model vào View bằng tham số thứ 2
      View(ViewName, Model)
    return View("/MyView/XinChao.cshtml", username);
    
    - Nếu chỉ truyền ViewName thì sẽ tìm
      trong /View/First/xinchao.cshtml
    return View("XinChao", username);
    
    - Nếu không truyền ViewName thì sẽ tìm
      file trùng tên với Action tại đường dẫn:
      /View/First/HelloView.cshtml
      Để truyền Model kiểu string thì phải
      ép kiểu sang object (vì string tham số
      đầu tiên mặc định là ViewName)
    return View((object)username);

    - Cấu hình nơi lưu trữ View thứ 2:
      Nếu không tìm thấy trong
      /View/Controller/Action.cshtml
      thì tìm trong nơi lưu trữ thứ 2
      /MyView/Controller/Action.cshtml
        builder.Services.Configure<RazorViewEngineOptions>(options =>
        {
            // {0} -> Tên Action
            // {1} -> Tên Controller
            // {2} -> Tên Area
            // RazorViewEngine.ViewExtension tương đương .cshtml

            options.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);
        });

### Truyền dữ liệu

- Truyền dữ liệu qua Model: return View(model);

- ViewData["key"]=value
  ViewData có thể truyền từ View con sang View cha (Layout)

- ViewBag là đối tượng có kiểu dynamic 
  nên có thể thêm thuộc tính bất kỳ
  VD: ViewBag.product = product

- TempData["key"]=value
  hoặc khai báo property
  [TempData]
  public string key { set; get;}

  sử dụng Session để lưu dữ liệu, có thể
  truyền dữ liệu từ trang này qua trang khác
  khi đọc dữ liệu xong thì được xóa luôn


---
# ROUTE

- app.MapControllers
- app.MapControllerRoute
- app.MapDefaultControllerRoute
- app.MapAreaControllerRoute

## 1. Sử dụng app.MapControllerRoute
Tạo URL endpoint đến các controllers

- Sử dụng defaults để chỉ định Route này
  truy cập đến controller nào, mặc định có các thuộc tính:
  - controller: "tên controller"
  - action: "tên action"
  - area: "tên area"
  Lúc này chỉ cần truy cập: /start-here
    app.MapControllerRoute(
        name: "firstroute",
        pattern: "start-here",
        defaults: new
        {
            controller="First",
            action= "ProductView",
            id=3
 	    }
     );

- Có thể chỉ định các thuộc tính của default
  ngay trong pattern:
  Lúc này truy cập: 
  /start-here/first/productview/1
  Có thể đặt controller, action mặc định
  bằng cách sử dụng defaults hoặc đặt ngay trong pattern
  VD: controller=Home
    app.MapControllerRoute(
	    name: "firstroute",
	    pattern: "start-here/{controller=Home}/{action=Index}/{id?}",
	    defaults: new
	    {
		    //controller = "First",
		    //action = "ProductView",
		    //id = 3
	    }
	 );

- Đặt các constraint ràng buộc các tham số của route
  có thể sử dụng tham số constraints hoặc đặt ngay trong pattern
  VD: id:range(1,4)
    app.MapControllerRoute(
        name: "first",
        pattern: "{url}/{id:range(1,4)?}",
        defaults: new
        {
            controller = "First",
            action = "ProductView"
	    },
        constraints: new
        {
            //url = new StringRouteConstraint("xemsanpham")
            // tương đương với: 
            //url="xemsanpham"
            // Xem thêm các ràng buộc khác trong thư viện:
            // Microsoft.AspNetCore.Routing.Constraints
        }
    );

## 2. [AcceptVerbs("")]
Chỉ ra phương thức truy cập (GET, POST, PUT,...)
cho các action, có thể thêm nhiều phương thức truy cập

VD: [AcceptVerbs("POST")] chỉ có thể truy cập bằng phương thức POST

## 3. Sử dụng app.MapControllers - [Route]

(Bổ sung): Để sử dụng TagHelper link (thẻ <a></a>)
với Controller:
<a asp-controller="Planet" asp-action="Index"></a>
(Nếu được mở view trực tiếp từ Controller Planet
thì không cần thêm thuộc tính asp-controller)

- Có thể ánh xạ Route bằng cách thêm attribute
[Route("pattern")] vào mỗi action, lúc này
app.MapControllerRoute sẽ không còn ảnh hưởng

- Thêm các token: controller, action, area
vào trong pattern bằng cú pháp:
[controller], [action], [area]
(Dùng ngoặc {} có thể gán giá trị mặc định)

- Nếu một action có nhiều attribute [Route]
thì tất cả các Route đó đều có tác dụng
-> Có thể truy cập theo Route nào cũng được
    - Framework tự động chọn Route để phát sinh Url
    nếu muốn chỉ định độ ưu tiên thì thêm tham số
    Order vào [Route]

- Có thể phát sinh Url dựa trên tên của Route:
@Url.RouteUrl("Tên Route")

- Cũng có thể thêm [Route] ở Controller,lúc này
Route ở Controller và Action sẽ kết hợp với nhau,
(nhưng nếu Route ở Action bắt đầu băng "/" thì không
kết hợp với nhau)
    - Khi đặt [Route] ở Controller thì phải
    đặt [Route] ở action hoặc thêm token "[action]"
    ở [Route] Controller nếu không sẽ LỖI

## 4. Sử dụng [HttpGet], [HttpPost], ...
- Cách sử dụng tương tự như [Route]
nhưng giới hạn phương thức truy cập
VD: [HttpPost] chỉ có thể truy cập bằng phương thức Post

## 5. Sử dụng cấu trúc thư mục với Area
- Khi dự án quá lớn muốn tổ chức lại một cách gọn gàng
- Thêm [Area("AreaName")] vào Controller
- View lúc này được tìm trong thư mục:
  /Areas/AreaName/Views/ControllerName/Action.cshtml
- Để tự động tạo cấu trúc thư mục Area: 
  dotnet aspnet-codegenerator area AreaName

## 6. Sử dụng Url Helpers
- Đối tượng tồn tại trong Controller và View
- Các loại Url Helpers:
    - Url.ActionLink() giống Url.Action nhưng có thêm Host Name
    - Url.Action() VD: Url.Action("ControllerName","ActionName", new { area="AreaName" id=123, name="xuanphuc"})
    -> (Nếu không có tham số thì mặc định truy cập đến
       controller và action hiện tại)

    - Url.RouteUrl()
    - Url.Link()

- tagHelpers asp-all-route-data
@{
    var routeData = new Dictionary<string, string>(){
        {"name", "xuanphuc"},
        {"id", "3"}
    }
}

<a asp-all-route-data="@routeData">VD</a>
Tương đương với:
<a route-data-name="xuanphuc">VD</a>
<a route-data-id="@routeData">VD</a>

- (Bonus) có thể inject model ngay trong view không cần qua controller:
    @inject MyMvcContext myMvcContext

## 7. Các câu lệnh phát sinh Area, Controller, View
- Để tự động tạo cấu trúc thư mục Area: 
  dotnet aspnet-codegenerator area AreaName

- Tự động tạo Controller và View (CRUD)
  dotnet aspnet-codegenerator controller -name ControllerName -namespace NameSpace -m ModelName -dc DbContextName -udl -outDir Areas/Contact/Controllers/

  VD:
  dotnet aspnet-codegenerator controller -name ContactController -namespace AspNetCoreMvc.Areas.Contact.Controllers -m ContactModel -dc MyMvcContext -udl -outDir Areas/Contact/Controllers/