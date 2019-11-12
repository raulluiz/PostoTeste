using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Posto.Infrastructure.Migrations
{
    public partial class Chamado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chamado",
                columns: table => new
                {
                    Id_Chamado = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id_Cliente = table.Column<int>(nullable: false),
                    Id_Tecnico = table.Column<int>(nullable: false),
                    Id_Empresa = table.Column<int>(nullable: false),
                    Data_Inicial = table.Column<DateTime>(nullable: false),
                    Data_Prazo = table.Column<DateTime>(nullable: false),
                    Data_Final = table.Column<DateTime>(nullable: false),
                    Descricao_Problema_Cliente = table.Column<string>(nullable: true),
                    Defeito_Encontrado_Tecnico = table.Column<string>(nullable: true),
                    Nota_Tempo = table.Column<byte>(nullable: false),
                    Nota_Tecnico = table.Column<byte>(nullable: false),
                    Nota_Eficacia = table.Column<byte>(nullable: false),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chamado", x => x.Id_Chamado);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chamado");
        }
    }
}
