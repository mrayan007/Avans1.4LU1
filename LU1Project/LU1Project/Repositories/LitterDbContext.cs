using Microsoft.EntityFrameworkCore;
using LU1Project.Models;
using LU1Project.Configurations;

namespace LU1Project.Repositories
{
    public class LitterDbContext : DbContext
    {
        public LitterDbContext(DbContextOptions<LitterDbContext> options) : base(options) { }

        public DbSet<Litter> Litter { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LitterConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
