using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSY.Migrations
{
    /// <inheritdoc />
    public partial class AddUserDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "App_UserDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "App_UserDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pinterest",
                table: "App_UserDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tiktok",
                table: "App_UserDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Twitter",
                table: "App_UserDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Youtube",
                table: "App_UserDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "App_UserDetails");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "App_UserDetails");

            migrationBuilder.DropColumn(
                name: "Pinterest",
                table: "App_UserDetails");

            migrationBuilder.DropColumn(
                name: "Tiktok",
                table: "App_UserDetails");

            migrationBuilder.DropColumn(
                name: "Twitter",
                table: "App_UserDetails");

            migrationBuilder.DropColumn(
                name: "Youtube",
                table: "App_UserDetails");
        }
    }
}
