using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HolyChildhood.Migrations
{
    public partial class groups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactInformations");

            migrationBuilder.DropColumn(
                name: "BeginTime",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "EndTime",
                table: "Events",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Events",
                newName: "BeginDate");

            migrationBuilder.AddColumn<bool>(
                name: "AllDay",
                table: "Events",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CalendarId",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Repeats",
                table: "Events",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Calendars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MassEvents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventId = table.Column<int>(nullable: false),
                    FirstReading = table.Column<string>(nullable: true),
                    SecondReading = table.Column<string>(nullable: true),
                    Gospel = table.Column<string>(nullable: true),
                    Intentions = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MassEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MassEvents_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MeetingEvents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventId = table.Column<int>(nullable: false),
                    Agenda = table.Column<string>(nullable: true),
                    Minutes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeetingEvents_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ministers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ministers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parishioners",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleInitial = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parishioners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parishioners_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VolunteerEvents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteerEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VolunteerEvents_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Position = table.Column<string>(nullable: true),
                    ParishionerId = table.Column<int>(nullable: true),
                    GroupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Members_Parishioners_ParishionerId",
                        column: x => x.ParishionerId,
                        principalTable: "Parishioners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParishionerMassEvent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MassEventId = table.Column<int>(nullable: false),
                    ParishionerId = table.Column<int>(nullable: false),
                    MinisterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParishionerMassEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParishionerMassEvent_MassEvents_MassEventId",
                        column: x => x.MassEventId,
                        principalTable: "MassEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParishionerMassEvent_Ministers_MinisterId",
                        column: x => x.MinisterId,
                        principalTable: "Ministers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParishionerMassEvent_Parishioners_ParishionerId",
                        column: x => x.ParishionerId,
                        principalTable: "Parishioners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Parish" },
                    { 14, "Liturgy Committee" },
                    { 13, "Finance Committee" },
                    { 12, "Technology Committee" },
                    { 11, "Pastoral Council" },
                    { 10, "Ushers" },
                    { 8, "Musicians" },
                    { 9, "Singers" },
                    { 6, "Greeters" },
                    { 5, "Servers" },
                    { 4, "Commentators" },
                    { 3, "Lectors" },
                    { 2, "Clergy" },
                    { 7, "ExtraordinaryMinisters" }
                });

            migrationBuilder.InsertData(
                table: "Ministers",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 6, "Usher" },
                    { 8, "Singer" },
                    { 7, "Musicion" },
                    { 5, "Extraorinary Minister" },
                    { 1, "Celebrant" },
                    { 3, "Server" },
                    { 2, "Lector" },
                    { 4, "Greeter" }
                });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Value",
                value: "(618) 566-2958");

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "Value",
                value: "hcc@holychildhoodchurch.com");

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 4,
                column: "Value",
                value: "419 East Church St.");

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 5,
                column: "Value",
                value: "Mascoutah");

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 6,
                column: "Value",
                value: "IL");

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 7,
                column: "Value",
                value: "62258");

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 8,
                column: "Value",
                value: "To be a credible sign of God’s love and care, Holy Childhood Parish needs to be a loving, charitable and caring community that is spiritually challenging, generously welcoming and liturgically alive. We strive to reach out to those in spiritual need and basic material needs. We will be open to the ideas of others, and, with God’s help, continue to live out the Gospel message.");

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 9,
                column: "Value",
                value: "At Holy Childhood, we use the gifts that God has given us, our gifts of time, talent and treasure, to further the Kingdom of God here on earth.");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CalendarId",
                table: "Events",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_MassEvents_EventId",
                table: "MassEvents",
                column: "EventId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MeetingEvents_EventId",
                table: "MeetingEvents",
                column: "EventId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Members_GroupId",
                table: "Members",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_ParishionerId",
                table: "Members",
                column: "ParishionerId");

            migrationBuilder.CreateIndex(
                name: "IX_ParishionerMassEvent_MassEventId",
                table: "ParishionerMassEvent",
                column: "MassEventId");

            migrationBuilder.CreateIndex(
                name: "IX_ParishionerMassEvent_MinisterId",
                table: "ParishionerMassEvent",
                column: "MinisterId");

            migrationBuilder.CreateIndex(
                name: "IX_ParishionerMassEvent_ParishionerId",
                table: "ParishionerMassEvent",
                column: "ParishionerId");

            migrationBuilder.CreateIndex(
                name: "IX_Parishioners_UserId",
                table: "Parishioners",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerEvents_EventId",
                table: "VolunteerEvents",
                column: "EventId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Calendars_CalendarId",
                table: "Events",
                column: "CalendarId",
                principalTable: "Calendars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Calendars_CalendarId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "Calendars");

            migrationBuilder.DropTable(
                name: "MeetingEvents");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "ParishionerMassEvent");

            migrationBuilder.DropTable(
                name: "VolunteerEvents");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "MassEvents");

            migrationBuilder.DropTable(
                name: "Ministers");

            migrationBuilder.DropTable(
                name: "Parishioners");

            migrationBuilder.DropIndex(
                name: "IX_Events_CalendarId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "AllDay",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "CalendarId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Repeats",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Events",
                newName: "EndTime");

            migrationBuilder.RenameColumn(
                name: "BeginDate",
                table: "Events",
                newName: "Date");

            migrationBuilder.AddColumn<DateTime>(
                name: "BeginTime",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ContactInformations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: true),
                    Index = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInformations", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Value",
                value: "");

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "Value",
                value: "");

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 4,
                column: "Value",
                value: "");

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 5,
                column: "Value",
                value: "");

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 6,
                column: "Value",
                value: "");

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 7,
                column: "Value",
                value: "");

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 8,
                column: "Value",
                value: "");

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 9,
                column: "Value",
                value: "");
        }
    }
}
