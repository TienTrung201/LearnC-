using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HocMigration.Model
{
    [Table("articletag")]
    public class ArticleTag// mỗi quan hệ nhiều nhiều
    {
        [Key]
        public int ArticleTagId { get; set; }
        public int  TagID { get; set; }
        [ForeignKey("TagID")]
        public Tag Tag { get; set; } 

          public int ArticleId {set; get;}
        [ForeignKey("ArticleId")]
        public Article article {set; get;}

    }
}