using System;
using System.Collections.Generic;

namespace Kiemtratrung.Models
{
    public partial class Sanvandong
    {
        public Sanvandong()
        {
            Caulacbos = new HashSet<Caulacbo>();
            Trandaus = new HashSet<Trandau>();
        }

        public string SanVanDongId { get; set; } = null!;
        public string? TenSan { get; set; }
        public string? ThanhPho { get; set; }
        public int? NamBatDau { get; set; }
        public string? Anh { get; set; }

        public virtual ICollection<Caulacbo> Caulacbos { get; set; }
        public virtual ICollection<Trandau> Trandaus { get; set; }
    }
}
