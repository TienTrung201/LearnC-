
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System;

namespace RazorpageWebapp
{
    public class ModelBinding:PageModel
    {
           // Binding Email từ dữ liệu từ nguồn tới có tên Email, email, emaIL ...
        [BindProperty(SupportsGet =true)]
        public UserContact userContact{set;get;}    
        public void OnGet(){
            // Console.WriteLine(userContact.Email);
            // userContact = new UserContact();
        }
    }
}