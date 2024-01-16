using Microsoft.EntityFrameworkCore;

namespace WebApplication6.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }

        public DbSet<registration> regist { get; set; }
        public DbSet<employe> employes { get; set; }
        public DbSet<drug> drugs { get; set; }
        public DbSet<usagecs> usages { get; set; }
        public DbSet<agent> agent { get; set; }
        public DbSet<alergic> alergicsym { get; set; }
        public DbSet<antialergy> antialergy{ get; set; }

    }
}
