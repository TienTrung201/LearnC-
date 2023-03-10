using Microsoft.AspNetCore.Mvc;
using TestKiemTraWeb.Models;

namespace TestKiemTraWeb.Views.Shared.Components
{
    public class MenuComponent:ViewComponent
    {
        QLBanVaLiContext DanhMuc;
        public MenuComponent(QLBanVaLiContext _DanhMuc) {
            DanhMuc= _DanhMuc;
        }
        public IViewComponentResult Invoke()
        {

            var listMenu=DanhMuc.TLoaiSps.ToList();
            // Thiết lập Header của HTTP Respone - chuyển hướng về trang đích
            return View(listMenu);
        }
    }
}
