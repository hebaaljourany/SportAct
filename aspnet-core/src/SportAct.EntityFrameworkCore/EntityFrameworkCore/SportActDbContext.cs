using Microsoft.EntityFrameworkCore;
using SportAct.ActivityTypes;
using SportAct.Cities;
using SportAct.Domain;
using SportAct.Locations;
using SportAct.Reservations;
using SportAct.SportActivities;
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

namespace SportAct.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class SportActDbContext :
    AbpDbContext<SportActDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */
    public DbSet<Client> Clients { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<SportActivity> SportActivities{ get; set; }
    public DbSet<ActivityType> ActivityTypes { get; set; }
    public DbSet<Reservation> Reservations { get; set; }



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

    public SportActDbContext(DbContextOptions<SportActDbContext> options)
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

        /* Configure your own tables/entities inside here */
        builder.Entity<Client>(b =>
        {
            b.ToTable(SportActConsts.DbTablePrefix + "Clients",
                SportActConsts.DbSchema);
            b.ConfigureByConvention();  //auto configure for the base class props
            b.HasOne<IdentityUser>().WithOne().HasForeignKey<Client>(x => x.UserId).IsRequired();

            // b.Property(x => x.).IsRequired().HasMaxLength(128);
        });
        ////////////////////////
        builder.Entity<City>(b =>
        {
            b.ToTable(SportActConsts.DbTablePrefix + "Cities",
                SportActConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.CityName)
        .IsRequired()
        .HasMaxLength(CityConsts.MaxCityNameLength);

            b.HasIndex(x => x.CityName);
        });
        ///////////////////////////////
        builder.Entity<Location>(b =>
        {
            b.ToTable(SportActConsts.DbTablePrefix + "Locations",
                SportActConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.HasOne<City>().WithMany().HasForeignKey(x => x.CityId).IsRequired();
            b.Property(x => x.LocationName)
               .IsRequired()
               .HasMaxLength(LocationConsts.MaxLocationNameLength);

                    b.HasIndex(x => x.LocationName);

        });
        ////////////////////////////////
        builder.Entity<SportActivity>(b =>
        {
            b.ToTable(SportActConsts.DbTablePrefix + "SportActivities",
                SportActConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props

            b.HasOne<Location>().WithMany().HasForeignKey(x => x.LocationId).IsRequired();
            b.HasOne<ActivityType>().WithMany().HasForeignKey(x => x.ActivityTypeId).IsRequired();
            b.Property(x => x.ActivityName)
                       .IsRequired()
                       .HasMaxLength(SportActivityConsts.MaxActivityNameLength);

            b.HasIndex(x => x.ActivityName);

        });
        ////////////////////////////
        builder.Entity<ActivityType>(b =>
        {
            b.ToTable(SportActConsts.DbTablePrefix + "ActivityTypes",
                SportActConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.ActivityTypeName)
       .IsRequired()
       .HasMaxLength(ActivityTypeConsts.MaxActivityTypeNameLength);

            b.HasIndex(x => x.ActivityTypeName);
        });
        builder.Entity<Reservation>(b =>
        {
            b.ToTable(SportActConsts.DbTablePrefix + "Reservations",
                SportActConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.HasOne<SportActivity>().WithMany().HasForeignKey(x => x.SportActivityId).IsRequired();
            b.HasOne<Client>().WithMany().HasForeignKey(x => x.ClientId).IsRequired();

        });



    }
}
