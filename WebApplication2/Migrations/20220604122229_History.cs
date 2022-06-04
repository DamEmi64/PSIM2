using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class History : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                                       name: "History",
                                       columns: table => new
                                       {
                                           stationID = table.Column<int>(nullable: false),
                                           userID = table.Column<int>(nullable: false),
                                           FuelAvaliabilityID = table.Column<int>(nullable: true),
                                           prize95 = table.Column<decimal>(nullable: true),
                                           prize98 = table.Column<decimal>(nullable: true),
                                           prizeLPG = table.Column<decimal>(nullable: true),
                                           prizeDiesel = table.Column<decimal>(nullable: true),
                                           date = table.Column<string>(nullable: true),
                                           fuelGradeID = table.Column<int>(nullable: true)
                                       },
                                       constraints: table =>
                                       {
                                           table.PrimaryKey("PK_History_ID", x => x.userID);
                                       });
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
            name: "History");
        }
    }
}
