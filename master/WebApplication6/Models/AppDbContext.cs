using Microsoft.EntityFrameworkCore;

namespace WebApplication6.Models
{
    public partial class AppDbContext : DbContext
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
     => optionsBuilder.UseSqlServer("server=ASJAL_PC\\SQLEXPRESS; Database=first; Trusted_Connection=True; MultipleActiveResultSets=True;Encrypt=False;");

    }
}
