using Microsoft.EntityFrameworkCore.Migrations;

namespace Posto.Infrastructure.Migrations
{
    public partial class ChamadoImagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChamadoImagem",
                columns: table => new
                {
                    Id_Imagem = table.Column<int>(nullable: false),
                    Id_Chamado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChamadoImagem", x => new { x.Id_Chamado, x.Id_Imagem });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChamadoImagem");
        }
    }
}
