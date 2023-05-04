using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PhamTrungKien.Models
{
    public partial class QLBongDaContext : DbContext
    {
        public QLBongDaContext()
        {
        }

        public QLBongDaContext(DbContextOptions<QLBongDaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Caulacbo> Caulacbos { get; set; } = null!;
        public virtual DbSet<Cauthu> Cauthus { get; set; } = null!;
        public virtual DbSet<Huanluyenvien> Huanluyenviens { get; set; } = null!;
        public virtual DbSet<Sanvandong> Sanvandongs { get; set; } = null!;
        public virtual DbSet<Trandau> Trandaus { get; set; } = null!;
        public virtual DbSet<TrandauCauthu> TrandauCauthus { get; set; } = null!;
        public virtual DbSet<TrandauGhiban> TrandauGhibans { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-0I9BVNB\\TRUNG;Initial Catalog=QLBongDa;Integrated Security=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Caulacbo>(entity =>
            {
                entity.ToTable("CAULACBO");

                entity.Property(e => e.CauLacBoId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CauLacBoID")
                    .IsFixedLength();

                entity.Property(e => e.HuanLuyenVienId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("HuanLuyenVienID")
                    .IsFixedLength();

                entity.Property(e => e.SanVanDongId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SanVanDongID")
                    .IsFixedLength();

                entity.Property(e => e.TenClb)
                    .HasMaxLength(80)
                    .HasColumnName("TenCLB");

                entity.Property(e => e.TenGoi)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.HuanLuyenVien)
                    .WithMany(p => p.Caulacbos)
                    .HasForeignKey(d => d.HuanLuyenVienId)
                    .HasConstraintName("FK_CAULACBO_HUANLUYENVIEN");

                entity.HasOne(d => d.SanVanDong)
                    .WithMany(p => p.Caulacbos)
                    .HasForeignKey(d => d.SanVanDongId)
                    .HasConstraintName("FK_CAULACBO_SANVANDONG");
            });

            modelBuilder.Entity<Cauthu>(entity =>
            {
                entity.ToTable("CAUTHU");

                entity.Property(e => e.CauThuId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CauThuID")
                    .IsFixedLength();

                entity.Property(e => e.Anh)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CauLacBoId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CauLacBoID")
                    .IsFixedLength();

                entity.Property(e => e.HoVaTen).HasMaxLength(40);

                entity.Property(e => e.Ngaysinh)
                    .HasColumnType("datetime")
                    .HasColumnName("NGAYSINH");

                entity.Property(e => e.QuocTich)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.SoAo)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ViTri)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.CauLacBo)
                    .WithMany(p => p.Cauthus)
                    .HasForeignKey(d => d.CauLacBoId)
                    .HasConstraintName("FK_CAUTHU_CAULACBO");
            });

            modelBuilder.Entity<Huanluyenvien>(entity =>
            {
                entity.ToTable("HUANLUYENVIEN");

                entity.Property(e => e.HuanLuyenVienId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("HuanLuyenVienID")
                    .IsFixedLength();

                entity.Property(e => e.Anh)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.QuocTich).HasMaxLength(40);

                entity.Property(e => e.TenHlv)
                    .HasMaxLength(40)
                    .HasColumnName("TenHLV");
            });

            modelBuilder.Entity<Sanvandong>(entity =>
            {
                entity.ToTable("SANVANDONG");

                entity.Property(e => e.SanVanDongId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SanVanDongID")
                    .IsFixedLength();

                entity.Property(e => e.Anh)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TenSan).HasMaxLength(60);

                entity.Property(e => e.ThanhPho)
                    .HasMaxLength(30)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Trandau>(entity =>
            {
                entity.ToTable("TRANDAU");

                entity.Property(e => e.TranDauId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TranDauID")
                    .IsFixedLength();

                entity.Property(e => e.Clbkhach)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CLBKhach")
                    .IsFixedLength();

                entity.Property(e => e.Clbnha)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CLBNha")
                    .IsFixedLength();

                entity.Property(e => e.HiepPhu).HasColumnType("datetime");

                entity.Property(e => e.KetQua).HasMaxLength(30);

                entity.Property(e => e.NgayThiDau).HasColumnType("datetime");

                entity.Property(e => e.SanVanDongId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SanVanDongID")
                    .IsFixedLength();

                entity.HasOne(d => d.ClbkhachNavigation)
                    .WithMany(p => p.TrandauClbkhachNavigations)
                    .HasForeignKey(d => d.Clbkhach)
                    .HasConstraintName("FK_TRANDAU_CLBKHACH");

                entity.HasOne(d => d.ClbnhaNavigation)
                    .WithMany(p => p.TrandauClbnhaNavigations)
                    .HasForeignKey(d => d.Clbnha)
                    .HasConstraintName("FK_TRANDAU_CLBNHA");

                entity.HasOne(d => d.SanVanDong)
                    .WithMany(p => p.Trandaus)
                    .HasForeignKey(d => d.SanVanDongId)
                    .HasConstraintName("FK_TRANDAU_SANVANDONG");
            });

            modelBuilder.Entity<TrandauCauthu>(entity =>
            {
                entity.HasKey(e => new { e.TranDauId, e.CauThuId })
                    .HasName("PK__TRANDAU_CAUTHU__07F6335A");

                entity.ToTable("TRANDAU_CAUTHU");

                entity.Property(e => e.TranDauId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TranDauID")
                    .IsFixedLength();

                entity.Property(e => e.CauThuId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CauThuID")
                    .IsFixedLength();

                entity.Property(e => e.PhamLoi)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.CauThu)
                    .WithMany(p => p.TrandauCauthus)
                    .HasForeignKey(d => d.CauThuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TRANDAU_CAUTHU_CAUTHU");

                entity.HasOne(d => d.TranDau)
                    .WithMany(p => p.TrandauCauthus)
                    .HasForeignKey(d => d.TranDauId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TRANDAU_CAUTHU_TRANDAU");
            });

            modelBuilder.Entity<TrandauGhiban>(entity =>
            {
                entity.HasKey(e => e.GhiBanId)
                    .HasName("PK__TRANDAU_GHIBAN__060DEAE8");

                entity.ToTable("TRANDAU_GHIBAN");

                entity.Property(e => e.GhiBanId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GhiBanID")
                    .IsFixedLength();

                entity.Property(e => e.CauLacBoId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CauLacBoID")
                    .IsFixedLength();

                entity.Property(e => e.CauThuId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CauThuID")
                    .IsFixedLength();

                entity.Property(e => e.TranDauId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TranDauID")
                    .IsFixedLength();

                entity.HasOne(d => d.CauLacBo)
                    .WithMany(p => p.TrandauGhibans)
                    .HasForeignKey(d => d.CauLacBoId)
                    .HasConstraintName("FK_TRANDAU_GHIBAN_CAULACBO");

                entity.HasOne(d => d.CauThu)
                    .WithMany(p => p.TrandauGhibans)
                    .HasForeignKey(d => d.CauThuId)
                    .HasConstraintName("FK_TRANDAU_GHIBAN_CAUTHU");

                entity.HasOne(d => d.TranDau)
                    .WithMany(p => p.TrandauGhibans)
                    .HasForeignKey(d => d.TranDauId)
                    .HasConstraintName("FK_TRANDAU_GHIBAN_TRANDAU");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
