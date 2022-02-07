using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_api.Migrations
{
    public partial class bd_inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "kits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Propietario = table.Column<string>(type: "varchar(200)", nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(1000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(1000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dispositivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Modelo = table.Column<string>(type: "varchar(200)", nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(1000)", nullable: true),
                    TipoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dispositivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dispositivos_tipos_TipoId",
                        column: x => x.TipoId,
                        principalTable: "tipos",
                        principalColumn: "Id");
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

            migrationBuilder.CreateTable(
                name: "kits_dispositivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dispositivo_Id = table.Column<int>(type: "int", nullable: false),
                    Kit_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kits_dispositivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_kitDispositivo_Dispositivos",
                        column: x => x.Dispositivo_Id,
                        principalTable: "dispositivos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_kitDispositivo_Kit",
                        column: x => x.Kit_Id,
                        principalTable: "kits",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_datos_Dispositivos_Id",
                table: "datos",
                column: "Dispositivo_Id");

            migrationBuilder.CreateIndex(
                name: "IX_dispositivos_TipoId",
                table: "dispositivos",
                column: "TipoId");

            migrationBuilder.CreateIndex(
                name: "IX_kitDispositivo_Dispositivos_Id",
                table: "kits_dispositivos",
                column: "Dispositivo_Id");

            migrationBuilder.CreateIndex(
                name: "IX_kitDispositivo_Kit_Id",
                table: "kits_dispositivos",
                column: "Kit_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "datos");

            migrationBuilder.DropTable(
                name: "kits_dispositivos");

            migrationBuilder.DropTable(
                name: "dispositivos");

            migrationBuilder.DropTable(
                name: "kits");

            migrationBuilder.DropTable(
                name: "tipos");
        }
    }
}
