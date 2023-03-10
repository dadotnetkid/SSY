using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSY.Migrations
{
    /// <inheritdoc />
    public partial class AddedProductOptionDetailEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_App_ProductOptions",
                table: "App_ProductOptions");

            migrationBuilder.DropIndex(
                name: "IX_App_ProductOptions_ProductId_OptionId",
                table: "App_ProductOptions");

            migrationBuilder.AddColumn<string>(
                name: "MaterialIds",
                table: "App_TypeOptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "App_ProductOptions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CollectionId",
                table: "App_Calendars",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_App_ProductOptions",
                table: "App_ProductOptions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "App_ProductOptionDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductOptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RollIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitOfMeasurementId = table.Column<int>(type: "int", nullable: true),
                    Consumption = table.Column<double>(type: "float", nullable: true),
                    MaterialName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RollNames = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_ProductOptionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App_ProductOptionDetails_App_ProductOptions_ProductOptionId",
                        column: x => x.ProductOptionId,
                        principalTable: "App_ProductOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_App_ProductOptions_OptionId",
                table: "App_ProductOptions",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_App_ProductOptions_ProductId_OptionId",
                table: "App_ProductOptions",
                columns: new[] { "ProductId", "OptionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_App_ProductOptionDetails_ProductOptionId",
                table: "App_ProductOptionDetails",
                column: "ProductOptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_App_ProductOptions_App_Options_OptionId",
                table: "App_ProductOptions",
                column: "OptionId",
                principalTable: "App_Options",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_App_ProductOptions_App_Options_OptionId",
                table: "App_ProductOptions");

            migrationBuilder.DropTable(
                name: "App_ProductOptionDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_App_ProductOptions",
                table: "App_ProductOptions");

            migrationBuilder.DropIndex(
                name: "IX_App_ProductOptions_OptionId",
                table: "App_ProductOptions");

            migrationBuilder.DropIndex(
                name: "IX_App_ProductOptions_ProductId_OptionId",
                table: "App_ProductOptions");

            migrationBuilder.DropColumn(
                name: "MaterialIds",
                table: "App_TypeOptions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "App_ProductOptions");

            migrationBuilder.AlterColumn<Guid>(
                name: "CollectionId",
                table: "App_Calendars",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_App_ProductOptions",
                table: "App_ProductOptions",
                columns: new[] { "ProductId", "OptionId" });

            migrationBuilder.CreateIndex(
                name: "IX_App_ProductOptions_ProductId_OptionId",
                table: "App_ProductOptions",
                columns: new[] { "ProductId", "OptionId" });
        }
    }
}
