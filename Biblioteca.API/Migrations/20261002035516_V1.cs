using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Biblioteca.API.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "autor",
                columns: table => new
                {
                    id_autor = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    apellido = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    nacionalidad = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_autor", x => x.id_autor);
                });

            migrationBuilder.CreateTable(
                name: "editorial",
                columns: table => new
                {
                    id_editorial = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    pais = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_editorial", x => x.id_editorial);
                });

            migrationBuilder.CreateTable(
                name: "genero",
                columns: table => new
                {
                    id_genero = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genero", x => x.id_genero);
                });

            migrationBuilder.CreateTable(
                name: "libro",
                columns: table => new
                {
                    id_libro = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    titulo = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    anio_publicacion = table.Column<int>(type: "integer", nullable: false),
                    isbn = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    descripcion = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    cantidad = table.Column<int>(type: "integer", nullable: false),
                    id_autor = table.Column<int>(type: "integer", nullable: false),
                    id_genero = table.Column<int>(type: "integer", nullable: false),
                    id_editorial = table.Column<int>(type: "integer", nullable: false),
                    AutorIdAutor = table.Column<int>(type: "integer", nullable: true),
                    GeneroIdGenero = table.Column<int>(type: "integer", nullable: true),
                    EditorialIdEditorial = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_libro", x => x.id_libro);
                    table.ForeignKey(
                        name: "FK_libro_autor_AutorIdAutor",
                        column: x => x.AutorIdAutor,
                        principalTable: "autor",
                        principalColumn: "id_autor");
                    table.ForeignKey(
                        name: "FK_libro_editorial_EditorialIdEditorial",
                        column: x => x.EditorialIdEditorial,
                        principalTable: "editorial",
                        principalColumn: "id_editorial");
                    table.ForeignKey(
                        name: "FK_libro_genero_GeneroIdGenero",
                        column: x => x.GeneroIdGenero,
                        principalTable: "genero",
                        principalColumn: "id_genero");
                });

            migrationBuilder.CreateIndex(
                name: "IX_libro_AutorIdAutor",
                table: "libro",
                column: "AutorIdAutor");

            migrationBuilder.CreateIndex(
                name: "IX_libro_EditorialIdEditorial",
                table: "libro",
                column: "EditorialIdEditorial");

            migrationBuilder.CreateIndex(
                name: "IX_libro_GeneroIdGenero",
                table: "libro",
                column: "GeneroIdGenero");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "libro");

            migrationBuilder.DropTable(
                name: "autor");

            migrationBuilder.DropTable(
                name: "editorial");

            migrationBuilder.DropTable(
                name: "genero");
        }
    }
}
