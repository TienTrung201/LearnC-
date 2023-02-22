using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HocMigration.Model
{
    public class Webcontext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ArticleTag> articleTags {set; get;}
        private const string connectionString = @"Data Source=DESKTOP-0I9BVNB\TRUNG;Initial Catalog=Migration;Integrated Security=True;TrustServerCertificate=True;";
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder
                   //    .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Warning)
                   //    .AddFilter(DbLoggerCategory.Query.Name, LogLevel.Debug)
                   .AddConsole();

        }
       );
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString)
                .UseLoggerFactory(loggerFactory);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ArticleTag>(entity=>{
                entity.HasIndex(articleTag =>new {articleTag.ArticleId,articleTag.TagID})
                    .IsUnique();
                    
            });
        }
    }
}
