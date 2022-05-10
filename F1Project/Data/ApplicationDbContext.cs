using F1Project.Models;
using Microsoft.EntityFrameworkCore;

namespace F1Project.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Country> Country { get; set; }
        public DbSet<Circuit> Circuit { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Grandprix> Grandprix { get; set; }
        public DbSet<Result> Result { get; set; }
        public DbSet<Driver> Driver { get; set; }
    
    public ApplicationDbContext(DbContextOptions options) : base(options) { }
    }
}
