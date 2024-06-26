using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampusVirtualWeb.Migrations
{
    public partial class ColumnProfesorAsignatura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfesorAsignatura",
                table: "Asignatura",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfesorAsignatura",
                table: "Asignatura");
        }
    }
}
