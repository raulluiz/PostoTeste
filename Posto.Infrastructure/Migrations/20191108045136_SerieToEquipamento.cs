using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Posto.Infrastructure.Migrations
{
    public partial class SerieToEquipamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Serie");

            migrationBuilder.CreateTable(
                name: "Equipamento",
                columns: table => new
                {
                    Id_Equipamento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdEmpresa = table.Column<int>(nullable: false),
                    Modelo_Bomba = table.Column<string>(nullable: true),
                    Tipo = table.Column<byte>(nullable: false),
                    Numero_Serie = table.Column<string>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamento", x => new { x.Id_Equipamento, x.IdEmpresa });
                    table.UniqueConstraint("AK_Equipamento_Id_Equipamento", x => x.Id_Equipamento);
                    table.ForeignKey(
                        name: "FK_Equipamento_Empresa_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "ID_EMPRESA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_IdEmpresa",
                table: "Equipamento",
                column: "IdEmpresa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipamento");

            migrationBuilder.CreateTable(
                name: "Serie",
                columns: table => new
                {
                    Id_Serie = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdEmpresa = table.Column<int>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Modelo_Bomba = table.Column<string>(nullable: true),
                    Numero_Serie = table.Column<string>(nullable: true),
                    Tipo = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serie", x => new { x.Id_Serie, x.IdEmpresa });
                    table.UniqueConstraint("AK_Serie_Id_Serie", x => x.Id_Serie);
                    table.ForeignKey(
                        name: "FK_Serie_Empresa_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "ID_EMPRESA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Serie_IdEmpresa",
                table: "Serie",
                column: "IdEmpresa");
        }
    }
}
