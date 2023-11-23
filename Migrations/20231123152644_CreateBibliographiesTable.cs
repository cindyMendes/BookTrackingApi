using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookTrackingApi.Migrations
{
    /// <inheritdoc />
    public partial class CreateBibliographiesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bibliographies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bibliographies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bibliographies_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bibliographies_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bibliographies_AuthorId",
                table: "Bibliographies",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Bibliographies_BookId",
                table: "Bibliographies",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bibliographies");
        }
    }
}
