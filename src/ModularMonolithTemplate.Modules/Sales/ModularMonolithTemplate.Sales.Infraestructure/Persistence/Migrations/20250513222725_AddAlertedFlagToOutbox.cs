using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModularMonolithTemplate.Sales.Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddAlertedFlagToOutbox : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Alerted",
                schema: "infra",
                table: "OutboxMessages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alerted",
                schema: "infra",
                table: "OutboxMessages");
        }
    }
}
