using Microsoft.EntityFrameworkCore;
using SecondTask.Model;

namespace SecondTask
{
    public class AppDbContext : DbContext
    {
        public DbSet<Url> urls { get; set; }
        
       public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

         protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Url>().ToTable("url");
            builder.Entity<Url>().HasKey(p => p.Short);
            builder.Entity<Url>().Property(p => p.Long).IsRequired();
            builder.Entity<Url>().Property(p => p.Short).IsRequired();
        
        }
    
    }

}

