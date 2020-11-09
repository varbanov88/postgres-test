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
        public DbSet<Country> countries { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductCode> product_codes { get; set; }
        public DbSet<Invoice> invoices { get; set; }
        public DbSet<InvoiceStatus> invoice_statuses { get; set; }
        public DbSet<Region> regions { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<MembershipType> membership_types { get; set; }


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

            builder.Entity<User>()
                .HasMany(u => u.Comments)
                .WithOne(c => c.Author)
                .HasForeignKey(c => c.AuthorId);
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
                .HasIndex(c => c.Email);
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
            builder.Entity<Company>()
                .HasMany(c => c.Addresses)
                .WithOne(a => a.Company)
                .HasForeignKey(a => a.CompanyId);
            builder.Entity<CompanyType>()
                .HasIndex(c => c.Name).IsUnique();

            builder.Entity<CompanyType>()
                .HasMany(c => c.Companies)
                .WithOne(c => c.CompanyType)
                .HasForeignKey(c => c.CompanyTypeId);

            #endregion
            #region Country
            builder.Entity<Country>()
                .HasIndex(c => c.Name);
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
                .HasForeignKey(c => c.MembershipId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<Membership>()
                .HasMany(m => m.Comments)
                .WithOne(c => c.Membership)
                .HasForeignKey(c => c.MembershipId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Membership>()
                .HasMany(m => m.Invoices)
                .WithOne(i => i.Membership)
                .HasForeignKey(i => i.MemberShipId)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion
            #region Product
            builder.Entity<Product>()
                .HasIndex(p => p.Name).IsUnique();

            builder.Entity<Product>()
                .HasMany(p => p.Invoices)
                .WithOne(i => i.Product)
                .HasForeignKey(i => i.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Product>()
                .HasMany(p => p.Memberships)
                .WithOne(m => m.Product)
                .HasForeignKey(m => m.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
                
            #endregion
            #region ProducCodes
            builder.Entity<ProductCode>()
                .HasIndex(pc => pc.Name).IsUnique();
            builder.Entity<ProductCode>()
                .HasMany(pc => pc.Products)
                .WithOne(p => p.ProductCode)
                .HasForeignKey(p => p.ProductCodeId);

            #endregion
            #region InvoiceStatus

            builder.Entity<InvoiceStatus>()
                .HasIndex(i => i.Name).IsUnique();
            builder.Entity<InvoiceStatus>()
                .HasMany(s => s.Invoices)
                .WithOne(i => i.Status)
                .HasForeignKey(i => i.StatusId);
            #endregion
            #region Invoice
            builder.Entity<Invoice>()
                .HasIndex(i => i.Number).IsUnique();

            builder.Entity<Invoice>()
                .HasMany(i => i.Memberships)
                .WithOne(m => m.LastPaidInvoice)
                .HasForeignKey(m => m.LastPaidInvoiceId);

            builder.Entity<Invoice>()
                .HasMany(i => i.CreditInvoices)
                .WithOne(ci => ci.DebitInvoice)
                .HasForeignKey(ci => ci.InvoiceId);
            #endregion
            #region Region

            builder.Entity<Region>()
                .HasIndex(r => r.Name).IsUnique();

            builder.Entity<Region>()
                .HasMany(r => r.Countries)
                .WithOne(c => c.Region)
                .HasForeignKey(c => c.RegionId);
            #endregion
            #region MembershipTypes

            builder.Entity<MembershipType>()
                .HasIndex(mt => mt.Name)
                .IsUnique();

            builder.Entity<MembershipType>()
                .HasMany(m => m.Products)
                .WithOne(p => p.MembershipType)
                .HasForeignKey(p => p.MembershipTypeId);
            #endregion

            base.OnModelCreating(builder);
        }
    }
}
