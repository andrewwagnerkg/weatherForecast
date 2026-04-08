using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Change_ForecastCash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Current",
                table: "ForecastCashes");

            migrationBuilder.DropColumn(
                name: "Daily",
                table: "ForecastCashes");

            migrationBuilder.RenameColumn(
                name: "Hourly",
                table: "ForecastCashes",
                newName: "Forecast");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Forecast",
                table: "ForecastCashes",
                newName: "Hourly");

            migrationBuilder.AddColumn<string>(
                name: "Current",
                table: "ForecastCashes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Daily",
                table: "ForecastCashes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
