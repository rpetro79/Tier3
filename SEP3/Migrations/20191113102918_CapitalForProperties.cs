using Microsoft.EntityFrameworkCore.Migrations;

namespace SEP3.Migrations
{
    public partial class CapitalForProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "username",
                table: "technologies",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "technology",
                table: "technologies",
                newName: "Technology");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "technologies",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "ITProviders",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "review",
                table: "ITProviders",
                newName: "Review");

            migrationBuilder.RenameColumn(
                name: "noOfReviews",
                table: "ITProviders",
                newName: "NoOfReviews");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "ITProviders",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "ITProviders",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "ITProviders",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "ITProviderCredentials",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "ITProviderCredentials",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "customers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "customers",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "customers",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "customerCredentials",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "customerCredentials",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "phoneNo",
                table: "contactInfo",
                newName: "PhoneNo");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "contactInfo",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "contactInfo",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "contactInfo",
                newName: "Username");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "technologies",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Technology",
                table: "technologies",
                newName: "technology");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "technologies",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "ITProviders",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Review",
                table: "ITProviders",
                newName: "review");

            migrationBuilder.RenameColumn(
                name: "NoOfReviews",
                table: "ITProviders",
                newName: "noOfReviews");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ITProviders",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "ITProviders",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "ITProviders",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "ITProviderCredentials",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "ITProviderCredentials",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "customers",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "customers",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "customers",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "customerCredentials",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "customerCredentials",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "PhoneNo",
                table: "contactInfo",
                newName: "phoneNo");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "contactInfo",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "contactInfo",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "contactInfo",
                newName: "username");
        }
    }
}
