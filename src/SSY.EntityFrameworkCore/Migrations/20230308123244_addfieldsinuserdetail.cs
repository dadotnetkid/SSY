using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSY.Migrations
{
    /// <inheritdoc />
    public partial class addfieldsinuserdetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Activewear",
                table: "App_UserDetails",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "App_UserDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Knitwear",
                table: "App_UserDetails",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address2",
                table: "App_Address",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activewear",
                table: "App_UserDetails");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "App_UserDetails");

            migrationBuilder.DropColumn(
                name: "Knitwear",
                table: "App_UserDetails");

            migrationBuilder.DropColumn(
                name: "Address2",
                table: "App_Address");
        }
    }
}
