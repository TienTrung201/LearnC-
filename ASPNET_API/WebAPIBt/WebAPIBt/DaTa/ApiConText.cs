using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using WebAPIBt.Model;

namespace WebAPIBt.DaTa
{
    public class ApiContext: DbContext
    {
        public DbSet<KhachHang> KhachHang { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KhachHang>()
        .HasKey(kh => kh.MaKH);
        }
    }
}
