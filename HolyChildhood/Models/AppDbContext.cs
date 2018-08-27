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

        public DbSet<ContactInformation> ContactInformations { get; set; }

    }
}
