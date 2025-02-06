using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace supercines.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Peliculas",
                columns: table => new
                {
                    IdPelicula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TituloDistribucion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TituloOriginal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdiomaOriginal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subtitulada = table.Column<bool>(type: "bit", nullable: false),
                    PaisOrigen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AñoProduccion = table.Column<int>(type: "int", nullable: false),
                    UrlSitioWeb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duracion = table.Column<TimeSpan>(type: "time", nullable: false),
                    Clasificacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaEstreno = table.Column<DateOnly>(type: "date", nullable: false),
                    Resumen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.IdPelicula);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nacionalidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CantidadPeliculas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Capacidad = table.Column<int>(type: "int", nullable: false),
                    CineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Salas_Cines_CineId",
                        column: x => x.CineId,
                        principalTable: "Cines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Opiniones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    Calificacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PeliculaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opiniones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opiniones_Peliculas_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "IdPelicula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Repartos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeliculaId = table.Column<int>(type: "int", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    Personaje = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repartos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Repartos_Peliculas_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "IdPelicula",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Repartos_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Funciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeliculaId = table.Column<int>(type: "int", nullable: false),
                    SalaId = table.Column<int>(type: "int", nullable: false),
                    DiaSemana = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoraInicio = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funciones_Peliculas_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "IdPelicula",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funciones_Salas_SalaId",
                        column: x => x.SalaId,
                        principalTable: "Salas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Promociones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descuento = table.Column<double>(type: "float", nullable: false),
                    FuncionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promociones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promociones_Funciones_FuncionId",
                        column: x => x.FuncionId,
                        principalTable: "Funciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_PeliculaId",
                table: "Funciones",
                column: "PeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_SalaId",
                table: "Funciones",
                column: "SalaId");

            migrationBuilder.CreateIndex(
                name: "IX_Opiniones_PeliculaId",
                table: "Opiniones",
                column: "PeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_Promociones_FuncionId",
                table: "Promociones",
                column: "FuncionId");

            migrationBuilder.CreateIndex(
                name: "IX_Repartos_PeliculaId",
                table: "Repartos",
                column: "PeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_Repartos_PersonaId",
                table: "Repartos",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Salas_CineId",
                table: "Salas",
                column: "CineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Opiniones");

            migrationBuilder.DropTable(
                name: "Promociones");

            migrationBuilder.DropTable(
                name: "Repartos");

            migrationBuilder.DropTable(
                name: "Funciones");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Peliculas");

            migrationBuilder.DropTable(
                name: "Salas");

            migrationBuilder.DropTable(
                name: "Cines");
        }
    }
}
