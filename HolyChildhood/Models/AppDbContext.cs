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
                new Setting { Id = 2, Key = "Phone", Value = "(618) 566-2958", CanDelete = false },
                new Setting { Id = 3, Key = "Email", Value = "hcc@holychildhoodchurch.com", CanDelete = false },
                new Setting { Id = 4, Key = "Address", Value = "419 East Church St.", CanDelete = false },
                new Setting { Id = 5, Key = "City", Value = "Mascoutah", CanDelete = false },
                new Setting { Id = 6, Key = "State", Value = "IL", CanDelete = false },
                new Setting { Id = 7, Key = "Zipcode", Value = "62258", CanDelete = false },
                new Setting { Id = 8, Key = "Mission_Statement", Value = "To be a credible sign of God’s love and care, Holy Childhood Parish needs to be a loving, charitable and caring community that is spiritually challenging, generously welcoming and liturgically alive. We strive to reach out to those in spiritual need and basic material needs. We will be open to the ideas of others, and, with God’s help, continue to live out the Gospel message.", CanDelete = false },
                new Setting { Id = 9, Key = "Quote", Value = "At Holy Childhood, we use the gifts that God has given us, our gifts of time, talent and treasure, to further the Kingdom of God here on earth.", CanDelete = false }
            );

            base.OnModelCreating(builder);
        }
    }
}
