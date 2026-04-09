using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Add_ForecastCash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ForecastCashes",
                columns: table => new
                {
                    LastUpdatedDateTime = table.Column<string>(type: "TEXT", nullable: false),
                    Current = table.Column<string>(type: "TEXT", nullable: false),
                    Daily = table.Column<string>(type: "TEXT", nullable: false),
                    Hourly = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForecastCashes", x => x.LastUpdatedDateTime);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ForecastCashes");
        }
    }
}
