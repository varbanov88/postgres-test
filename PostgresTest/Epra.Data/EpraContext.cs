using Microsoft.EntityFrameworkCore;

namespace Epra.Data
{
    public class EpraContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=18.184.132.169;Database=backend_test_design;Username=postgres;Password=postgrestest");
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserRoles>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            builder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            builder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId);

            builder.Entity<Role>()
                .HasIndex(r => r.Name)
                .IsUnique();

            builder.Entity<Role>()
                .HasMany(r => r.Users)
                .WithOne(u => u.Role)
                .HasForeignKey(u => u.RoleId);

            builder.Entity<Contact>()
                .HasMany(c => c.Bosses)
                .WithOne(b => b.Assistant)
                .HasForeignKey(b => b.AssistantId);

            builder.Entity<Company>()
                .HasMany(c => c.Contacts)
                .WithOne(c => c.Company)
                .HasForeignKey(c => c.CompanyId);

            builder.Entity<Address>()
                .HasMany(a => a.Contacts)
                .WithOne(c => c.Address)
                .HasForeignKey(c => c.AddressId);

            base.OnModelCreating(builder);
        }
    }
}
