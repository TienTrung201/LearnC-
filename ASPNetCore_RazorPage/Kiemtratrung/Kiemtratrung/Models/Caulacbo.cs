using System;
using System.Collections.Generic;

namespace Kiemtratrung.Models
{
    public partial class Caulacbo
    {
        public Caulacbo()
        {
            Cauthus = new HashSet<Cauthu>();
            TrandauClbkhachNavigations = new HashSet<Trandau>();
            TrandauClbnhaNavigations = new HashSet<Trandau>();
            TrandauGhibans = new HashSet<TrandauGhiban>();
        }

        public string CauLacBoId { get; set; } = null!;
        public string? TenClb { get; set; }
        public string? TenGoi { get; set; }
        public string? SanVanDongId { get; set; }
        public string? HuanLuyenVienId { get; set; }

        public virtual Huanluyenvien? HuanLuyenVien { get; set; }
        public virtual Sanvandong? SanVanDong { get; set; }
        public virtual ICollection<Cauthu> Cauthus { get; set; }
        public virtual ICollection<Trandau> TrandauClbkhachNavigations { get; set; }
        public virtual ICollection<Trandau> TrandauClbnhaNavigations { get; set; }
        public virtual ICollection<TrandauGhiban> TrandauGhibans { get; set; }
    }
}
