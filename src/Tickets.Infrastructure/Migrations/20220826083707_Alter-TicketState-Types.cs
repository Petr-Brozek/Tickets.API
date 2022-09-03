using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tickets.Infrastructure.Migrations;

 public partial class AlterTicketStateTypes : Migration
 {
     protected override void Up(MigrationBuilder migrationBuilder)
     {
         migrationBuilder.DropTable(
             name: "TicketStateFlows");

         migrationBuilder.DeleteData(
             table: "TicketStates",
             keyColumn: "Name",
             keyValue: "Cancelled");

         migrationBuilder.DeleteData(
             table: "TicketStates",
             keyColumn: "Name",
             keyValue: "Finished");

         migrationBuilder.DeleteData(
             table: "TicketStates",
             keyColumn: "Name",
             keyValue: "InProgress");

         migrationBuilder.DeleteData(
             table: "TicketStates",
             keyColumn: "Name",
             keyValue: "New");

         migrationBuilder.DropColumn(
             name: "State",
             table: "Tickets");

         migrationBuilder.AddColumn<string>(
             name: "StateName",
             table: "Tickets",
             type: "nvarchar(450)",
             nullable: false,
             defaultValue: "");

         migrationBuilder.CreateIndex(
             name: "IX_Tickets_StateName",
             table: "Tickets",
             column: "StateName");

         migrationBuilder.AddForeignKey(
             name: "FK_Tickets_TicketStates_StateName",
             table: "Tickets",
             column: "StateName",
             principalTable: "TicketStates",
             principalColumn: "Name",
             onDelete: ReferentialAction.Cascade);
     }

     protected override void Down(MigrationBuilder migrationBuilder)
     {
         migrationBuilder.DropForeignKey(
             name: "FK_Tickets_TicketStates_StateName",
             table: "Tickets");

         migrationBuilder.DropIndex(
             name: "IX_Tickets_StateName",
             table: "Tickets");

         migrationBuilder.DropColumn(
             name: "StateName",
             table: "Tickets");

         migrationBuilder.AddColumn<string>(
             name: "State",
             table: "Tickets",
             type: "nvarchar(max)",
             nullable: false,
             defaultValue: "");

         migrationBuilder.CreateTable(
             name: "TicketStateFlows",
             columns: table => new
             {
                 OriginalStateName = table.Column<int>(type: "int", nullable: false),
                 PossibleStateName = table.Column<int>(type: "int", nullable: false),
                 LabelInfinitiveForm = table.Column<string>(type: "nvarchar(max)", nullable: false)
             },
             constraints: table =>
             {
                 table.PrimaryKey("PK_TicketStateFlows", x => new { x.OriginalStateName, x.PossibleStateName });
             });

         migrationBuilder.InsertData(
             table: "TicketStateFlows",
             columns: new[] { "OriginalStateName", "PossibleStateName", "LabelInfinitiveForm" },
             values: new object[,]
             {
                 { 0, 1, "Start Working" },
                 { 0, 3, "Cancel" },
                 { 1, 2, "Finish" },
                 { 1, 3, "Cancel" },
                 { 2, 1, "Re-open" },
                 { 3, 1, "Re-open" }
             });

         migrationBuilder.InsertData(
             table: "TicketStates",
             columns: new[] { "Name", "IsNewTicketDefault", "Label" },
             values: new object[,]
             {
                 { "Cancelled", false, "Cancelled" },
                 { "Finished", false, "Fnished" },
                 { "InProgress", false, "In Progress" },
                 { "New", true, "New" }
             });
     }
 }
