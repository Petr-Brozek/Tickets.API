using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tickets.Infrastructure.Migrations;

 public partial class CreateTableTicketComments : Migration
 {
     protected override void Up(MigrationBuilder migrationBuilder)
     {
         migrationBuilder.CreateTable(
             name: "TicketComments",
             columns: table => new
             {
                 Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                 TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                 CreatedByUserProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                 Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                 CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                 LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
             },
             constraints: table =>
             {
                 table.PrimaryKey("PK_TicketComments", x => x.Id);
                 table.ForeignKey(
                     name: "FK_TicketComments_Tickets_TicketId",
                     column: x => x.TicketId,
                     principalTable: "Tickets",
                     principalColumn: "Id",
                     onDelete: ReferentialAction.Cascade);
                 table.ForeignKey(
                     name: "FK_TicketComments_UserProfiles_CreatedByUserProfileId",
                     column: x => x.CreatedByUserProfileId,
                     principalTable: "UserProfiles",
                     principalColumn: "UserProfileId",
                     onDelete: ReferentialAction.NoAction);
             });

         migrationBuilder.CreateIndex(
             name: "IX_TicketComments_CreatedByUserProfileId",
             table: "TicketComments",
             column: "CreatedByUserProfileId");

         migrationBuilder.CreateIndex(
             name: "IX_TicketComments_TicketId",
             table: "TicketComments",
             column: "TicketId");
     }

     protected override void Down(MigrationBuilder migrationBuilder)
     {
         migrationBuilder.DropTable(
             name: "TicketComments");
     }
 }
