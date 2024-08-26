using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrlShortenerMVC.Migrations.AppDb
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TokenModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokenModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShortenedUrl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LongUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClickCount = table.Column<int>(type: "int", nullable: false),
                    TokenId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortenedUrl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShortenedUrl_TokenModel_TokenId",
                        column: x => x.TokenId,
                        principalTable: "TokenModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShortenedUrl_TokenId",
                table: "ShortenedUrl",
                column: "TokenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShortenedUrl");

            migrationBuilder.DropTable(
                name: "TokenModel");
        }
    }
}
