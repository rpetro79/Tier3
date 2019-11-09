using Microsoft.EntityFrameworkCore.Migrations;

namespace SEP3.Migrations
{
    public partial class pleasee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contactInfo",
                columns: table => new
                {
                    username = table.Column<string>(nullable: false),
                    address = table.Column<string>(nullable: true),
                    phoneNo = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contactInfo", x => x.username);
                });

            migrationBuilder.CreateTable(
                name: "credentials",
                columns: table => new
                {
                    username = table.Column<string>(nullable: false),
                    password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_credentials", x => x.username);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    username = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.username);
                });

            migrationBuilder.CreateTable(
                name: "ITProviders",
                columns: table => new
                {
                    username = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    review = table.Column<double>(nullable: false),
                    type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITProviders", x => x.username);
                });

            migrationBuilder.CreateTable(
                name: "technologies",
                columns: table => new
                {
                    username = table.Column<string>(nullable: true),
                    technology = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
