using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppEF.Data.Migrations
{
    /// <inheritdoc />
    public partial class libros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Copias = table.Column<int>(type: "int", nullable: false),
                    generoId = table.Column<int>(type: "int", nullable: false),
                    ubicacionId = table.Column<int>(type: "int", nullable: false),
                    editorialId = table.Column<int>(type: "int", nullable: false),
                    autorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Libros_Autores_autorId",
                        column: x => x.autorId,
                        principalTable: "Autores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Libros_Editoriales_editorialId",
                        column: x => x.editorialId,
                        principalTable: "Editoriales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Libros_Generos_generoId",
                        column: x => x.generoId,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Libros_Ubicaciones_ubicacionId",
                        column: x => x.ubicacionId,
                        principalTable: "Ubicaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libros_autorId",
                table: "Libros",
                column: "autorId");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_editorialId",
                table: "Libros",
                column: "editorialId");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_generoId",
                table: "Libros",
                column: "generoId");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_ubicacionId",
                table: "Libros",
                column: "ubicacionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libros");
        }
    }
}
