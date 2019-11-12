using Microsoft.EntityFrameworkCore.Migrations;

namespace Posto.Infrastructure.Migrations
{
    public partial class Programacao_PreventivaTecnico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Progamacao_Preventiva",
                table: "Tecnico",
                newName: "Programacao_Preventiva");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Programacao_Preventiva",
                table: "Tecnico",
                newName: "Progamacao_Preventiva");
        }
    }
}
