using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_api.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dispositivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Modelo = table.Column<string>(type: "varchar(200)", nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(1000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dispositivos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "datos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tiempo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Temperatura = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    HumedadRelativa = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    HumedadSuelo = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    RadiacionSolar = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    Dispositivo_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_datos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_datos_Dispositivos",
                        column: x => x.Dispositivo_Id,
                        principalTable: "dispositivos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_datos_Dispositivos_Id",
                table: "datos",
                column: "Dispositivo_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "datos");

            migrationBuilder.DropTable(
                name: "dispositivos");
        }
    }
}
