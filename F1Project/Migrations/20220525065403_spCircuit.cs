using Microsoft.EntityFrameworkCore.Migrations;
using System.Text;

#nullable disable

namespace F1Project.Migrations
{
    public partial class spCircuit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("CREATE PROCEDURE spCircuit");
            sb.Append(" @CIRCUIT int , @TOP int = 3");
            sb.Append(" AS");
            sb.Append(" SELECT TOP(@TOP) d.Name , count(*) [Wins]");
            sb.Append(" FROM circuits c");
            sb.Append(" INNER JOIN Results r ON c.ID = r.CircuitID");
            sb.Append(" INNER JOIN Drivers d ON r.DriverID = d.ID");
            sb.Append(" WHERE c.ID = @CIRCUIT");
            sb.Append(" GROUP BY d.Name");
            sb.Append(" ORDER BY 2 DESC");
            migrationBuilder.Sql(sb.ToString());
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE spCircuit");
            

        }
    }
}
