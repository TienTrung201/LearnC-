using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EF1
{
    //[Table("Products")] fluentAPI k  cần actibute ở  đây
    public class Product
    {
        [Key]
        public int ProductId { set; get; }

        [Required]// bắt buộc khác null
        [StringLength(50)]
        [Column("Tensanpham",TypeName="ntext")]
        public string Name { set; get; }
        [Column("GiaTien",TypeName = "money")]
        public decimal Price { set; get; }
        //Fk
        public int CateID { set; get; }// dấu hỏi có thể là null
        [ForeignKey("CateID")]// cách để tự tạo tên cột fk là CategId
        //[Required]
        public Category Category { get; set; }// tự động tạo FK cột teen là CategoryId giống bảng kết nối
        //Fk


        public int? CateID2 { set; get; }// dấu hỏi có thể là null 1 trong 2 phải là null
        [ForeignKey("CateID2")]// cách để tự tạo tên cột fk là CategId
        //[Required]
        [InverseProperty("Products")]// khi lấy ra category thì lấy ra list product của nó
        public Category Category2 { get; set; }// tự động tạo FK cột teen là CategoryId giống bảng kết nối
       
        public override string ToString() => $"{Name}  {Price}";
    }
}