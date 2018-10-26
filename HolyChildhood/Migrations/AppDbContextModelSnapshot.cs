﻿// <auto-generated />
using System;
using HolyChildhood.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HolyChildhood.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rc1-32029")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HolyChildhood.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("HolyChildhood.Models.Calendar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Calendars");
                });

            modelBuilder.Entity("HolyChildhood.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AllDay");

                    b.Property<DateTime>("BeginDate");

                    b.Property<int?>("CalendarId");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("EndDate");

                    b.Property<string>("Location");

                    b.Property<string>("Notes");

                    b.Property<bool>("Repeats");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("CalendarId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("HolyChildhood.Models.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Title");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("HolyChildhood.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Groups");

                    b.HasData(
                        new { Id = 1, Name = "Parish" },
                        new { Id = 2, Name = "Clergy" },
                        new { Id = 3, Name = "Lectors" },
                        new { Id = 4, Name = "Commentators" },
                        new { Id = 5, Name = "Servers" },
                        new { Id = 6, Name = "Greeters" },
                        new { Id = 7, Name = "ExtraordinaryMinisters" },
                        new { Id = 8, Name = "Musicians" },
                        new { Id = 9, Name = "Singers" },
                        new { Id = 10, Name = "Ushers" },
                        new { Id = 11, Name = "Pastoral Council" },
                        new { Id = 12, Name = "Technology Committee" },
                        new { Id = 13, Name = "Finance Committee" },
                        new { Id = 14, Name = "Liturgy Committee" }
                    );
                });

            modelBuilder.Entity("HolyChildhood.Models.MassEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EventId");

                    b.Property<string>("FirstReading");

                    b.Property<string>("Gospel");

                    b.Property<string>("Intentions");

                    b.Property<string>("SecondReading");

                    b.HasKey("Id");

                    b.HasIndex("EventId")
                        .IsUnique();

                    b.ToTable("MassEvents");
                });

            modelBuilder.Entity("HolyChildhood.Models.MeetingEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Agenda");

                    b.Property<int>("EventId");

                    b.Property<string>("Minutes");

                    b.HasKey("Id");

                    b.HasIndex("EventId")
                        .IsUnique();

                    b.ToTable("MeetingEvents");
                });

            modelBuilder.Entity("HolyChildhood.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GroupId");

                    b.Property<int?>("ParishionerId");

                    b.Property<string>("Position");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("ParishionerId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("HolyChildhood.Models.Minister", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Ministers");

                    b.HasData(
                        new { Id = 1, Title = "Celebrant" },
                        new { Id = 2, Title = "Lector" },
                        new { Id = 3, Title = "Server" },
                        new { Id = 4, Title = "Greeter" },
                        new { Id = 5, Title = "Extraorinary Minister" },
                        new { Id = 6, Title = "Usher" },
                        new { Id = 7, Title = "Musicion" },
                        new { Id = 8, Title = "Singer" }
                    );
                });

            modelBuilder.Entity("HolyChildhood.Models.Page", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ParentId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("HolyChildhood.Models.PageContent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<string>("ContentType")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("Text");

                    b.Property<int>("Height");

                    b.Property<int?>("PageId");

                    b.Property<int>("Width");

                    b.Property<int>("X");

                    b.Property<int>("Y");

                    b.HasKey("Id");

                    b.HasIndex("PageId");

                    b.ToTable("PageContents");
                });

            modelBuilder.Entity("HolyChildhood.Models.Parishioner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("MiddleInitial");

                    b.Property<string>("Title");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Parishioners");
                });

            modelBuilder.Entity("HolyChildhood.Models.ParishionerMassEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MassEventId");

                    b.Property<int>("MinisterId");

                    b.Property<int>("ParishionerId");

                    b.HasKey("Id");

                    b.HasIndex("MassEventId");

                    b.HasIndex("MinisterId");

                    b.HasIndex("ParishionerId");

                    b.ToTable("ParishionerMassEvent");
                });

            modelBuilder.Entity("HolyChildhood.Models.Setting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CanDelete")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<string>("Key")
                        .IsRequired();

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasAlternateKey("Key")
                        .HasName("AlternateKey_Key");

                    b.ToTable("Settings");

                    b.HasData(
                        new { Id = 1, CanDelete = false, Key = "Title", Value = "Holy Childhood of Jesus" },
                        new { Id = 2, CanDelete = false, Key = "Phone", Value = "(618) 566-2958" },
                        new { Id = 3, CanDelete = false, Key = "Email", Value = "hcc@holychildhoodchurch.com" },
                        new { Id = 4, CanDelete = false, Key = "Address", Value = "419 East Church St." },
                        new { Id = 5, CanDelete = false, Key = "City", Value = "Mascoutah" },
                        new { Id = 6, CanDelete = false, Key = "State", Value = "IL" },
                        new { Id = 7, CanDelete = false, Key = "Zipcode", Value = "62258" },
                        new { Id = 8, CanDelete = false, Key = "Mission_Statement", Value = "To be a credible sign of God’s love and care, Holy Childhood Parish needs to be a loving, charitable and caring community that is spiritually challenging, generously welcoming and liturgically alive. We strive to reach out to those in spiritual need and basic material needs. We will be open to the ideas of others, and, with God’s help, continue to live out the Gospel message." },
                        new { Id = 9, CanDelete = false, Key = "Quote", Value = "At Holy Childhood, we use the gifts that God has given us, our gifts of time, talent and treasure, to further the Kingdom of God here on earth." }
                    );
                });

            modelBuilder.Entity("HolyChildhood.Models.VolunteerEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EventId");

                    b.HasKey("Id");

                    b.HasIndex("EventId")
                        .IsUnique();

                    b.ToTable("VolunteerEvents");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("HolyChildhood.Models.Event", b =>
                {
                    b.HasOne("HolyChildhood.Models.Calendar", "Calendar")
                        .WithMany("Events")
                        .HasForeignKey("CalendarId");
                });

            modelBuilder.Entity("HolyChildhood.Models.MassEvent", b =>
                {
                    b.HasOne("HolyChildhood.Models.Event", "Event")
                        .WithOne("MassEvent")
                        .HasForeignKey("HolyChildhood.Models.MassEvent", "EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HolyChildhood.Models.MeetingEvent", b =>
                {
                    b.HasOne("HolyChildhood.Models.Event", "Event")
                        .WithOne("MeetingEvent")
                        .HasForeignKey("HolyChildhood.Models.MeetingEvent", "EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HolyChildhood.Models.Member", b =>
                {
                    b.HasOne("HolyChildhood.Models.Group", "Group")
                        .WithMany("Members")
                        .HasForeignKey("GroupId");

                    b.HasOne("HolyChildhood.Models.Parishioner", "Parishioner")
                        .WithMany("GroupMemberships")
                        .HasForeignKey("ParishionerId");
                });

            modelBuilder.Entity("HolyChildhood.Models.Page", b =>
                {
                    b.HasOne("HolyChildhood.Models.Page", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("HolyChildhood.Models.PageContent", b =>
                {
                    b.HasOne("HolyChildhood.Models.Page", "Page")
                        .WithMany("PageContents")
                        .HasForeignKey("PageId");
                });

            modelBuilder.Entity("HolyChildhood.Models.Parishioner", b =>
                {
                    b.HasOne("HolyChildhood.Models.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("HolyChildhood.Models.ParishionerMassEvent", b =>
                {
                    b.HasOne("HolyChildhood.Models.MassEvent", "MassEvent")
                        .WithMany("Ministers")
                        .HasForeignKey("MassEventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HolyChildhood.Models.Minister", "Minister")
                        .WithMany()
                        .HasForeignKey("MinisterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HolyChildhood.Models.Parishioner", "Parishioner")
                        .WithMany()
                        .HasForeignKey("ParishionerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HolyChildhood.Models.VolunteerEvent", b =>
                {
                    b.HasOne("HolyChildhood.Models.Event", "Event")
                        .WithOne("VolunteerEvent")
                        .HasForeignKey("HolyChildhood.Models.VolunteerEvent", "EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("HolyChildhood.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("HolyChildhood.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HolyChildhood.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("HolyChildhood.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
