using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Posto.Infrastructure.Migrations
{
    public partial class SerieProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id_Produto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdEmpresa = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => new { x.Id_Produto, x.IdEmpresa });
                    table.ForeignKey(
                        name: "FK_Produtos_EMPRESAS_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "EMPRESAS",
                        principalColumn: "ID_EMPRESA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SerieProduto",
                columns: table => new
                {
                    Id_Serie = table.Column<int>(nullable: false),
                    Id_Produto = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerieProduto", x => new { x.Id_Serie, x.Id_Produto });
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id_Serie = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdEmpresa = table.Column<int>(nullable: false),
                    Modelo_Bomba = table.Column<string>(nullable: true),
                    Tipo = table.Column<byte>(nullable: false),
                    Numero_Serie = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => new { x.Id_Serie, x.IdEmpresa });
                    table.UniqueConstraint("AK_Series_Id_Serie", x => x.Id_Serie);
                    table.ForeignKey(
                        name: "FK_Series_EMPRESAS_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "EMPRESAS",
                        principalColumn: "ID_EMPRESA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_IdEmpresa",
                table: "Produtos",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Series_IdEmpresa",
                table: "Series",
                column: "IdEmpresa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "SerieProduto");

            migrationBuilder.DropTable(
                name: "Series");
        }
    }
}
