using Microsoft.EntityFrameworkCore.Migrations;

namespace SEP3.Migrations
{
    public partial class ApplicationAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customerCredentials");

            migrationBuilder.DropTable(
                name: "ITProviderCredentials");

            migrationBuilder.DropColumn(
                name: "ApplicantUsername",
                table: "Applications");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "Applications",
                newName: "Date");

            migrationBuilder.AddColumn<string>(
                name: "Approved",
                table: "Applications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ITproviderUsername",
                table: "Applications",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approved",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "ITproviderUsername",
                table: "Applications");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Applications",
                newName: "date");

            migrationBuilder.AddColumn<string>(
                name: "ApplicantUsername",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "customerCredentials",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customerCredentials", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "ITProviderCredentials",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITProviderCredentials", x => x.Username);
                });
        }
    }
}
