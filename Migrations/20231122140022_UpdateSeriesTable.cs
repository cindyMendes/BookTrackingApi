using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookTrackingApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeriesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsFinised",
                table: "Series",
                newName: "IsFinished");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsFinished",
                table: "Series",
                newName: "IsFinised");
        }
    }
}
