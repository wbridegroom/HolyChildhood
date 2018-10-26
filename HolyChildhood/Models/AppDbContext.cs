using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HolyChildhood.Models
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Page> Pages { get; set; }
        public DbSet<PageContent> PageContents { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Parishioner> Parishioners { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Minister> Ministers { get; set; }
        public DbSet<MassEvent> MassEvents { get; set; }
        public DbSet<MeetingEvent> MeetingEvents { get; set; }
        public DbSet<VolunteerEvent> VolunteerEvents { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<File> Files { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Event>().HasOne(me => me.MassEvent).WithOne(e => e.Event).HasForeignKey<MassEvent>(me => me.EventId);
            builder.Entity<Event>().HasOne(me => me.MeetingEvent).WithOne(e => e.Event).HasForeignKey<MeetingEvent>(me => me.EventId);
            builder.Entity<Event>().HasOne(me => me.VolunteerEvent).WithOne(e => e.Event).HasForeignKey<VolunteerEvent>(me => me.EventId);
            

            builder.Entity<Setting>().HasAlternateKey(s => s.Key).HasName("AlternateKey_Key");
            builder.Entity<Setting>().Property(s => s.CanDelete).HasDefaultValue(true);

            builder.Entity<PageContent>().Property(pc => pc.ContentType).HasDefaultValue("Text");

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

            var parish = new Group {Id = 1, Name = "Parish"};
            var clergy = new Group {Id = 2, Name = "Clergy"};

            builder.Entity<Group>().HasData(
                parish,
                clergy,
                new Group { Id = 3, Name = "Lectors" },
                new Group { Id = 4, Name = "Commentators" },
                new Group { Id = 5, Name = "Servers" },
                new Group { Id = 6, Name = "Greeters" },
                new Group { Id = 7, Name = "ExtraordinaryMinisters" },
                new Group { Id = 8, Name = "Musicians" },
                new Group { Id = 9, Name = "Singers" },
                new Group { Id = 10, Name = "Ushers" },
                new Group { Id = 11, Name = "Pastoral Council" },
                new Group { Id = 12, Name = "Technology Committee" },
                new Group { Id = 13, Name = "Finance Committee" },
                new Group { Id = 14, Name = "Liturgy Committee" }
            );

            builder.Entity<Minister>().HasData(
                new Minister { Id = 1, Title = "Celebrant" },
                new Minister { Id = 2, Title = "Lector"},
                new Minister { Id = 3, Title = "Server" },
                new Minister { Id = 4, Title = "Greeter" },
                new Minister { Id = 5, Title = "Extraorinary Minister" },
                new Minister { Id = 6, Title = "Usher" },
                new Minister { Id = 7, Title = "Musicion" },
                new Minister { Id = 8, Title = "Singer" }
            );

            base.OnModelCreating(builder);
        }
    }
}
