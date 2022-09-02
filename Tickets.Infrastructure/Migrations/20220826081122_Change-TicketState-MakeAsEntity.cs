using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tickets.Infrastructure.Migrations;

 public partial class ChangeTicketStateMakeAsEntity : Migration
 {
     protected override void Up(MigrationBuilder migrationBuilder)
     {
         migrationBuilder.RenameColumn(
             name: "InfinitiveFormLabel",
             table: "TicketStateFlows",
             newName: "LabelInfinitiveForm");

         migrationBuilder.RenameColumn(
             name: "PossibleState",
             table: "TicketStateFlows",
             newName: "PossibleStateName");

         migrationBuilder.RenameColumn(
             name: "OriginalState",
             table: "TicketStateFlows",
             newName: "OriginalStateName");

         migrationBuilder.CreateTable(
             name: "TicketStates",
             columns: table => new
             {
                 Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                 Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                 IsNewTicketDefault = table.Column<bool>(type: "bit", nullable: false)
             },
             constraints: table =>
             {
                 table.PrimaryKey("PK_TicketStates", x => x.Name);
             });

         migrationBuilder.InsertData(
             table: "TicketStates",
             columns: new[] { "Name", "IsNewTicketDefault", "Label" },
             values: new object[,]
             {
                 { "New", true, "New" },
                 { "InProgress", false, "In Progress" },
                 { "Finished", false, "Fnished" },
                 { "Cancelled", false, "Cancelled" }
             });
     }

     protected override void Down(MigrationBuilder migrationBuilder)
     {
         migrationBuilder.DropTable(
             name: "TicketStates");

         migrationBuilder.RenameColumn(
             name: "LabelInfinitiveForm",
             table: "TicketStateFlows",
             newName: "InfinitiveFormLabel");

         migrationBuilder.RenameColumn(
             name: "PossibleStateName",
             table: "TicketStateFlows",
             newName: "PossibleState");

         migrationBuilder.RenameColumn(
             name: "OriginalStateName",
             table: "TicketStateFlows",
             newName: "OriginalState");
     }
 }
