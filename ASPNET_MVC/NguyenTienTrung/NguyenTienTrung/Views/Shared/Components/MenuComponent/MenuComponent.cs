using Microsoft.AspNetCore.Mvc;
using NguyenTienTrung.Models;

namespace NguyenTienTrung.Views.Shared.Component.MenuComponent
{
    public class MenuComponent:ViewComponent
    {

        QLBanVaLiContext DanhMuc;
        public MenuComponent(QLBanVaLiContext _DanhMuc)
        {
            DanhMuc = _DanhMuc;
        }
        public IViewComponentResult Invoke()
        {

            var listMenu = DanhMuc.TChatLieus.ToList();
            // Thiết lập Header của HTTP Respone - chuyển hướng về trang đích
            return View(listMenu);
        }
    }
}
