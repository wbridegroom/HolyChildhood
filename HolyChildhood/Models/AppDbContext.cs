using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HolyChildhood.Models
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Page> Pages { get; set; }

        public DbSet<PageContent> PageContents { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Setting> Settings { get; set; }

        public DbSet<ContactInformation> ContactInformations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Setting>().HasAlternateKey(s => s.Key).HasName("AlternateKey_Key");

            builder.Entity<Setting>().Property(s => s.CanDelete).HasDefaultValue(true);

            builder.Entity<Setting>().HasData(
                new Setting { Id = 1, Key = "Title", Value = "Holy Childhood of Jesus", CanDelete = false },
                new Setting { Id = 2, Key = "Phone", Value = "", CanDelete = false },
                new Setting { Id = 3, Key = "Email", Value = "", CanDelete = false },
                new Setting { Id = 4, Key = "Address", Value = "", CanDelete = false },
                new Setting { Id = 5, Key = "City", Value = "", CanDelete = false },
                new Setting { Id = 6, Key = "State", Value = "", CanDelete = false },
                new Setting { Id = 7, Key = "Zipcode", Value = "", CanDelete = false },
                new Setting { Id = 8, Key = "Mission_Statement", Value = "", CanDelete = false },
                new Setting { Id = 9, Key = "Quote", Value = "", CanDelete = false }
            );

            base.OnModelCreating(builder);
        }
    }
}
