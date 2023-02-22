using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HocMigration.Model
{
    public class Tag
    {
        // [Key]

        // public int TagId { set; get; }
        [Column(TypeName = "ntext")]
        public string Content { set; get; }
        [Key]
        public int TagID { set; get; }
    }
}
