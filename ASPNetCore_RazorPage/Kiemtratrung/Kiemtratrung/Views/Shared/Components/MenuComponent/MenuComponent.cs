using Kiemtratrung.Models;
using Microsoft.AspNetCore.Mvc;


namespace NguyenTienTrung.Views.Shared.Component.MenuComponent
{
    public class MenuComponent:ViewComponent
    {

        QLBongDaContext CLB;
        public MenuComponent(QLBongDaContext _clb)
        {
            CLB = _clb;
        }
        public IViewComponentResult Invoke()
        {

            var listMenu = CLB.Caulacbos.ToList();
            // Thiết lập Header của HTTP Respone - chuyển hướng về trang đích
            return View(listMenu);
        }
    }
}
