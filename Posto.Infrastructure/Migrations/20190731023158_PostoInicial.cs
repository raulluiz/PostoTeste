using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Posto.Infrastructure.Migrations
{
    public partial class PostoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EXEMPLOS",
                columns: table => new
                {
                    ID_EXEMPLO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NOME = table.Column<string>(maxLength: 200, nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_EXEMPLO", x => x.ID_EXEMPLO);
                });

            migrationBuilder.CreateTable(
                name: "EXEMPLOS_ITENS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NOME = table.Column<string>(maxLength: 200, nullable: true),
                    ExemploId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EXEMPLOS_ITENS_EXEMPLOS_ExemploId",
                        column: x => x.ExemploId,
                        principalTable: "EXEMPLOS",
                        principalColumn: "ID_EXEMPLO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EXEMPLOS_ITENS_ExemploId",
                table: "EXEMPLOS_ITENS",
                column: "ExemploId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EXEMPLOS_ITENS");

            migrationBuilder.DropTable(
                name: "EXEMPLOS");
        }
    }
}
