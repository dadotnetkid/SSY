using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SSY.Authors;
using SSY.Books;
using SSY.Influencers;
using SSY.Influencers.Agencies;
using SSY.Influencers.Banks;
using SSY.Influencers.Messagings.Folders;
using SSY.Influencers.Messagings.Messages;
using SSY.Influencers.RevenueShares;
using SSY.Influencers.Sizings;
using SSY.Products;
using SSY.Products.Accountings;
using SSY.Products.ApprovalStatuses;
using SSY.Products.BillOfMaterials;
using SSY.Products.Collections;
using SSY.Products.Collections.AssignedTos;
using SSY.Products.Collections.CalendarConfigurations;
using SSY.Products.Collections.CalendarDetails;
using SSY.Products.Collections.Calendars;
using SSY.Products.Collections.ColorOptions;
using SSY.Products.Collections.DesignStatuses;
using SSY.Products.Collections.Drops;
using SSY.Products.Collections.Factories;
using SSY.Products.Collections.MarketingTypes;
using SSY.Products.Collections.PricePoints;
using SSY.Products.Collections.Seasons;
using SSY.Products.Collections.ShippingTypes;
using SSY.Products.CustomFilters;
using SSY.Products.Holidays;
using SSY.Products.LaunchCategories;
using SSY.Products.Options;
using SSY.Products.OrderStatuses;
using SSY.Products.Pricings;
using SSY.Products.RejectionNotes;
using SSY.Products.Shopifies;
using SSY.Products.Typeforms;
using SSY.Products.Types;
using SSY.UserDetails;
using SSY.UserDetails.Addresses;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Volo.Abp.Users;

namespace SSY.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class SSYDbContext :
    AbpDbContext<SSYDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion
    #region Influencers

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<UserDetail> UserDetails { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Sizing> Sizings { get; set; }
    public DbSet<Agent> Agents { get; set; }
    public DbSet<Bank> Banks { get; set; }
    public DbSet<RevenueShare> RevenueShares { get; set; }
    public DbSet<Folder> Folders{ get; set; }
    public DbSet<Message> Messages{ get; set; }
    #endregion
    #region Products

    public virtual DbSet<Accounting> Accountings { get; set; }
    public virtual DbSet<ApprovalStatus> ApprovalStatuses { get; set; }
    public virtual DbSet<BaseSizeSpec> BaseSizeSpecs { get; set; }
    public virtual DbSet<BillOfMaterial> BillOfMaterials { get; set; }
    public virtual DbSet<Products.Categories.Category> Categories { get; set; }

    #region Collections

    public virtual DbSet<AssignedTo> AssignedTos { get; set; }
    public virtual DbSet<CalendarConfiguration> CalendarConfigurations { get; set; }
    public virtual DbSet<Calendar> Calendars { get; set; }
    public virtual DbSet<CalendarDetail> CalendarDetails { get; set; }
    public virtual DbSet<ColorOption> ColorOptions { get; set; }
    public virtual DbSet<ColorOptionProductType> ColorOptionProductTypes { get; set; }
    public virtual DbSet<ColorOptionFabric> ColorOptionFabrics { get; set; }
    public virtual DbSet<ColorOptionFabricRoll> ColorOptionFabricRolls { get; set; }
    public virtual DbSet<DesignStatus> DesignStatuses { get; set; }
    public virtual DbSet<Drop> Drops { get; set; }
    public virtual DbSet<Factory> Factories { get; set; }
    public virtual DbSet<MarketingType> MarketingTypes { get; set; }
    public virtual DbSet<PricePoint> PricePoints { get; set; }
    public virtual DbSet<Season> Seasons { get; set; }
    public virtual DbSet<ShippingType> ShippingTypes { get; set; }
    public virtual DbSet<Products.Collections.Statuses.Status> CollectionStatuses { get; set; }

    public virtual DbSet<Collection> Collections { get; set; }
    public virtual DbSet<CollectionInfluencer> CollectionInfluencers { get; set; }
    public virtual DbSet<CollectionProductType> CollectionProductTypes { get; set; }
    public virtual DbSet<CollectionSize> CollectionSizes { get; set; }

    #endregion

    public virtual DbSet<Holiday> Holidays { get; set; }
    public virtual DbSet<Products.MediaFiles.MediaFile> MediaFiles { get; set; }
    public virtual DbSet<Products.MediaFiles.Categories.Category> MediaFileCategories { get; set; }
    public virtual DbSet<ObjBlockPattern> OBJBlockPatterns { get; set; }
    public virtual DbSet<Option> Options { get; set; }
    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }
    public virtual DbSet<Pricing> Pricings { get; set; }
    public virtual DbSet<RejectionNote> RejectionNotes { get; set; }
    public virtual DbSet<RejectionNoteMediaFile> RejectionNoteMediaFiles { get; set; }
    public virtual DbSet<Shopify> Shopifies { get; set; }
    public virtual DbSet<ShopifyMediaFile> ShopifyMediaFiles { get; set; }
    public virtual DbSet<Products.Sizes.Size> ProductSizes { get; set; }
    public virtual DbSet<Products.Statuses.Status> ProductStatuses { get; set; }
    public virtual DbSet<Typeform> Typeforms { get; set; }
    public virtual DbSet<Products.Types.Type> Types { get; set; }
    public virtual DbSet<TypeOption> TypeOptions { get; set; }
    public virtual DbSet<LaunchCategory> LaunchCategories { get; set; }

    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<ProductMediaFile> ProductMediaFiles { get; set; }
    public virtual DbSet<ProductOption> ProductOptions { get; set; }

    #endregion
    
    public SSYDbContext(DbContextOptions<SSYDbContext> options)
        : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine);
        base.OnConfiguring(optionsBuilder);
    }

    protected bool IsActiveFilterEnabled => DataFilter?.IsEnabled<IIsActive>() ?? false;

    protected override bool ShouldFilterEntity<TEntity>(IMutableEntityType entityType)
    {
        if (typeof(IIsActive).IsAssignableFrom(typeof(TEntity)))
        {
            return true;
        }

        return base.ShouldFilterEntity<TEntity>(entityType);
    }

    protected override Expression<Func<TEntity, bool>> CreateFilterExpression<TEntity>()
    {
        var expression = base.CreateFilterExpression<TEntity>();

        if (typeof(IIsActive).IsAssignableFrom(typeof(TEntity)))
        {
            Expression<Func<TEntity, bool>> isActiveFilter =
                e => !IsActiveFilterEnabled || EF.Property<bool>(e, "IsActive");
            expression = expression == null
                ? isActiveFilter
                : CombineExpressions(expression, isActiveFilter);
        }

        return expression;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();



        ConfigureProducts(builder);
        ConfigureProductDropdowns(builder);

        ConfigureCollections(builder);
        ConfigureCollectionDropdowns(builder);
        ConfigureCalendars(builder);
        ConfigureAppUser(builder);
        ConfigureSizing(builder);
        ConfigureAgents(builder);
        ConfigureBanks(builder);
        ConfigureRevenueShares(builder);
        ConfigureMessagings(builder);
    }

    private void ConfigureMessagings(ModelBuilder builder)
    {
        builder.Entity<Folder>(b =>
        {
            b.ToTable($"{ProductsConsts.DbTablePrefix}Folders");
            b.ConfigureByConvention();

        }); 
        builder.Entity<Message>(b =>
        {
            b.ToTable($"{ProductsConsts.DbTablePrefix}Messages");
            b.ConfigureByConvention();
            b.HasOne(c=>c.Folder).WithMany(c=>c.Messages).HasForeignKey(c=>c.FolderId).OnDelete(DeleteBehavior.ClientCascade);

        });
        builder.Entity<InfluencersInFolder>(b =>
        {
            b.ToTable($"{ProductsConsts.DbTablePrefix}InfluencersInFolders");
            b.ConfigureByConvention();
            b.HasOne(c => c.Folder).WithMany(c => c.InfluencersInFolders)
                .HasForeignKey(c => c.FolderId).OnDelete(DeleteBehavior.ClientCascade);
            b.HasOne(c => c.UserDetail).WithMany(c => c.InfluencersInFolders)
                .HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.ClientCascade);
        });
    }

    private void ConfigureRevenueShares(ModelBuilder builder)
    {
        builder.Entity<RevenueShare>(b =>
        {
            b.ToTable($"{ProductsConsts.DbTablePrefix}RevenueShares");
            b.ConfigureByConvention();
            b.HasOne(c => c.UserDetail).WithMany(c => c.RevenueShares).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.SetNull);
        });
    }

    private void ConfigureBanks(ModelBuilder builder)
    {
        builder.Entity<Bank>(b =>
        {
            b.ToTable($"{ProductsConsts.DbTablePrefix}Banks");
            b.ConfigureByConvention();
            b.HasOne(c => c.UserDetail).WithMany(c => c.Banks).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.SetNull);
        });
    }

    private void ConfigureAgents(ModelBuilder builder)
    {
        builder.Entity<Agent>(b =>
        {
            b.ToTable($"{ProductsConsts.DbTablePrefix}Agents");
            b.ConfigureByConvention();
            b.HasOne(c => c.UserDetail).WithMany(c => c.Agents).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.SetNull);
        });
    }

    private void ConfigureSizing(ModelBuilder builder)
    {
        builder.Entity<Sizing>(b =>
        {
            b.ToTable($"{ProductsConsts.DbTablePrefix}Sizings");
            b.ConfigureByConvention();
            b.HasOne(c => c.UserDetail).WithOne(c => c.Sizing).HasForeignKey<Sizing>(c => c.UserId).OnDelete(DeleteBehavior.SetNull);
        });
    }

    private void ConfigureAppUser(ModelBuilder builder)
    {
        builder.Entity<IdentityUser>(b =>
           {
               b.Property(x => x.Name).HasColumnName("FirstName");
               b.Property(x => x.Surname).HasColumnName("LastName");
           });
        builder.Entity<UserDetail>(b =>
        {
            b.ToTable($"{ProductsConsts.DbTablePrefix}UserDetails");
            b.ConfigureByConvention();
            b.HasOne(c => c.AppUser).WithMany().HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.SetNull);

        });
        builder.Entity<Address>(b =>
        {
            b.ToTable($"{ProductsConsts.DbTablePrefix}Address");
            b.ConfigureByConvention();
            b.HasOne(c => c.UserDetail).WithMany(c => c.Addresses).HasForeignKey(c => c.UserId);
        });
    }



    private void ConfigureCalendars(ModelBuilder builder)
    {
        builder.Entity<Calendar>(b =>
        {
            b.ToTable($"{ProductsConsts.DbTablePrefix}{nameof(Calendars)}", ProductsConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.CollectionId).IsRequired();

            b.HasOne(x => x.Collection).WithMany().HasForeignKey(x => x.CollectionId).OnDelete(DeleteBehavior.Restrict);
        });
        builder.Entity<CalendarDetail>(b =>
        {
            b.ToTable($"{ProductsConsts.DbTablePrefix}{nameof(CalendarDetails)}", ProductsConsts.DbSchema);
            b.ConfigureByConvention();
            b.HasOne(c => c.ProductStatus).WithMany().HasForeignKey(c => c.ProductStatusId).OnDelete(DeleteBehavior.Restrict);
            b.HasOne(c => c.Calendar).WithMany(c => c.CalendarDetails).HasForeignKey(c => c.CalendarId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }

    private void ConfigureProducts(ModelBuilder builder)
    {
        builder.Entity<Product>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "Products", ProductsConsts.DbSchema);
            b.ConfigureByConvention();

            b.HasOne<Product>().WithMany(x => x.ChildProducts).HasForeignKey(x => x.ParentId);
            b.HasMany(x => x.ChildProducts).WithOne().HasForeignKey(x => x.ParentId);
            b.HasMany(x => x.ProductMediaFiles).WithOne().HasForeignKey(x => x.ProductId).IsRequired();
        });

        builder.Entity<ProductOption>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "ProductOptions", ProductsConsts.DbSchema);
            b.ConfigureByConvention();

            b.HasIndex(x => new { x.ProductId, x.OptionId }).IsUnique();
        });

        builder.Entity<ProductOptionDetail>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "ProductOptionDetails", ProductsConsts.DbSchema);
            b.ConfigureByConvention();
        });

        builder.Entity<ProductMediaFile>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "ProductMediaFiles", ProductsConsts.DbSchema);
            b.ConfigureByConvention();

            b.HasKey(x => new { x.ProductId, x.MediaFileId });
            b.HasIndex(x => new { x.ProductId, x.MediaFileId });
            b.HasOne<Product>().WithMany(x => x.ProductMediaFiles).HasForeignKey(x => x.ProductId).IsRequired();
        });

        builder.Entity<Products.MediaFiles.MediaFile>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "Product_MediaFiles", ProductsConsts.DbSchema);
            b.ConfigureByConvention();
        });

        builder.Entity<Pricing>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "Pricings", ProductsConsts.DbSchema);
            b.ConfigureByConvention();
        });

        builder.Entity<Accounting>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "Accountings", ProductsConsts.DbSchema);
            b.ConfigureByConvention();
        });
        builder.Entity<Shopify>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "Shopifies", ProductsConsts.DbSchema);
            b.ConfigureByConvention();

            b.HasMany(x => x.MediaFiles).WithOne().HasForeignKey(x => x.ShopifyId).IsRequired();
        });

        builder.Entity<ShopifyMediaFile>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "ShopifyMediaFiles", ProductsConsts.DbSchema);
            b.ConfigureByConvention();

            b.HasKey(x => new { x.ShopifyId, x.MediaFileId });
            b.HasIndex(x => new { x.ShopifyId, x.MediaFileId });
            b.HasOne<Shopify>().WithMany(x => x.MediaFiles).HasForeignKey(x => x.ShopifyId).IsRequired();
        });

        builder.Entity<RejectionNote>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "RejectionNotes", ProductsConsts.DbSchema);
            b.ConfigureByConvention();

            b.HasMany(x => x.MediaFiles).WithOne().HasForeignKey(x => x.RejectionNoteId).IsRequired();
        });

        builder.Entity<RejectionNoteMediaFile>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "RejectionNoteMediaFiles", ProductsConsts.DbSchema);
            b.ConfigureByConvention();

            b.HasKey(x => new { x.RejectionNoteId, x.MediaFileId });
            b.HasIndex(x => new { x.RejectionNoteId, x.MediaFileId });
            b.HasOne<RejectionNote>().WithMany(x => x.MediaFiles).HasForeignKey(x => x.RejectionNoteId).IsRequired();
        });

        builder.Entity<BillOfMaterial>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "BillOfMaterials", ProductsConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Id).ValueGeneratedOnAdd();
        });

    }

    private void ConfigureProductDropdowns(ModelBuilder builder)
    {
        builder.Entity<ApprovalStatus>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "ApprovalStatuses", ProductsConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Id).ValueGeneratedNever();
        });

        builder.Entity<Products.Categories.Category>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "ProductCategories", ProductsConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Id).ValueGeneratedNever();
        });

        builder.Entity<Products.LaunchCategories.LaunchCategory>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "LaunchCategories", ProductsConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Id).ValueGeneratedNever();
        });

        builder.Entity<Option>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "Options", ProductsConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Id).ValueGeneratedNever();

            b.HasOne<Option>().WithMany(x => x.Options).HasForeignKey(x => x.ParentId);
            b.HasMany(x => x.Options).WithOne().HasForeignKey(x => x.ParentId);
        });

        builder.Entity<OrderStatus>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "OrderStatuses", ProductsConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Id).ValueGeneratedNever();
        });

        builder.Entity<Products.Sizes.Size>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "Product_Sizes", ProductsConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Id).ValueGeneratedNever();
        });

        builder.Entity<Products.Statuses.Status>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "Product_Statuses", ProductsConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Id).ValueGeneratedNever();

            b.HasOne(x => x.DesignStatus).WithMany().HasForeignKey(x => x.DesignStatusId).OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<Typeform>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "Typeforms", ProductsConsts.DbSchema);
            b.ConfigureByConvention();
        });

        builder.Entity<Products.Types.Type>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "Types", ProductsConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Id).ValueGeneratedNever();

            b.HasMany(x => x.Options).WithOne().HasForeignKey(x => x.TypeId).IsRequired();
            b.HasMany(x => x.BaseSizeSpecs).WithOne().HasForeignKey(x => x.TypeId).IsRequired();
            b.HasMany(x => x.ObjBlockPatterns).WithOne().HasForeignKey(x => x.TypeId).IsRequired();
        });

        builder.Entity<TypeOption>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "TypeOptions", ProductsConsts.DbSchema);
            b.ConfigureByConvention();

            b.HasKey(x => new { x.TypeId, x.OptionId });
            b.HasIndex(x => new { x.TypeId, x.OptionId });
            b.HasOne<Products.Types.Type>().WithMany(x => x.Options).HasForeignKey(x => x.TypeId).IsRequired();
        });

        builder.Entity<Products.MediaFiles.Categories.Category>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "Product_MediaFileCategories", ProductsConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Id).ValueGeneratedNever();
        });

        builder.Entity<BaseSizeSpec>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "BaseSizeSpecs", ProductsConsts.DbSchema);
            b.ConfigureByConvention();

            b.HasKey(x => new { x.TypeId, x.MediaFileId });
            b.HasIndex(x => new { x.TypeId, x.MediaFileId });
            b.HasOne<Products.Types.Type>().WithMany(x => x.BaseSizeSpecs).HasForeignKey(x => x.TypeId).IsRequired();
        });

        builder.Entity<ObjBlockPattern>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "ObjBlockPatterns", ProductsConsts.DbSchema);
            b.ConfigureByConvention();

            b.HasKey(x => new { x.TypeId, x.MediaFileId });
            b.HasIndex(x => new { x.TypeId, x.MediaFileId });
            b.HasOne<Products.Types.Type>().WithMany(x => x.ObjBlockPatterns).HasForeignKey(x => x.TypeId).IsRequired();
        });

        builder.Entity<Holiday>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "Holidays", ProductsConsts.DbSchema);
            b.ConfigureByConvention();

        });
    }

    private void ConfigureCollections(ModelBuilder builder)
    {
        builder.Entity<Collection>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "Product_Collections", ProductsConsts.DbSchema);
            b.ConfigureByConvention();

            //b.HasMany(x => x.Products).WithOne().HasForeignKey(x => x.CollectionId);
            b.HasMany(x => x.ColorOptions).WithOne().HasForeignKey(x => x.CollectionId).IsRequired();
            b.HasMany(x => x.ProductTypes).WithOne().HasForeignKey(x => x.CollectionId).IsRequired();
            b.HasMany(x => x.Influencers).WithOne().HasForeignKey(x => x.CollectionId).IsRequired();
            b.HasMany(x => x.Sizes).WithOne().HasForeignKey(x => x.CollectionId).IsRequired();
        });

        builder.Entity<AssignedTo>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "AssignedTos", ProductsConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Id).ValueGeneratedOnAdd();
        });

        #region ColorOption

        builder.Entity<ColorOption>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "ColorOptions", ProductsConsts.DbSchema);
            b.ConfigureByConvention();

            b.Property(x => x.Id).ValueGeneratedOnAdd();
            b.HasOne<Collection>().WithMany(x => x.ColorOptions).HasForeignKey(x => x.CollectionId).IsRequired();
            b.HasMany(x => x.ProductTypes).WithOne().HasForeignKey(x => x.ColorOptionId).IsRequired();
        });

        builder.Entity<ColorOptionProductType>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "ColorOptionProductTypes", ProductsConsts.DbSchema);
            b.ConfigureByConvention();

            b.Property(x => x.ColorOptionId).ValueGeneratedOnAdd();
            b.HasKey(x => new { x.ColorOptionId, x.ProductTypeId });
            b.HasIndex(x => new { x.ColorOptionId, x.ProductTypeId });
            b.HasOne<ColorOption>().WithMany(x => x.ProductTypes).HasForeignKey(x => x.ColorOptionId).IsRequired();
        });

        builder.Entity<ColorOptionFabric>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "ColorOptionFabrics", ProductsConsts.DbSchema);
            b.ConfigureByConvention();

            b.Property(x => x.Id).ValueGeneratedOnAdd();
            b.Property(x => x.ColorOptionId).ValueGeneratedOnAdd();
            b.HasIndex(x => new { x.ColorOptionId, x.MaterialId }).IsUnique();
        });

        builder.Entity<ColorOptionFabricRoll>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "ColorOptionFabricRolls", ProductsConsts.DbSchema);
            b.ConfigureByConvention();

            b.Property(x => x.ColorOptionFabricId).ValueGeneratedOnAdd();
            b.HasKey(x => new { x.ColorOptionFabricId, x.RollId });
            b.HasIndex(x => new { x.ColorOptionFabricId, x.RollId });
        });

        #endregion

        builder.Entity<CollectionProductType>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "CollectionProductTypes", ProductsConsts.DbSchema);
            b.ConfigureByConvention();

            b.HasKey(x => new { x.CollectionId, x.ProductTypeId });
            b.HasIndex(x => new { x.CollectionId, x.ProductTypeId });
            b.HasOne<Collection>().WithMany(x => x.ProductTypes).HasForeignKey(x => x.CollectionId).IsRequired();
        });

        builder.Entity<CollectionInfluencer>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "CollectionInfluencers", ProductsConsts.DbSchema);
            b.ConfigureByConvention();

            b.HasKey(x => new { x.CollectionId, x.InfluencerId });
            b.HasIndex(x => new { x.CollectionId, x.InfluencerId });
            b.HasOne<Collection>().WithMany(x => x.Influencers).HasForeignKey(x => x.CollectionId).IsRequired();
        });

        builder.Entity<CollectionSize>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "CollectionProductSizes", ProductsConsts.DbSchema);
            b.ConfigureByConvention();

            b.HasKey(x => new { x.CollectionId, x.SizeId });
            b.HasIndex(x => new { x.CollectionId, x.SizeId });
            b.HasOne<Collection>().WithMany(x => x.Sizes).HasForeignKey(x => x.CollectionId).IsRequired();
        });
    }

    private void ConfigureCollectionDropdowns(ModelBuilder builder)
    {

        builder.Entity<CalendarConfiguration>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "CalendarConfigurations", ProductsConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Id).ValueGeneratedNever();

            b.HasOne(x => x.ProductStatus).WithMany().IsRequired(true).HasForeignKey(x => x.ProductStatusId).OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<DesignStatus>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "DesignStatuses", ProductsConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Id).ValueGeneratedNever();
        });

        builder.Entity<Drop>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "Drops", ProductsConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Id).ValueGeneratedNever();
        });

        builder.Entity<Factory>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "Factories", ProductsConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Id).ValueGeneratedNever();
        });

        builder.Entity<MarketingType>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "MarketingTypes", ProductsConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Id).ValueGeneratedNever();
        });

        builder.Entity<PricePoint>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "PricePoints", ProductsConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Id).ValueGeneratedNever();
        });

        builder.Entity<Season>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "Seasons", ProductsConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Id).ValueGeneratedNever();
        });

        builder.Entity<ShippingType>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "ShippingTypes", ProductsConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Id).ValueGeneratedNever();
        });

        builder.Entity<Products.Collections.Statuses.Status>(b =>
        {
            b.ToTable(ProductsConsts.DbTablePrefix + "Collection_Statuses", ProductsConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Id).ValueGeneratedNever();
        });

    }
}