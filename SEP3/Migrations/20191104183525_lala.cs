using Microsoft.EntityFrameworkCore.Migrations;

namespace SEP3.Migrations
{
    public partial class lala : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contactInfo");

            migrationBuilder.DropTable(
                name: "credentials");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "ITProviders");

            migrationBuilder.DropTable(
                name: "technologies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contactInfo",
                columns: table => new
                {
                    username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contactInfo", x => x.username);
                });

            migrationBuilder.CreateTable(
                name: "credentials",
                columns: table => new
                {
                    username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_credentials", x => x.username);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.username);
                });

            migrationBuilder.CreateTable(
                name: "ITProviders",
                columns: table => new
                {
                    username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    review = table.Column<double>(type: "float", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITProviders", x => x.username);
                });

            migrationBuilder.CreateTable(
                name: "technologies",
                columns: table => new
                {
                    technology = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });
        }
    }
}
