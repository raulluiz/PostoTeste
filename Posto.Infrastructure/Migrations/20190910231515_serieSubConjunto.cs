using Microsoft.EntityFrameworkCore.Migrations;

namespace Posto.Infrastructure.Migrations
{
    public partial class serieSubConjunto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SubConjunto",
                table: "SubConjunto");

            migrationBuilder.RenameTable(
                name: "SubConjunto",
                newName: "SubConjuntos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubConjuntos",
                table: "SubConjuntos",
                column: "Id_SubConjunto");

            migrationBuilder.CreateTable(
                name: "SerieSubConjunto",
                columns: table => new
                {
                    Id_SubConjunto = table.Column<int>(nullable: false),
                    Id_Serie = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerieSubConjunto", x => new { x.Id_SubConjunto, x.Id_Serie });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SerieSubConjunto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubConjuntos",
                table: "SubConjuntos");

            migrationBuilder.RenameTable(
                name: "SubConjuntos",
                newName: "SubConjunto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubConjunto",
                table: "SubConjunto",
                column: "Id_SubConjunto");
        }
    }
}
