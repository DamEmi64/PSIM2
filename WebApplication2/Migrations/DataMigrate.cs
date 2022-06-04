using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class Comment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StationID = table.Column<int>(nullable: true),
                    UserID = table.Column<int>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                });
            migrationBuilder.CreateTable(
             name: "User",
             columns: table => new
             {
                 Id = table.Column<int>(nullable: false)
                     .Annotation("SqlServer:Identity", "1, 1"),
                 Login = table.Column<string>(nullable: true),
                 Password = table.Column<string>(nullable: true),
                 Name = table.Column<string>(nullable: true),
                 Surname = table.Column<string>(nullable: true),
                 Email = table.Column<string>(nullable: true),
                 Locaction = table.Column<string>(nullable: true),
                 Role = table.Column<int>(nullable: true)
             },
             constraints: table =>
             {
                 table.PrimaryKey("PK_User", x => x.Id);
             });
            migrationBuilder.DropColumn(
                 name: "Role",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "User",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Station",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    OpenHours = table.Column<string>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    AdresID = table.Column<int>(nullable: true),
                    Grade = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Station", x => x.Id);
                });
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
                name: "Comment");
            migrationBuilder.DropTable(
            name: "User");
            migrationBuilder.DropTable(
            name: "Station");
            migrationBuilder.DropColumn(
                name: "Role",
                table: "User");
            migrationBuilder.DropTable(
             name: "Station");
            migrationBuilder.DropColumn(
                name: "Role",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "User",
                type: "int",
                nullable: true);
            migrationBuilder.DropTable(
            name: "FuelAvaliability");

            migrationBuilder.DropTable(
                name: "FuelGrade");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
