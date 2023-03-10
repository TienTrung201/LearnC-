using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly MyBlogContext myBlogContext;
        public IndexModel(ILogger<IndexModel> logger, MyBlogContext _blogContext)
        {
            _logger = logger;
            myBlogContext=_blogContext;
        }

        public void OnGet()
        {
            var posts=(from p in myBlogContext.Articles select p).ToList();
            ViewData["Posts"]=posts;
        }
    }
}