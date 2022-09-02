using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tickets.Infrastructure.Migrations;

 public partial class CreateTicketStateFlows : Migration
 {
     protected override void Up(MigrationBuilder migrationBuilder)
     {
         migrationBuilder.DropForeignKey(
             name: "FK_TicketComments_UserProfiles_CreatedByUserProfileId",
             table: "TicketComments");

         migrationBuilder.DropIndex(
             name: "IX_TicketComments_CreatedByUserProfileId",
             table: "TicketComments");

         migrationBuilder.CreateTable(
             name: "TicketStateFlows",
             columns: table => new
             {
                 OriginalState = table.Column<int>(type: "int", nullable: false),
                 PossibleState = table.Column<int>(type: "int", nullable: false),
                 InfinitiveFormLabel = table.Column<string>(type: "nvarchar(max)", nullable: false)
             },
             constraints: table =>
             {
                 table.PrimaryKey("PK_TicketStateFlows", x => new { x.OriginalState, x.PossibleState });
             });
     }

     protected override void Down(MigrationBuilder migrationBuilder)
     {
         migrationBuilder.DropTable(
             name: "TicketStateFlows");

         migrationBuilder.CreateIndex(
             name: "IX_TicketComments_CreatedByUserProfileId",
             table: "TicketComments",
             column: "CreatedByUserProfileId");

         migrationBuilder.AddForeignKey(
             name: "FK_TicketComments_UserProfiles_CreatedByUserProfileId",
             table: "TicketComments",
             column: "CreatedByUserProfileId",
             principalTable: "UserProfiles",
             principalColumn: "UserProfileId",
             onDelete: ReferentialAction.Cascade);
     }
 }
