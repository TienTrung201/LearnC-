using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace RazorpageWebapp
{
    public class UserContact

    {
        [BindProperty(SupportsGet =true)]// tím kiếm các nguồn gửi đến thấy thì sẽ đọc được
        [EmailAddress(ErrorMessage ="Email sai định dạng")]
        public string Email { get; set; }

        // Binding cho UserId từ nguồn gửi đến, dữ liệu nguồn có tên username
        [BindProperty (SupportsGet =true)]
        // [BindProperty (Name = "username",SupportsGet =true)]
        [DisplayName("Id của bạn")]
        [Range(10,100,ErrorMessage ="nhap sai" )]
        public int UserId { set; get; }

        // Binding ProductID - thiết lập BINDING ngay cả khi truy cập là HTTP GÉT
        
        [BindProperty(SupportsGet=true)]
        public int ProductID { set; get; }

        // Binding Color
        // [BindProperty]
        // public string Color { set; get; }    
    }
    
}