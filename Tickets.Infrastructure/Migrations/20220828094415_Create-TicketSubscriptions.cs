using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tickets.Infrastructure.Migrations
{
    public partial class CreateTicketSubscriptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TicketSubscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToUserProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerUserProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DistrType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToRole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketSubscriptions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketSubscriptions");
        }
    }
}
