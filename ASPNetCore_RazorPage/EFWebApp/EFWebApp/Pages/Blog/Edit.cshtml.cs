using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFWebApp;

namespace EFWebApp.Pages_Blog
{
    public class EditModel : PageModel
    {
        private readonly EFWebApp.MyBlogContext _context;

        public EditModel(EFWebApp.MyBlogContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Article Article { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Articles == null)
            {
                return NotFound();
            }

            var article = await _context.Articles.FirstOrDefaultAsync(m => m.ID == id);

            if (article == null)
            {
                return NotFound();
            }
            Article = article;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //ModelState.IsValid kiểm tra xem liệu có lỗi nào trong quá trình binding dữ liệu từ
            // form gửi lên hay không. Nếu có lỗi, phương thức sẽ trả về trang hiện tại.

            if (!ModelState.IsValid)
            {
                return Page();
            }
            // Tìm Article theo ID, nạp dữ liệu của Article từ form gửi lên vào trong Article đã tìm được
            // Bằng cách sử dụng Attach() để nạp dữ liệu và sử dụng EntityState.Modified để đánh dấu là
            // đối tượng đã bị sửa đổi trong context


            _context.Attach(Article).State = EntityState.Modified;


            //Articld đang nhận dữ liệu đưuọc binding đưungs độc lập
            //sử dụng  _context.Attach(Article).State  để nạp vào thiết lập trạng thái bị sửa đổi
            // tìm đưuọc article mới và so sánh  trong csdl để thay đổi
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleExists(Article.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ArticleExists(int id)
        {
            return (_context.Articles?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
