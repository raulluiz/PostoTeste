using Microsoft.EntityFrameworkCore.Migrations;

namespace Posto.Infrastructure.Migrations
{
    public partial class ChamadoSubConjunto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChamadoSubConjunto",
                columns: table => new
                {
                    Id_Chamado = table.Column<int>(nullable: false),
                    Id_SubConjunto = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChamadoSubConjunto", x => new { x.Id_Chamado, x.Id_SubConjunto });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChamadoSubConjunto");
        }
    }
}
