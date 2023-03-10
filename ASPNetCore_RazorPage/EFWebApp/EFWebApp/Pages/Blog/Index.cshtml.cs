using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EFWebApp;

namespace EFWebApp.Pages_Blog
{
    public class IndexModel : PageModel
    {
        private readonly EFWebApp.MyBlogContext _context;

        public IndexModel(EFWebApp.MyBlogContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get;set; } = default!;

        public async Task OnGetAsync(string? searchString)
        {
            if (_context.Articles != null)
            {
                // Article = await _context.Articles.ToListAsync();

                var aritcles= from a in _context.Articles orderby a.Created descending select a;
                if(searchString!=null){
                    Article= aritcles.Where(a=>a.Title.Contains(searchString)).ToList();
                }else{
                    Article=await aritcles.ToListAsync();
                }
                
                
            }
        }
    }
}
