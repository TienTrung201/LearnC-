using System;
using System.ComponentModel.DataAnnotations;

namespace RazorpageWebapp
{
    public class Article
    {// ID sẽ là Primary Key khi lưu trong Db
        [Key]
        public int ID { get; set; }
        [Display(Name="Tiêu đề")]
        public string Title { get; set; }

        [Display(Name="Ngày đăng")]
        
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }

        [Display(Name="Nội dung")]
        public string Content {set; get;}
    }
}