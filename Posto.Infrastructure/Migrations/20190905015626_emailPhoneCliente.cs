using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Posto.Infrastructure.Migrations
{
    public partial class emailPhoneCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id_Usuario",
                table: "Endereco");

            migrationBuilder.AddColumn<int>(
                name: "Id_Endereco",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Cliente",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Cliente",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tecnico",
                columns: table => new
                {
                    Id_Tecnico = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id_Endereco = table.Column<int>(nullable: false),
                    Id_Usuario = table.Column<int>(nullable: false),
                    Cpf = table.Column<long>(nullable: false),
                    Nome = table.Column<string>(maxLength: 200, nullable: true),
                    Progamacao_Preventiva = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tecnico", x => x.Id_Tecnico);
                    table.ForeignKey(
                        name: "FK_Tecnico_Endereco_Id_Endereco",
                        column: x => x.Id_Endereco,
                        principalTable: "Endereco",
                        principalColumn: "Id_Endereco",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tecnico_Usuarios_Id_Usuario",
                        column: x => x.Id_Usuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id_Usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Id_Endereco",
                table: "Usuarios",
                column: "Id_Endereco");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Id_Endereco",
                table: "Cliente",
                column: "Id_Endereco");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Id_Usuario",
                table: "Cliente",
                column: "Id_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Tecnico_Id_Endereco",
                table: "Tecnico",
                column: "Id_Endereco");

            migrationBuilder.CreateIndex(
                name: "IX_Tecnico_Id_Usuario",
                table: "Tecnico",
                column: "Id_Usuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Endereco_Id_Endereco",
                table: "Cliente",
                column: "Id_Endereco",
                principalTable: "Endereco",
                principalColumn: "Id_Endereco",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Usuarios_Id_Usuario",
                table: "Cliente",
                column: "Id_Usuario",
                principalTable: "Usuarios",
                principalColumn: "Id_Usuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Endereco_Id_Endereco",
                table: "Usuarios",
                column: "Id_Endereco",
                principalTable: "Endereco",
                principalColumn: "Id_Endereco",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Endereco_Id_Endereco",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Usuarios_Id_Usuario",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Endereco_Id_Endereco",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Tecnico");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_Id_Endereco",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_Id_Endereco",
                table: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_Id_Usuario",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Id_Endereco",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Cliente");

            migrationBuilder.AddColumn<int>(
                name: "Id_Usuario",
                table: "Endereco",
                nullable: false,
                defaultValue: 0);
        }
    }
}
