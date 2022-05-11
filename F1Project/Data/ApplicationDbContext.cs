using F1Project.Models;
using Microsoft.EntityFrameworkCore;

namespace F1Project.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Circuit> Circuits { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Grandprix> Grandprix { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Driver> Drivers { get; set; }
    
    public ApplicationDbContext(DbContextOptions options) : base(options) { }
    }
}
