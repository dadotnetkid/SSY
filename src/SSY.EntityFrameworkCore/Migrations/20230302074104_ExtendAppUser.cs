using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSY.Migrations
{
    /// <inheritdoc />
    public partial class ExtendAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AbpUsers",
                newName: "FirstName");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AbpUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "FemaleFollower",
                table: "AbpUsers",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ForecastQuantity",
                table: "AbpUsers",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "IGEngagement",
                table: "AbpUsers",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "IGFollowers",
                table: "AbpUsers",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IGHandle",
                table: "AbpUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AbpUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "AbpUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "NextLaunchDate",
                table: "AbpUsers",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "OnBoardedDate",
                table: "AbpUsers",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherSocials",
                table: "AbpUsers",
                type: "nvarchar(max)",
                nullable: true);

           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "FemaleFollower",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "ForecastQuantity",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "IGEngagement",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "IGFollowers",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "IGHandle",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "NextLaunchDate",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "OnBoardedDate",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "OtherSocials",
                table: "AbpUsers");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "AbpUsers",
                newName: "Name");
        }
    }
}
