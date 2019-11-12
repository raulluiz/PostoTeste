using Microsoft.EntityFrameworkCore.Migrations;

namespace Posto.Infrastructure.Migrations
{
    public partial class nomesChamado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome_Cliente",
                table: "Chamado",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome_Tecnico",
                table: "Chamado",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome_Cliente",
                table: "Chamado");

            migrationBuilder.DropColumn(
                name: "Nome_Tecnico",
                table: "Chamado");
        }
    }
}
