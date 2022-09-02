using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tickets.Infrastructure.Migrations;

 public partial class SeedTicketStateFlows : Migration
 {
     protected override void Up(MigrationBuilder migrationBuilder)
     {
         migrationBuilder.InsertData(
             table: "TicketStateFlows",
             columns: new[] { "OriginalState", "PossibleState", "InfinitiveFormLabel" },
             values: new object[,]
             {
                 { 0, 1, "Start Working" },
                 { 0, 3, "Cancel" },
                 { 1, 2, "Finish" },
                 { 1, 3, "Cancel" },
                 { 2, 1, "Re-open" },
                 { 3, 1, "Re-open" }
             });
     }

     protected override void Down(MigrationBuilder migrationBuilder)
     {
         migrationBuilder.DeleteData(
             table: "TicketStateFlows",
             keyColumns: new[] { "OriginalState", "PossibleState" },
             keyValues: new object[] { 0, 1 });

         migrationBuilder.DeleteData(
             table: "TicketStateFlows",
             keyColumns: new[] { "OriginalState", "PossibleState" },
             keyValues: new object[] { 0, 3 });

         migrationBuilder.DeleteData(
             table: "TicketStateFlows",
             keyColumns: new[] { "OriginalState", "PossibleState" },
             keyValues: new object[] { 1, 2 });

         migrationBuilder.DeleteData(
             table: "TicketStateFlows",
             keyColumns: new[] { "OriginalState", "PossibleState" },
             keyValues: new object[] { 1, 3 });

         migrationBuilder.DeleteData(
             table: "TicketStateFlows",
             keyColumns: new[] { "OriginalState", "PossibleState" },
             keyValues: new object[] { 2, 1 });

         migrationBuilder.DeleteData(
             table: "TicketStateFlows",
             keyColumns: new[] { "OriginalState", "PossibleState" },
             keyValues: new object[] { 3, 1 });
     }
 }
