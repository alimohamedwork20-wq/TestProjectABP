using Microsoft.EntityFrameworkCore;
using TestProjectABP.Brands;
using TestProjectABP.Categories;
using TestProjectABP.Invoices;
using TestProjectABP.Orders;
using TestProjectABP.Products;
using TestProjectABP.Suppliers;
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

namespace TestProjectABP.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class TestProjectABPDbContext :
    AbpDbContext<TestProjectABPDbContext>,
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
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<InvoiceItem> InvoiceItems { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }
    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public TestProjectABPDbContext(DbContextOptions<TestProjectABPDbContext> options)
        : base(options)
    {

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
        builder.Entity<Product>(b =>
        {
            b.ToTable(TestProjectABPConsts.DbTablePrefix + "Products", TestProjectABPConsts.DbSchema);
            b.ConfigureByConvention(); // بيظبط التسميات والـ Primary Keys تلقائياً حسب قواعد ABP

            b.Property(x => x.Name).IsRequired().HasMaxLength(128);
            b.Property(x => x.Price).HasColumnType("decimal(18,2)");
        });
        builder.Entity<Category>(b =>
        {
            b.ToTable(TestProjectABPConsts.DbTablePrefix + "Categories", TestProjectABPConsts.DbSchema);

            // السطر ده هو السر في ABP! بيظبط الـ Audit Properties والـ Keys أوتوماتيك
            b.ConfigureByConvention();

            b.Property(x => x.Name).IsRequired().HasMaxLength(128);
            b.Property(x => x.Description).HasMaxLength(512);
        });
        builder.Entity<Brand>(b =>
        {
            b.ToTable(TestProjectABPConsts.DbTablePrefix + "Brands", TestProjectABPConsts.DbSchema);

            // السطر ده هو السر في ABP! بيظبط الـ Audit Properties والـ Keys أوتوماتيك
            b.ConfigureByConvention();

            b.Property(x => x.Name).IsRequired().HasMaxLength(128);
            b.Property(x => x.Description).HasMaxLength(512);
        });
        builder.Entity<Order>(b =>
        {
            b.ToTable(TestProjectABPConsts.DbTablePrefix + "Orders", TestProjectABPConsts.DbSchema);
            b.ConfigureByConvention();

            b.Property(x => x.OrderNumber).IsRequired().HasMaxLength(64);
            b.Property(x => x.TotalPrice).HasColumnType("decimal(18,2)");

            // تحديد علاقة Order بـ OrderItems
            b.HasMany(x => x.Items)
             .WithOne()
             .HasForeignKey(x => x.OrderId)
             .IsRequired();
        });

        builder.Entity<OrderItem>(b =>
        {
            b.ToTable(TestProjectABPConsts.DbTablePrefix + "OrderItems", TestProjectABPConsts.DbSchema);
            b.ConfigureByConvention();

            b.Property(x => x.UnitPrice).HasColumnType("decimal(18,2)");
        });
        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(TestProjectABPConsts.DbTablePrefix + "YourEntities", TestProjectABPConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
    }
}
