using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;


namespace EF1
{
    public class shopContext : DbContext
    {
           // Tạo ILoggerFactory 
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => {
        builder
            //    .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Warning)
            //    .AddFilter(DbLoggerCategory.Query.Name, LogLevel.Debug)
               .AddConsole();

            }
        ); 

  


        // Thuộc tính products kiểu DbSet<Product> cho biết CSDL có bảng mà
        // thông tin về bảng dữ liệu biểu diễn bởi model Product
        public DbSet<Product> products {set; get;}//bẳng biểu diễn sp product mỗi dòng tương ứng 1 pt product   
        public DbSet<Category> categories { set; get; }   // bảng Category

        // Chuỗi kết nối tới CSDL (MS SQL Server)
        private const string connectionString2 = @"
                Data Source=localhost,1433;
                Initial Catalog=mydata;
                User ID=SA;Password=Password123";
        private const string connectionString = @"Data Source=DESKTOP-0I9BVNB\TRUNG;Initial Catalog=datanew;Integrated Security=True;TrustServerCertificate=True;";
        // Phương thức OnConfiguring gọi mỗi khi một đối tượng DbContext được tạo
        // Nạp chồng nó để thiết lập các cấu hình, như thiết lập chuỗi kết nối
        protected override void  OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder
                .UseSqlServer(connectionString)
                .UseLoggerFactory(loggerFactory);  
      
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //fluent API
            // var entity = modelBuilder.Entity(typeof(Product));

            modelBuilder.Entity<Product>(entity =>
            {
                //entity
                entity.ToTable("Product");
                //key 
                entity.HasKey(p => p.ProductId);

                //index
                entity.HasIndex(p => p.Price).HasDatabaseName("IndexPrice");//đây là factory nên trả về modelbuider có thể .tiếptucthietlap

                //relative 1-n
                entity.HasOne(p => p.Category).WithMany()
                        .HasForeignKey("CateId")//p là 1 category là nhiều
                         .OnDelete(DeleteBehavior.NoAction)//cascade xóa 1 thì phần nhiều ảnh hưởng, setnull là cadeID có khả năng nhận null chứ k xóa
                           .HasConstraintName("Khoangoaigiua2bang");

                entity.HasOne(p => p.Category2).WithMany(c=>c.products)
                        .HasForeignKey("CateId2")//p là 1 category là nhiều
                         .OnDelete(DeleteBehavior.NoAction)//cascade xóa 1 thì phần nhiều ảnh hưởng, setnull là cadeID có khả năng nhận null chứ k xóa
                           .HasConstraintName("Khoangoaigiua2bang");

                entity.Property(p => p.Name)
                .IsRequired(false)
                .HasDefaultValue("ten cac san pham mac dinh")
                .HasMaxLength(50)
                .HasColumnType("nvarchar");
            });

        }

    }
}