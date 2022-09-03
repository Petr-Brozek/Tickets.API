using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tickets.Infrastructure.Migrations;

 public partial class AddTicketStateFlowSeed : Migration
 {
     protected override void Up(MigrationBuilder migrationBuilder)
     {
         migrationBuilder.InsertData(
             table: "TicketStateFlows",
             columns: new[] { "OriginalStateName", "PossibleStateName", "LabelInfinitiveForm" },
             values: new object[,]
             {
                 { "New", "InProgress", "Start working" },
                 { "New", "Cancelled", "Cancel" },
                 { "InProgress", "Finished", "Finish" },
                 { "InProgress", "Cancelled", "Cancel" },
                 { "Finished", "InProgress", "Re-open" },
                 { "Cancelled", "InProgress", "Re-open" }
             });
     }

     protected override void Down(MigrationBuilder migrationBuilder)
     {
         migrationBuilder.DeleteData(
             table: "TicketStateFlows",
             keyColumns: new[] { "OriginalStateName", "PossibleStateName" },
             keyValues: new object[] { "New", "InProgress" });

         migrationBuilder.DeleteData(
             table: "TicketStateFlows",
             keyColumns: new[] { "OriginalStateName", "PossibleStateName" },
             keyValues: new object[] { "New", "Cancelled" });

         migrationBuilder.DeleteData(
             table: "TicketStateFlows",
             keyColumns: new[] { "OriginalStateName", "PossibleStateName" },
             keyValues: new object[] { "InProgress", "Finished" });

         migrationBuilder.DeleteData(
             table: "TicketStateFlows",
             keyColumns: new[] { "OriginalStateName", "PossibleStateName" },
             keyValues: new object[] { "InProgress", "Cancelled" });

         migrationBuilder.DeleteData(
             table: "TicketStateFlows",
             keyColumns: new[] { "OriginalStateName", "PossibleStateName" },
             keyValues: new object[] { "Finished", "InProgress" });

         migrationBuilder.DeleteData(
             table: "TicketStateFlows",
             keyColumns: new[] { "OriginalStateName", "PossibleStateName" },
             keyValues: new object[] { "Cancelled", "InProgress" });
     }
 }
