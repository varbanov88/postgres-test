using System;
using Microsoft.EntityFrameworkCore;

namespace Epra.Data
{
    public class EpraContext : DbContext
    {
        public EpraContext(DbContextOptions<EpraContext> options)
            : base(options)
        {
        }

        public DbSet<User> users { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<UserRoles> user_roles { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<Company> companies { get; set; }
        public DbSet<Address> addresses { get; set; }
        public DbSet<TitleInternal> titles_internal { get; set; }
        public DbSet<CompanyType> company_types { get; set; }
        public DbSet<MarketActivity> market_activities { get; set; }
        public DbSet<Membership> memberships { get; set; }
        public DbSet<Country> counties { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=18.184.132.169;Port=5430;Database=backend_test_design;Username=postgres;Password=postgrestest",
                options => options.SetPostgresVersion(new Version(9, 6)));
        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region User
            builder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            builder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId);
            #endregion
            #region Role
            builder.Entity<UserRoles>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            builder.Entity<Role>()
                .HasIndex(r => r.Name)
                .IsUnique();

            builder.Entity<Role>()
                .HasMany(r => r.Users)
                .WithOne(u => u.Role)
                .HasForeignKey(u => u.RoleId);
            #endregion
            #region Contact
            builder.Entity<Contact>()
                .HasIndex(c => c.Email).IsUnique();
            builder.Entity<Contact>()
                .HasMany(c => c.Bosses)
                .WithOne(b => b.Assistant)
                .HasForeignKey(b => b.AssistantId);
            #endregion
            #region Company
            builder.Entity<Company>()
                .HasMany(c => c.Contacts)
                .WithOne(c => c.Company)
                .HasForeignKey(c => c.CompanyId);

            builder.Entity<CompanyType>()
                .HasIndex(c => c.Name).IsUnique();

            builder.Entity<CompanyType>()
                .HasMany(c => c.Companies)
                .WithOne(c => c.CompanyType)
                .HasForeignKey(c => c.CompanyTypeId);

            #endregion
            #region Country
            builder.Entity<Country>()
                .HasIndex(c => c.Name).IsUnique();
            builder.Entity<Country>()
                .HasMany(c => c.Addresses)
                .WithOne(a => a.Country)
                .HasForeignKey(a => a.CountryId);
            #endregion
            #region Address
            builder.Entity<Address>()
                .HasMany(a => a.Contacts)
                .WithOne(c => c.Address)
                .HasForeignKey(c => c.AddressId);

            builder.Entity<Address>()
                .HasMany(a => a.Companies)
                .WithOne(c => c.Address)
                .HasForeignKey(a => a.AddressId);
            #endregion
            #region TitleInternal
            builder.Entity<TitleInternal>()
                .HasIndex(t => t.Name).IsUnique();

            builder.Entity<TitleInternal>()
                .HasMany(t => t.Contacts)
                .WithOne(c => c.TitleInternal)
                .HasForeignKey(c => c.TitleInternalId);
            #endregion
            #region MarketActivity
            builder.Entity<MarketActivity>()
                .HasIndex(m => m.Name).IsUnique();

            builder.Entity<MarketActivity>()
                .HasMany(m => m.Companies)
                .WithOne(c => c.MarketActivity)
                .HasForeignKey(c => c.MarketActivityId);
            #endregion
            #region Membership
            builder.Entity<Membership>()
                .HasMany(m => m.Companies)
                .WithOne(c => c.Membership)
                .HasForeignKey(c => c.MembershipId);
            #endregion

            base.OnModelCreating(builder);
        }
    }
}
