using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSY.Migrations
{
    /// <inheritdoc />
    public partial class ProductAndCollectionModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "App_ApprovalStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_App_ApprovalStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_Collection_Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_App_Collection_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_DesignStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_App_DesignStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_Drops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_App_Drops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_Factories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_App_Factories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_Holidays",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
                    HolidayType = table.Column<int>(type: "int", nullable: false),
                    HolidayDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_App_Holidays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_LaunchCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_App_LaunchCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_MarketingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_App_MarketingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_Options",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
                    HasPanel = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_App_Options", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App_Options_App_Options_ParentId",
                        column: x => x.ParentId,
                        principalTable: "App_Options",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "App_OrderStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_App_OrderStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_PricePoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_App_PricePoints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_Product_MediaFileCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_App_Product_MediaFileCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_Product_MediaFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    MediaFileType = table.Column<int>(type: "int", nullable: false),
                    StorageFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentDisposition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_App_Product_MediaFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_Product_Sizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_App_Product_Sizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
                    SalesPercentage = table.Column<double>(type: "float", nullable: false),
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
                    table.PrimaryKey("PK_App_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_Seasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_App_Seasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_ShippingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_App_ShippingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_Typeforms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_App_Typeforms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    MaterialTypeId = table.Column<int>(type: "int", nullable: true),
                    ShortCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
                    AverageConsumption = table.Column<double>(type: "float", nullable: false),
                    SalesPercentage = table.Column<double>(type: "float", nullable: false),
                    SubSalesPercentage = table.Column<double>(type: "float", nullable: false),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: true),
                    DefaultWeight = table.Column<double>(type: "float", nullable: true),
                    FreeShippingFedExPrice = table.Column<double>(type: "float", nullable: true),
                    FreeShippingDHLPrice = table.Column<double>(type: "float", nullable: true),
                    TenUSDPrice = table.Column<double>(type: "float", nullable: true),
                    FifteenUSDPrice = table.Column<double>(type: "float", nullable: true),
                    TwentyUSDPrice = table.Column<double>(type: "float", nullable: true),
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
                    table.PrimaryKey("PK_App_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_Product_Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DesignStatusId = table.Column<int>(type: "int", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_App_Product_Statuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App_Product_Statuses_App_DesignStatuses_DesignStatusId",
                        column: x => x.DesignStatusId,
                        principalTable: "App_DesignStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "App_Product_Collections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Availability = table.Column<bool>(type: "bit", nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    CollectionDevelopmentStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProvisionalLaunchDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DesignStatusId = table.Column<int>(type: "int", nullable: false),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    MarketingTypeId = table.Column<int>(type: "int", nullable: false),
                    PricePointId = table.Column<int>(type: "int", nullable: false),
                    SeasonId = table.Column<int>(type: "int", nullable: false),
                    ShippingTypeId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_App_Product_Collections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App_Product_Collections_App_Collection_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "App_Collection_Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_App_Product_Collections_App_DesignStatuses_DesignStatusId",
                        column: x => x.DesignStatusId,
                        principalTable: "App_DesignStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_App_Product_Collections_App_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "App_Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_App_Product_Collections_App_MarketingTypes_MarketingTypeId",
                        column: x => x.MarketingTypeId,
                        principalTable: "App_MarketingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_App_Product_Collections_App_PricePoints_PricePointId",
                        column: x => x.PricePointId,
                        principalTable: "App_PricePoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_App_Product_Collections_App_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "App_Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_App_Product_Collections_App_ShippingTypes_ShippingTypeId",
                        column: x => x.ShippingTypeId,
                        principalTable: "App_ShippingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "App_BaseSizeSpecs",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    MediaFileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_BaseSizeSpecs", x => new { x.TypeId, x.MediaFileId });
                    table.ForeignKey(
                        name: "FK_App_BaseSizeSpecs_App_Product_MediaFiles_MediaFileId",
                        column: x => x.MediaFileId,
                        principalTable: "App_Product_MediaFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_App_BaseSizeSpecs_App_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "App_Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "App_ObjBlockPatterns",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    MediaFileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_ObjBlockPatterns", x => new { x.TypeId, x.MediaFileId });
                    table.ForeignKey(
                        name: "FK_App_ObjBlockPatterns_App_Product_MediaFiles_MediaFileId",
                        column: x => x.MediaFileId,
                        principalTable: "App_Product_MediaFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_App_ObjBlockPatterns_App_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "App_Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "App_TypeOptions",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    OptionId = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_TypeOptions", x => new { x.TypeId, x.OptionId });
                    table.ForeignKey(
                        name: "FK_App_TypeOptions_App_Options_OptionId",
                        column: x => x.OptionId,
                        principalTable: "App_Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_App_TypeOptions_App_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "App_Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "App_CalendarConfigurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ProductStatusId = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_App_CalendarConfigurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App_CalendarConfigurations_App_Product_Statuses_ProductStatusId",
                        column: x => x.ProductStatusId,
                        principalTable: "App_Product_Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "App_AssignedTos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CollectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DesignerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ThreeDDesignerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SSYMerchandiserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OEMMerchandiserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OEMPatternMakerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_AssignedTos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App_AssignedTos_App_Product_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "App_Product_Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "App_Calendars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CollectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SalesForecastQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ActualSalesQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CollectionDevelopmentTarget = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    table.PrimaryKey("PK_App_Calendars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App_Calendars_App_Product_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "App_Product_Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "App_CollectionInfluencers",
                columns: table => new
                {
                    CollectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InfluencerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    InfluencerFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfluencerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfluencerSurname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_CollectionInfluencers", x => new { x.CollectionId, x.InfluencerId });
                    table.ForeignKey(
                        name: "FK_App_CollectionInfluencers_App_Product_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "App_Product_Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "App_CollectionProductSizes",
                columns: table => new
                {
                    CollectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_CollectionProductSizes", x => new { x.CollectionId, x.SizeId });
                    table.ForeignKey(
                        name: "FK_App_CollectionProductSizes_App_Product_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "App_Product_Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_App_CollectionProductSizes_App_Product_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "App_Product_Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "App_CollectionProductTypes",
                columns: table => new
                {
                    CollectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    MaterialTypeShortCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialTypeValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_CollectionProductTypes", x => new { x.CollectionId, x.ProductTypeId });
                    table.ForeignKey(
                        name: "FK_App_CollectionProductTypes_App_Product_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "App_Product_Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_App_CollectionProductTypes_App_Types_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "App_Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "App_ColorOptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CollectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    ColorShortCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: true),
                    IsRejected = table.Column<bool>(type: "bit", nullable: true),
                    ApprovedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_ColorOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App_ColorOptions_App_Product_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "App_Product_Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "App_CalendarDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CalendarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductStatusId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_App_CalendarDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App_CalendarDetails_App_Calendars_CalendarId",
                        column: x => x.CalendarId,
                        principalTable: "App_Calendars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_App_CalendarDetails_App_Product_Statuses_ProductStatusId",
                        column: x => x.ProductStatusId,
                        principalTable: "App_Product_Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "App_ColorOptionFabrics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ColorOptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Consumption = table.Column<double>(type: "float", nullable: true),
                    FabricComposition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CareInstruction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitOfMeasurement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuttableWidth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Supplier = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_ColorOptionFabrics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App_ColorOptionFabrics_App_ColorOptions_ColorOptionId",
                        column: x => x.ColorOptionId,
                        principalTable: "App_ColorOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "App_ColorOptionProductTypes",
                columns: table => new
                {
                    ColorOptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_ColorOptionProductTypes", x => new { x.ColorOptionId, x.ProductTypeId });
                    table.ForeignKey(
                        name: "FK_App_ColorOptionProductTypes_App_ColorOptions_ColorOptionId",
                        column: x => x.ColorOptionId,
                        principalTable: "App_ColorOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_App_ColorOptionProductTypes_App_Types_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "App_Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "App_Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Sku = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CollectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LaunchCategoryId = table.Column<int>(type: "int", nullable: true),
                    ApprovalStatusId = table.Column<int>(type: "int", nullable: false),
                    ObjBlockPatternId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BaseSizeSpecId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WorkmanshipGuideId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OEMId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ColorOptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    DropId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_App_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App_Products_App_ColorOptions_ColorOptionId",
                        column: x => x.ColorOptionId,
                        principalTable: "App_ColorOptions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_App_Products_App_LaunchCategories_LaunchCategoryId",
                        column: x => x.LaunchCategoryId,
                        principalTable: "App_LaunchCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_App_Products_App_Product_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "App_Product_Collections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_App_Products_App_Product_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "App_Product_Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_App_Products_App_Products_ParentId",
                        column: x => x.ParentId,
                        principalTable: "App_Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_App_Products_App_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "App_Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "App_ColorOptionFabricRolls",
                columns: table => new
                {
                    ColorOptionFabricId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RollId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_ColorOptionFabricRolls", x => new { x.ColorOptionFabricId, x.RollId });
                    table.ForeignKey(
                        name: "FK_App_ColorOptionFabricRolls_App_ColorOptionFabrics_ColorOptionFabricId",
                        column: x => x.ColorOptionFabricId,
                        principalTable: "App_ColorOptionFabrics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "App_Accountings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UnitSales = table.Column<double>(type: "float", nullable: false),
                    TotalSales = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Accountings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App_Accountings_App_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "App_Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "App_BillOfMaterials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PartNumber = table.Column<int>(type: "int", nullable: false),
                    PartName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Consumption = table.Column<double>(type: "float", nullable: false),
                    UnitOfMeasurement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuttableWidth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Supplier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_BillOfMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App_BillOfMaterials_App_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "App_Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "App_Pricings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RetailPrice = table.Column<double>(type: "float", nullable: false),
                    ShippingPremium = table.Column<double>(type: "float", nullable: false),
                    NetPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Pricings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App_Pricings_App_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "App_Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "App_ProductMediaFiles",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MediaFileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    InternalIsApproved = table.Column<bool>(type: "bit", nullable: true),
                    InternalIsApprovedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InternalApprovedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfluencerIsApproved = table.Column<bool>(type: "bit", nullable: true),
                    InfluencerIsApprovedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InfluencerApprovedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_ProductMediaFiles", x => new { x.ProductId, x.MediaFileId });
                    table.ForeignKey(
                        name: "FK_App_ProductMediaFiles_App_Product_MediaFiles_MediaFileId",
                        column: x => x.MediaFileId,
                        principalTable: "App_Product_MediaFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_App_ProductMediaFiles_App_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "App_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "App_ProductOptions",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OptionId = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RollIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitOfMeasurementId = table.Column<int>(type: "int", nullable: true),
                    Consumption = table.Column<double>(type: "float", nullable: true),
                    MaterialName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RollNames = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_ProductOptions", x => new { x.ProductId, x.OptionId });
                    table.ForeignKey(
                        name: "FK_App_ProductOptions_App_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "App_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "App_RejectionNotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MediaFileCategoryId = table.Column<int>(type: "int", nullable: false),
                    IsInternal = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_App_RejectionNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App_RejectionNotes_App_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "App_Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "App_Shopifies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    FabricComposition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CareInstruction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopifyId = table.Column<long>(type: "bigint", nullable: true),
                    VariantId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Shopifies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App_Shopifies_App_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "App_Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "App_RejectionNoteMediaFiles",
                columns: table => new
                {
                    RejectionNoteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MediaFileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_RejectionNoteMediaFiles", x => new { x.RejectionNoteId, x.MediaFileId });
                    table.ForeignKey(
                        name: "FK_App_RejectionNoteMediaFiles_App_Product_MediaFiles_MediaFileId",
                        column: x => x.MediaFileId,
                        principalTable: "App_Product_MediaFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_App_RejectionNoteMediaFiles_App_RejectionNotes_RejectionNoteId",
                        column: x => x.RejectionNoteId,
                        principalTable: "App_RejectionNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "App_ShopifyMediaFiles",
                columns: table => new
                {
                    ShopifyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MediaFileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    OrderNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_ShopifyMediaFiles", x => new { x.ShopifyId, x.MediaFileId });
                    table.ForeignKey(
                        name: "FK_App_ShopifyMediaFiles_App_Product_MediaFiles_MediaFileId",
                        column: x => x.MediaFileId,
                        principalTable: "App_Product_MediaFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_App_ShopifyMediaFiles_App_Shopifies_ShopifyId",
                        column: x => x.ShopifyId,
                        principalTable: "App_Shopifies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_App_Accountings_ProductId",
                table: "App_Accountings",
                column: "ProductId",
                unique: true,
                filter: "[ProductId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_App_AssignedTos_CollectionId",
                table: "App_AssignedTos",
                column: "CollectionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_App_BaseSizeSpecs_MediaFileId",
                table: "App_BaseSizeSpecs",
                column: "MediaFileId");

            migrationBuilder.CreateIndex(
                name: "IX_App_BaseSizeSpecs_TypeId_MediaFileId",
                table: "App_BaseSizeSpecs",
                columns: new[] { "TypeId", "MediaFileId" });

            migrationBuilder.CreateIndex(
                name: "IX_App_BillOfMaterials_ProductId",
                table: "App_BillOfMaterials",
                column: "ProductId",
                unique: true,
                filter: "[ProductId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_App_CalendarConfigurations_ProductStatusId",
                table: "App_CalendarConfigurations",
                column: "ProductStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_App_CalendarDetails_CalendarId",
                table: "App_CalendarDetails",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_App_CalendarDetails_ProductStatusId",
                table: "App_CalendarDetails",
                column: "ProductStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_App_Calendars_CollectionId",
                table: "App_Calendars",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_App_CollectionInfluencers_CollectionId_InfluencerId",
                table: "App_CollectionInfluencers",
                columns: new[] { "CollectionId", "InfluencerId" });

            migrationBuilder.CreateIndex(
                name: "IX_App_CollectionProductSizes_CollectionId_SizeId",
                table: "App_CollectionProductSizes",
                columns: new[] { "CollectionId", "SizeId" });

            migrationBuilder.CreateIndex(
                name: "IX_App_CollectionProductSizes_SizeId",
                table: "App_CollectionProductSizes",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_App_CollectionProductTypes_CollectionId_ProductTypeId",
                table: "App_CollectionProductTypes",
                columns: new[] { "CollectionId", "ProductTypeId" });

            migrationBuilder.CreateIndex(
                name: "IX_App_CollectionProductTypes_ProductTypeId",
                table: "App_CollectionProductTypes",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_App_ColorOptionFabricRolls_ColorOptionFabricId_RollId",
                table: "App_ColorOptionFabricRolls",
                columns: new[] { "ColorOptionFabricId", "RollId" });

            migrationBuilder.CreateIndex(
                name: "IX_App_ColorOptionFabrics_ColorOptionId_MaterialId",
                table: "App_ColorOptionFabrics",
                columns: new[] { "ColorOptionId", "MaterialId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_App_ColorOptionProductTypes_ColorOptionId_ProductTypeId",
                table: "App_ColorOptionProductTypes",
                columns: new[] { "ColorOptionId", "ProductTypeId" });

            migrationBuilder.CreateIndex(
                name: "IX_App_ColorOptionProductTypes_ProductTypeId",
                table: "App_ColorOptionProductTypes",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_App_ColorOptions_CollectionId",
                table: "App_ColorOptions",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_App_ObjBlockPatterns_MediaFileId",
                table: "App_ObjBlockPatterns",
                column: "MediaFileId");

            migrationBuilder.CreateIndex(
                name: "IX_App_ObjBlockPatterns_TypeId_MediaFileId",
                table: "App_ObjBlockPatterns",
                columns: new[] { "TypeId", "MediaFileId" });

            migrationBuilder.CreateIndex(
                name: "IX_App_Options_ParentId",
                table: "App_Options",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_App_Pricings_ProductId",
                table: "App_Pricings",
                column: "ProductId",
                unique: true,
                filter: "[ProductId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_App_Product_Collections_DesignStatusId",
                table: "App_Product_Collections",
                column: "DesignStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_App_Product_Collections_FactoryId",
                table: "App_Product_Collections",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_App_Product_Collections_MarketingTypeId",
                table: "App_Product_Collections",
                column: "MarketingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_App_Product_Collections_PricePointId",
                table: "App_Product_Collections",
                column: "PricePointId");

            migrationBuilder.CreateIndex(
                name: "IX_App_Product_Collections_SeasonId",
                table: "App_Product_Collections",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_App_Product_Collections_ShippingTypeId",
                table: "App_Product_Collections",
                column: "ShippingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_App_Product_Collections_StatusId",
                table: "App_Product_Collections",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_App_Product_Statuses_DesignStatusId",
                table: "App_Product_Statuses",
                column: "DesignStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_App_ProductMediaFiles_MediaFileId",
                table: "App_ProductMediaFiles",
                column: "MediaFileId");

            migrationBuilder.CreateIndex(
                name: "IX_App_ProductMediaFiles_ProductId_MediaFileId",
                table: "App_ProductMediaFiles",
                columns: new[] { "ProductId", "MediaFileId" });

            migrationBuilder.CreateIndex(
                name: "IX_App_ProductOptions_ProductId_OptionId",
                table: "App_ProductOptions",
                columns: new[] { "ProductId", "OptionId" });

            migrationBuilder.CreateIndex(
                name: "IX_App_Products_CollectionId",
                table: "App_Products",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_App_Products_ColorOptionId",
                table: "App_Products",
                column: "ColorOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_App_Products_LaunchCategoryId",
                table: "App_Products",
                column: "LaunchCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_App_Products_ParentId",
                table: "App_Products",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_App_Products_StatusId",
                table: "App_Products",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_App_Products_TypeId",
                table: "App_Products",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_App_RejectionNoteMediaFiles_MediaFileId",
                table: "App_RejectionNoteMediaFiles",
                column: "MediaFileId");

            migrationBuilder.CreateIndex(
                name: "IX_App_RejectionNoteMediaFiles_RejectionNoteId_MediaFileId",
                table: "App_RejectionNoteMediaFiles",
                columns: new[] { "RejectionNoteId", "MediaFileId" });

            migrationBuilder.CreateIndex(
                name: "IX_App_RejectionNotes_ProductId",
                table: "App_RejectionNotes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_App_Shopifies_ProductId",
                table: "App_Shopifies",
                column: "ProductId",
                unique: true,
                filter: "[ProductId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_App_ShopifyMediaFiles_MediaFileId",
                table: "App_ShopifyMediaFiles",
                column: "MediaFileId");

            migrationBuilder.CreateIndex(
                name: "IX_App_ShopifyMediaFiles_ShopifyId_MediaFileId",
                table: "App_ShopifyMediaFiles",
                columns: new[] { "ShopifyId", "MediaFileId" });

            migrationBuilder.CreateIndex(
                name: "IX_App_TypeOptions_OptionId",
                table: "App_TypeOptions",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_App_TypeOptions_TypeId_OptionId",
                table: "App_TypeOptions",
                columns: new[] { "TypeId", "OptionId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "App_Accountings");

            migrationBuilder.DropTable(
                name: "App_ApprovalStatuses");

            migrationBuilder.DropTable(
                name: "App_AssignedTos");

            migrationBuilder.DropTable(
                name: "App_BaseSizeSpecs");

            migrationBuilder.DropTable(
                name: "App_BillOfMaterials");

            migrationBuilder.DropTable(
                name: "App_CalendarConfigurations");

            migrationBuilder.DropTable(
                name: "App_CalendarDetails");

            migrationBuilder.DropTable(
                name: "App_CollectionInfluencers");

            migrationBuilder.DropTable(
                name: "App_CollectionProductSizes");

            migrationBuilder.DropTable(
                name: "App_CollectionProductTypes");

            migrationBuilder.DropTable(
                name: "App_ColorOptionFabricRolls");

            migrationBuilder.DropTable(
                name: "App_ColorOptionProductTypes");

            migrationBuilder.DropTable(
                name: "App_Drops");

            migrationBuilder.DropTable(
                name: "App_Holidays");

            migrationBuilder.DropTable(
                name: "App_ObjBlockPatterns");

            migrationBuilder.DropTable(
                name: "App_OrderStatuses");

            migrationBuilder.DropTable(
                name: "App_Pricings");

            migrationBuilder.DropTable(
                name: "App_Product_MediaFileCategories");

            migrationBuilder.DropTable(
                name: "App_ProductCategories");

            migrationBuilder.DropTable(
                name: "App_ProductMediaFiles");

            migrationBuilder.DropTable(
                name: "App_ProductOptions");

            migrationBuilder.DropTable(
                name: "App_RejectionNoteMediaFiles");

            migrationBuilder.DropTable(
                name: "App_ShopifyMediaFiles");

            migrationBuilder.DropTable(
                name: "App_Typeforms");

            migrationBuilder.DropTable(
                name: "App_TypeOptions");

            migrationBuilder.DropTable(
                name: "App_Calendars");

            migrationBuilder.DropTable(
                name: "App_Product_Sizes");

            migrationBuilder.DropTable(
                name: "App_ColorOptionFabrics");

            migrationBuilder.DropTable(
                name: "App_RejectionNotes");

            migrationBuilder.DropTable(
                name: "App_Product_MediaFiles");

            migrationBuilder.DropTable(
                name: "App_Shopifies");

            migrationBuilder.DropTable(
                name: "App_Options");

            migrationBuilder.DropTable(
                name: "App_Products");

            migrationBuilder.DropTable(
                name: "App_ColorOptions");

            migrationBuilder.DropTable(
                name: "App_LaunchCategories");

            migrationBuilder.DropTable(
                name: "App_Product_Statuses");

            migrationBuilder.DropTable(
                name: "App_Types");

            migrationBuilder.DropTable(
                name: "App_Product_Collections");

            migrationBuilder.DropTable(
                name: "App_Collection_Statuses");

            migrationBuilder.DropTable(
                name: "App_DesignStatuses");

            migrationBuilder.DropTable(
                name: "App_Factories");

            migrationBuilder.DropTable(
                name: "App_MarketingTypes");

            migrationBuilder.DropTable(
                name: "App_PricePoints");

            migrationBuilder.DropTable(
                name: "App_Seasons");

            migrationBuilder.DropTable(
                name: "App_ShippingTypes");
        }
    }
}
