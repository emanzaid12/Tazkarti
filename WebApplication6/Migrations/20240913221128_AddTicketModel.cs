using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tazkarty.Migrations
{
    /// <inheritdoc />
    public partial class AddTicketModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookingTime",
                table: "Tickets",
                newName: "SelectedTime");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Tickets",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Tickets",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "SelectedTime",
                table: "Tickets",
                newName: "BookingTime");
        }
    }
}
