using Microsoft.EntityFrameworkCore.Migrations;

namespace Posto.Infrastructure.Migrations
{
    public partial class ChamadoProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChamadoProduto",
                columns: table => new
                {
                    Id_Chamado = table.Column<int>(nullable: false),
                    Id_Produto = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChamadoProduto", x => new { x.Id_Chamado, x.Id_Produto });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChamadoProduto");
        }
    }
}
