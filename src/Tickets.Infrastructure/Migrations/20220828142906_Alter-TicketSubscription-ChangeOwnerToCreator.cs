using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tickets.Infrastructure.Migrations
{
    public partial class AlterTicketSubscriptionChangeOwnerToCreator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ToUserProfileId",
                table: "TicketSubscriptions",
                newName: "SubscriberUserProfileId");

            migrationBuilder.RenameColumn(
                name: "ToRole",
                table: "TicketSubscriptions",
                newName: "SubscriberRole");

            migrationBuilder.RenameColumn(
                name: "OwnerUserProfileId",
                table: "TicketSubscriptions",
                newName: "CreatedByUserProfileId");

            migrationBuilder.AddColumn<int>(
                name: "OnTicketAction",
                table: "TicketSubscriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TicketSubscriptions_TicketId",
                table: "TicketSubscriptions",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketSubscriptions_Tickets_TicketId",
                table: "TicketSubscriptions",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketSubscriptions_Tickets_TicketId",
                table: "TicketSubscriptions");

            migrationBuilder.DropIndex(
                name: "IX_TicketSubscriptions_TicketId",
                table: "TicketSubscriptions");

            migrationBuilder.DropColumn(
                name: "OnTicketAction",
                table: "TicketSubscriptions");

            migrationBuilder.RenameColumn(
                name: "SubscriberUserProfileId",
                table: "TicketSubscriptions",
                newName: "ToUserProfileId");

            migrationBuilder.RenameColumn(
                name: "SubscriberRole",
                table: "TicketSubscriptions",
                newName: "ToRole");

            migrationBuilder.RenameColumn(
                name: "CreatedByUserProfileId",
                table: "TicketSubscriptions",
                newName: "OwnerUserProfileId");
        }
    }
}
