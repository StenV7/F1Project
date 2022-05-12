using F1Lib.ViewModels;
using F1Lib.Models;
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

        //stappen voor viewModel toevoegen:
        //add-migration, voeg sql in de up methode, en doorstuur aan de down methode
        //string view "SELECT "
        //view+= " * FROM... etc"
        //migrationBuilder.Sql(view);
        //migrationBuilder.Sql(@"DROP VIEW vwRooster");
        //Elke ViewModel heeft een eigen DbSet nodig.
        public DbSet<SeasonVM> SeasonVMs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) //onmodelcreating voegt
        {
            base.OnModelCreating(builder);
            builder.Entity<SeasonVM>().ToView("vwRaces").HasNoKey();
            //builder.Entity<-----Naam van ViewModel----->().ToView("----Naam van Db View----").HasNoKey();

        }

        public ApplicationDbContext(DbContextOptions options) : base(options) { }
    }
}
