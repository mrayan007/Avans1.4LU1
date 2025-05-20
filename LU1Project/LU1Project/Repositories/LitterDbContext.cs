using Microsoft.EntityFrameworkCore;
using LU1Project.Models;

namespace LU1Project.Repositories;
    public class LitterDbContext : DbContext
    {
    public LitterDbContext(DbContextOptions<LitterDbContext> options) : base(options) { }
            public DbSet<Litter> Litter { get; set; }
    }
