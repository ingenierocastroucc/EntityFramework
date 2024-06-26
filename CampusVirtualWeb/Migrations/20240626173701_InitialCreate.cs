using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampusVirtualWeb.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Asignatura",
                columns: table => new
                {
                    AsignaturaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreAsignatura = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nivelacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Horario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignatura", x => x.AsignaturaId);
                });

            migrationBuilder.CreateTable(
                name: "Matricula",
                columns: table => new
                {
                    MatriculaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AsignaturaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreAsignatura = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Profesor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TipoInscripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Semestreinscripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PrioridadMatricula = table.Column<int>(type: "int", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matricula", x => x.MatriculaId);
                    table.ForeignKey(
                        name: "FK_Matricula_Asignatura_AsignaturaId",
                        column: x => x.AsignaturaId,
                        principalTable: "Asignatura",
                        principalColumn: "AsignaturaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_AsignaturaId",
                table: "Matricula",
                column: "AsignaturaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matricula");

            migrationBuilder.DropTable(
                name: "Asignatura");
        }
    }
}
