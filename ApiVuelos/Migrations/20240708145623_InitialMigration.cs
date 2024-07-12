using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiVuelos.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aerolineas",
                columns: table => new
                {
                    IdAerolinea = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aerolineas", x => x.IdAerolinea);
                });

            migrationBuilder.CreateTable(
                name: "Vuelos",
                columns: table => new
                {
                    IdVuelo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAerolinea = table.Column<int>(type: "int", nullable: false),
                    Origen = table.Column<string>(type: "varchar(35)", nullable: false),
                    Destino = table.Column<string>(type: "varchar(35)", nullable: false),
                    FechaIda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaVuelta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Clase = table.Column<string>(type: "varchar(20)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vuelos", x => x.IdVuelo);
                    table.ForeignKey(
                        name: "FK_Vuelos_Aerolineas_IdAerolinea",
                        column: x => x.IdAerolinea,
                        principalTable: "Aerolineas",
                        principalColumn: "IdAerolinea",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vuelos_IdAerolinea",
                table: "Vuelos",
                column: "IdAerolinea");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vuelos");

            migrationBuilder.DropTable(
                name: "Aerolineas");
        }
    }
}
