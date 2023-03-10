using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSY.Migrations
{
    /// <inheritdoc />
    public partial class addfolder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "App_Folders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_App_Folders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_InfluencersInFolders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FolderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_App_InfluencersInFolders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App_InfluencersInFolders_App_Folders_FolderId",
                        column: x => x.FolderId,
                        principalTable: "App_Folders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_App_InfluencersInFolders_App_UserDetails_UserId",
                        column: x => x.UserId,
                        principalTable: "App_UserDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_App_InfluencersInFolders_FolderId",
                table: "App_InfluencersInFolders",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_App_InfluencersInFolders_UserId",
                table: "App_InfluencersInFolders",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "App_InfluencersInFolders");

            migrationBuilder.DropTable(
                name: "App_Folders");
        }
    }
}
