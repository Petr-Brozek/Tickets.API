using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tickets.Infrastructure.Migrations;

 public partial class AddTicketStateFlow2 : Migration
 {
     protected override void Up(MigrationBuilder migrationBuilder)
     {
         migrationBuilder.CreateTable(
             name: "TicketStateFlows",
             columns: table => new
             {
                 OriginalStateName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                 PossibleStateName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                 LabelInfinitiveForm = table.Column<string>(type: "nvarchar(max)", nullable: false)
             },
             constraints: table =>
             {
                 table.PrimaryKey("PK_TicketStateFlows", x => new { x.OriginalStateName, x.PossibleStateName });
                 table.ForeignKey(
                     name: "FK_TicketStateFlows_TicketStates_OriginalStateName",
                     column: x => x.OriginalStateName,
                     principalTable: "TicketStates",
                     principalColumn: "Name",
                     onDelete: ReferentialAction.NoAction);
                 table.ForeignKey(
                     name: "FK_TicketStateFlows_TicketStates_PossibleStateName",
                     column: x => x.PossibleStateName,
                     principalTable: "TicketStates",
                     principalColumn: "Name",
                     onDelete: ReferentialAction.NoAction);
             });

         migrationBuilder.CreateIndex(
             name: "IX_TicketStateFlows_PossibleStateName",
             table: "TicketStateFlows",
             column: "PossibleStateName");
     }

     protected override void Down(MigrationBuilder migrationBuilder)
     {
         migrationBuilder.DropTable(
             name: "TicketStateFlows");
     }
 }
