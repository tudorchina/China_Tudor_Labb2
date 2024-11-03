using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace China_Tudor_Labb2.Migrations
{
    /// <inheritdoc />
    public partial class Author : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Authors_AuthorsID",
                table: "Book");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.RenameColumn(
                name: "AuthorsID",
                table: "Book",
                newName: "AuthorID");

            migrationBuilder.RenameIndex(
                name: "IX_Book_AuthorsID",
                table: "Book",
                newName: "IX_Book_AuthorID");

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author_AuthorID",
                table: "Book",
                column: "AuthorID",
                principalTable: "Author",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author_AuthorID",
                table: "Book");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.RenameColumn(
                name: "AuthorID",
                table: "Book",
                newName: "AuthorsID");

            migrationBuilder.RenameIndex(
                name: "IX_Book_AuthorID",
                table: "Book",
                newName: "IX_Book_AuthorsID");

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Authors_AuthorsID",
                table: "Book",
                column: "AuthorsID",
                principalTable: "Authors",
                principalColumn: "ID");
        }
    }
}
