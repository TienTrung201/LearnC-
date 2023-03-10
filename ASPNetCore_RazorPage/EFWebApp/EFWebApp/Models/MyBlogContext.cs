using Microsoft.EntityFrameworkCore;
namespace EFWebApp
{
    
    public class MyBlogContext:DbContext
    {
        public DbSet<Article> Articles { get; set; }

        public MyBlogContext(DbContextOptions<MyBlogContext> option):base(option){

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}