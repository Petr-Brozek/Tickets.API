using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tickets.Infrastructure.Migrations;

 public partial class UpdateTicketStateRemovePropIsNewTicketDefault : Migration
 {
     protected override void Up(MigrationBuilder migrationBuilder)
     {
         migrationBuilder.DropColumn(
             name: "IsNewTicketDefault",
             table: "TicketStates");
     }

     protected override void Down(MigrationBuilder migrationBuilder)
     {
         migrationBuilder.AddColumn<bool>(
             name: "IsNewTicketDefault",
             table: "TicketStates",
             type: "bit",
             nullable: false,
             defaultValue: false);

         migrationBuilder.UpdateData(
             table: "TicketStates",
             keyColumn: "Name",
             keyValue: "New",
             column: "IsNewTicketDefault",
             value: true);
     }
 }
