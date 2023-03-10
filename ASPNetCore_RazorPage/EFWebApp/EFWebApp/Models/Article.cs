using System;
using System.ComponentModel.DataAnnotations;

namespace EFWebApp
{
    //dotnet aspnet-codegenerator razorpage -m EFWebApp.Article -dc EFWebApp.MyBlogContext -outDir Pages/Blog --useDefaultLayout --referenceScriptLibraries

    // dotnet aspnet-codegenerator razorpage -m EFWebApp.Article -dc EFWebApp.MyBlogContext -outDir Pages/Blog --udl --referenceScriptLibraries
    public class Article
    {// ID sẽ là Primary Key khi lưu trong Db
        [Key]
        public int ID { get; set; }
        [StringLength(255,MinimumLength =5,ErrorMessage ="{0} phải dài từ {2} đến {1}")]
        [Required(ErrorMessage ="{0} Không được để trống")]
        [Display(Name="Tiêu đề")]
        public string? Title { get; set; }
        [Required(ErrorMessage ="{0} Không được để trống")]

        [Display(Name="Ngày đăng")]
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }
        [Required(ErrorMessage ="{0} Không được để trống")]
        [Display(Name="Nội dung")]
        public string? Content {set; get;}
    }
}