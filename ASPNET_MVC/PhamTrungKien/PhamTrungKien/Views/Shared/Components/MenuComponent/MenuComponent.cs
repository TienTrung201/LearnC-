using Microsoft.AspNetCore.Mvc;
using PhamTrungKien.Models;

namespace PhamTrungKien.Views.Shared.Components
{
	

	public class MenuComponent: ViewComponent
	{
		QLBongDaContext context;
		public MenuComponent(QLBongDaContext _context)
		{
            context = _context;
		}
		public IViewComponentResult Invoke()
		{

			var listMenu = context.Sanvandongs.Take(7).ToList();
			// Thiết lập Header của HTTP Respone - chuyển hướng về trang đích
			return View(listMenu);
		}

	}
}
