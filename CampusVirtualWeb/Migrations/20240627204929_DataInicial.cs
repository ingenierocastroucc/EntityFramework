using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampusVirtualWeb.Migrations
{
    public partial class DataInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nivelacion",
                table: "Asignatura",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistro",
                table: "Asignatura",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Asignatura",
                columns: new[] { "AsignaturaId", "FechaRegistro", "Horario", "Nivelacion", "NombreAsignatura", "ProfesorAsignatura" },
                values: new object[] { new Guid("d97c9709-1b2e-4084-aee3-17094f61bf02"), new DateTime(2024, 6, 27, 15, 49, 28, 950, DateTimeKind.Local).AddTicks(2895), 2, "No", "Ingles", "Luisa Fernandez" });

            migrationBuilder.InsertData(
                table: "Asignatura",
                columns: new[] { "AsignaturaId", "FechaRegistro", "Horario", "Nivelacion", "NombreAsignatura", "ProfesorAsignatura" },
                values: new object[] { new Guid("d97c9709-1b2e-4084-aee3-17094f61bf74"), new DateTime(2024, 6, 27, 15, 49, 28, 950, DateTimeKind.Local).AddTicks(2847), 4, "No", "Calculo", "Pedro Diaz" });

            migrationBuilder.InsertData(
                table: "Matricula",
                columns: new[] { "MatriculaId", "AsignaturaId", "FechaRegistro", "NombreAsignatura", "PrioridadMatricula", "Profesor", "Semestreinscripcion", "TipoInscripcion" },
                values: new object[] { new Guid("d97c9709-1b2e-4084-aee3-17094f61bf03"), new Guid("d97c9709-1b2e-4084-aee3-17094f61bf74"), new DateTime(2024, 6, 27, 15, 49, 28, 951, DateTimeKind.Local).AddTicks(5448), "Calculo", 1, "Pedro Diaz", "Primero", "Virtual" });

            migrationBuilder.InsertData(
                table: "Matricula",
                columns: new[] { "MatriculaId", "AsignaturaId", "FechaRegistro", "NombreAsignatura", "PrioridadMatricula", "Profesor", "Semestreinscripcion", "TipoInscripcion" },
                values: new object[] { new Guid("d97c9709-1b2e-4084-aee3-17094f61bf04"), new Guid("d97c9709-1b2e-4084-aee3-17094f61bf02"), new DateTime(2024, 6, 27, 15, 49, 28, 951, DateTimeKind.Local).AddTicks(5480), "Ingles", 1, "Luisa Fernandez", "Primero", "Virtual" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Matricula",
                keyColumn: "MatriculaId",
                keyValue: new Guid("d97c9709-1b2e-4084-aee3-17094f61bf03"));

            migrationBuilder.DeleteData(
                table: "Matricula",
                keyColumn: "MatriculaId",
                keyValue: new Guid("d97c9709-1b2e-4084-aee3-17094f61bf04"));

            migrationBuilder.DeleteData(
                table: "Asignatura",
                keyColumn: "AsignaturaId",
                keyValue: new Guid("d97c9709-1b2e-4084-aee3-17094f61bf02"));

            migrationBuilder.DeleteData(
                table: "Asignatura",
                keyColumn: "AsignaturaId",
                keyValue: new Guid("d97c9709-1b2e-4084-aee3-17094f61bf74"));

            migrationBuilder.DropColumn(
                name: "FechaRegistro",
                table: "Asignatura");

            migrationBuilder.AlterColumn<string>(
                name: "Nivelacion",
                table: "Asignatura",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
