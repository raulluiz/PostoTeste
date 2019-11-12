using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Posto.Infrastructure.Migrations
{
    public partial class cliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "EmpresaUsuario",
                newName: "Id_Usuario");

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id_Cliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id_Endereco = table.Column<int>(nullable: false),
                    Id_Usuario = table.Column<int>(nullable: false),
                    Cnpj = table.Column<long>(nullable: false),
                    Data_Preventiva_Mes = table.Column<DateTime>(nullable: false),
                    Razao_Social = table.Column<string>(nullable: true),
                    Prazo_Cliente = table.Column<DateTime>(nullable: false),
                    Programacao_Preventiva = table.Column<int>(nullable: false),
                    Id_Tecnico = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id_Cliente);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaUsuario_Id_Usuario",
                table: "EmpresaUsuario",
                column: "Id_Usuario");

            migrationBuilder.AddForeignKey(
                name: "FK_EmpresaUsuario_EMPRESAS_IdEmpresa",
                table: "EmpresaUsuario",
                column: "IdEmpresa",
                principalTable: "EMPRESAS",
                principalColumn: "ID_EMPRESA",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmpresaUsuario_Usuarios_Id_Usuario",
                table: "EmpresaUsuario",
                column: "Id_Usuario",
                principalTable: "Usuarios",
                principalColumn: "Id_Usuario",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpresaUsuario_EMPRESAS_IdEmpresa",
                table: "EmpresaUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_EmpresaUsuario_Usuarios_Id_Usuario",
                table: "EmpresaUsuario");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_EmpresaUsuario_Id_Usuario",
                table: "EmpresaUsuario");

            migrationBuilder.RenameColumn(
                name: "Id_Usuario",
                table: "EmpresaUsuario",
                newName: "IdUsuario");
        }
    }
}
