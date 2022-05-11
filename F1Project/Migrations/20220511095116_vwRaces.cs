using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace F1Project.Migrations
{
    public partial class vwRaces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string view = "CREATE VIEW vwRaces";
            view += " AS";
            view += " SELECT[Year], Count([Racenumber]) AS";
            view += " 'Races' FROM Results";
            view += " GROUP BY[Year]";

            migrationBuilder.Sql(view);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW vwRaces");

        }
    }
}
