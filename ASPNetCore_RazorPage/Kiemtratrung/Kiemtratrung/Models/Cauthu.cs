using System;
using System.Collections.Generic;

namespace Kiemtratrung.Models
{
    public partial class Cauthu
    {
        public Cauthu()
        {
            TrandauCauthus = new HashSet<TrandauCauthu>();
            TrandauGhibans = new HashSet<TrandauGhiban>();
        }

        public string CauThuId { get; set; } = null!;
        public string? HoVaTen { get; set; }
        public string? CauLacBoId { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public string? ViTri { get; set; }
        public string? QuocTich { get; set; }
        public string? SoAo { get; set; }
        public string? Anh { get; set; }

        public virtual Caulacbo? CauLacBo { get; set; }
        public virtual ICollection<TrandauCauthu> TrandauCauthus { get; set; }
        public virtual ICollection<TrandauGhiban> TrandauGhibans { get; set; }
    }
}
