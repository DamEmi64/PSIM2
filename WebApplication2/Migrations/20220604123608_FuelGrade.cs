using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class FuelGrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FuelAvaliability",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Avaliable95 = table.Column<bool>(nullable: true),
                    Avaliable98 = table.Column<bool>(nullable: true),
                    AvaliableDiesel = table.Column<bool>(nullable: true),
                    AvaliableLPG = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelAvaliability", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuelGrade",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Likes = table.Column<int>(nullable: true),
                    Dislikes = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelGrade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsAdmin = table.Column<bool>(nullable: true),
                    Range = table.Column<int>(nullable: true),
                    Bonuses = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuelAvaliability");

            migrationBuilder.DropTable(
                name: "FuelGrade");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
