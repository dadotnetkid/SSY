using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSY.Migrations
{
    /// <inheritdoc />
    public partial class AddUserDetailFirstNameLastname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActiveWearQuantityForecast",
                table: "App_UserDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "App_UserDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KnitWearQuantityForecast",
                table: "App_UserDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "App_UserDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveWearQuantityForecast",
                table: "App_UserDetails");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "App_UserDetails");

            migrationBuilder.DropColumn(
                name: "KnitWearQuantityForecast",
                table: "App_UserDetails");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "App_UserDetails");
        }
    }
}
