using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace supercines.Migrations
{
    /// <inheritdoc />
    public partial class seg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "personasModelId",
                table: "Repartos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "peliculasModelIdPelicula",
                table: "Funciones",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "salasModelId",
                table: "Funciones",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Repartos_personasModelId",
                table: "Repartos",
                column: "personasModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_peliculasModelIdPelicula",
                table: "Funciones",
                column: "peliculasModelIdPelicula");

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_salasModelId",
                table: "Funciones",
                column: "salasModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funciones_Peliculas_peliculasModelIdPelicula",
                table: "Funciones",
                column: "peliculasModelIdPelicula",
                principalTable: "Peliculas",
                principalColumn: "IdPelicula");

            migrationBuilder.AddForeignKey(
                name: "FK_Funciones_Salas_salasModelId",
                table: "Funciones",
                column: "salasModelId",
                principalTable: "Salas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Repartos_Personas_personasModelId",
                table: "Repartos",
                column: "personasModelId",
                principalTable: "Personas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funciones_Peliculas_peliculasModelIdPelicula",
                table: "Funciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Funciones_Salas_salasModelId",
                table: "Funciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Repartos_Personas_personasModelId",
                table: "Repartos");

            migrationBuilder.DropIndex(
                name: "IX_Repartos_personasModelId",
                table: "Repartos");

            migrationBuilder.DropIndex(
                name: "IX_Funciones_peliculasModelIdPelicula",
                table: "Funciones");

            migrationBuilder.DropIndex(
                name: "IX_Funciones_salasModelId",
                table: "Funciones");

            migrationBuilder.DropColumn(
                name: "personasModelId",
                table: "Repartos");

            migrationBuilder.DropColumn(
                name: "peliculasModelIdPelicula",
                table: "Funciones");

            migrationBuilder.DropColumn(
                name: "salasModelId",
                table: "Funciones");
        }
    }
}
