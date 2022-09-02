using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tickets.Infrastructure.Migrations;

 public partial class AddTicketStateSeed : Migration
 {
     protected override void Up(MigrationBuilder migrationBuilder)
     {
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
         migrationBuilder.DeleteData(
             table: "TicketStates",
             keyColumn: "Name",
             keyValue: "New");

         migrationBuilder.DeleteData(
             table: "TicketStates",
             keyColumn: "Name",
             keyValue: "InProgress");

         migrationBuilder.DeleteData(
             table: "TicketStates",
             keyColumn: "Name",
             keyValue: "Finished");

         migrationBuilder.DeleteData(
             table: "TicketStates",
             keyColumn: "Name",
             keyValue: "Cancelled");
     }
 }
