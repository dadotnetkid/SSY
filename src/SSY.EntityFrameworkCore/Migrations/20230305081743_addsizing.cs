using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSY.Migrations
{
    /// <inheritdoc />
    public partial class addsizing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "App_Sizings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ToziUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToziId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToziCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToziObj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToziTopSize = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ToziBottomSize = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ToziDressSize = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ToziHeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ToziWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NeckGirth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ArmLength = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ShoulderLenth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ArmholeGirth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AcrossFront = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AcrossBack = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AboveBustGirth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BustGirth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ChestWidth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BackWaistLength = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WaistGirth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LowWaistGirth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LowerWaistGirth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HipGirth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CrotchLength = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KneeGirth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CalfGirth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InseamInLeg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InseamInLegAngkle = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SideSeam = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Sizings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App_Sizings_App_UserDetails_UserId",
                        column: x => x.UserId,
                        principalTable: "App_UserDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_App_Sizings_UserId",
                table: "App_Sizings",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "App_Sizings");
        }
    }
}
