using Microsoft.EntityFrameworkCore.Migrations;

namespace Posto.Infrastructure.Migrations
{
    public partial class TrocaDeNomeTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Usuarios_Id_Usuario",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_EmpresaUsuario_EMPRESAS_IdEmpresa",
                table: "EmpresaUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_EmpresaUsuario_Usuarios_Id_Usuario",
                table: "EmpresaUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_EMPRESAS_IdEmpresa",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Series_EMPRESAS_IdEmpresa",
                table: "Series");

            migrationBuilder.DropForeignKey(
                name: "FK_Tecnico_Usuarios_Id_Usuario",
                table: "Tecnico");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Endereco_Id_Endereco",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubConjuntos",
                table: "SubConjuntos");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Series_Id_Serie",
                table: "Series");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Series",
                table: "Series");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Imagens",
                table: "Imagens");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "Usuario");

            migrationBuilder.RenameTable(
                name: "SubConjuntos",
                newName: "SubConjunto");

            migrationBuilder.RenameTable(
                name: "Series",
                newName: "Serie");

            migrationBuilder.RenameTable(
                name: "Produtos",
                newName: "Produto");

            migrationBuilder.RenameTable(
                name: "Imagens",
                newName: "Imagem");

            migrationBuilder.RenameTable(
                name: "EMPRESAS",
                newName: "Empresa");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_Id_Endereco",
                table: "Usuario",
                newName: "IX_Usuario_Id_Endereco");

            migrationBuilder.RenameIndex(
                name: "IX_Series_IdEmpresa",
                table: "Serie",
                newName: "IX_Serie_IdEmpresa");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_IdEmpresa",
                table: "Produto",
                newName: "IX_Produto_IdEmpresa");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id_Usuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubConjunto",
                table: "SubConjunto",
                column: "Id_SubConjunto");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Serie_Id_Serie",
                table: "Serie",
                column: "Id_Serie");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Serie",
                table: "Serie",
                columns: new[] { "Id_Serie", "IdEmpresa" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produto",
                table: "Produto",
                columns: new[] { "Id_Produto", "IdEmpresa", "Id_Serie" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Imagem",
                table: "Imagem",
                column: "Id_Imagem");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Usuario_Id_Usuario",
                table: "Cliente",
                column: "Id_Usuario",
                principalTable: "Usuario",
                principalColumn: "Id_Usuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmpresaUsuario_Empresa_IdEmpresa",
                table: "EmpresaUsuario",
                column: "IdEmpresa",
                principalTable: "Empresa",
                principalColumn: "ID_EMPRESA",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmpresaUsuario_Usuario_Id_Usuario",
                table: "EmpresaUsuario",
                column: "Id_Usuario",
                principalTable: "Usuario",
                principalColumn: "Id_Usuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Empresa_IdEmpresa",
                table: "Produto",
                column: "IdEmpresa",
                principalTable: "Empresa",
                principalColumn: "ID_EMPRESA",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Serie_Empresa_IdEmpresa",
                table: "Serie",
                column: "IdEmpresa",
                principalTable: "Empresa",
                principalColumn: "ID_EMPRESA",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tecnico_Usuario_Id_Usuario",
                table: "Tecnico",
                column: "Id_Usuario",
                principalTable: "Usuario",
                principalColumn: "Id_Usuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Endereco_Id_Endereco",
                table: "Usuario",
                column: "Id_Endereco",
                principalTable: "Endereco",
                principalColumn: "Id_Endereco",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Usuario_Id_Usuario",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_EmpresaUsuario_Empresa_IdEmpresa",
                table: "EmpresaUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_EmpresaUsuario_Usuario_Id_Usuario",
                table: "EmpresaUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Empresa_IdEmpresa",
                table: "Produto");

            migrationBuilder.DropForeignKey(
                name: "FK_Serie_Empresa_IdEmpresa",
                table: "Serie");

            migrationBuilder.DropForeignKey(
                name: "FK_Tecnico_Usuario_Id_Usuario",
                table: "Tecnico");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Endereco_Id_Endereco",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubConjunto",
                table: "SubConjunto");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Serie_Id_Serie",
                table: "Serie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Serie",
                table: "Serie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produto",
                table: "Produto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Imagem",
                table: "Imagem");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "Usuarios");

            migrationBuilder.RenameTable(
                name: "SubConjunto",
                newName: "SubConjuntos");

            migrationBuilder.RenameTable(
                name: "Serie",
                newName: "Series");

            migrationBuilder.RenameTable(
                name: "Produto",
                newName: "Produtos");

            migrationBuilder.RenameTable(
                name: "Imagem",
                newName: "Imagens");

            migrationBuilder.RenameTable(
                name: "Empresa",
                newName: "EMPRESAS");

            migrationBuilder.RenameIndex(
                name: "IX_Usuario_Id_Endereco",
                table: "Usuarios",
                newName: "IX_Usuarios_Id_Endereco");

            migrationBuilder.RenameIndex(
                name: "IX_Serie_IdEmpresa",
                table: "Series",
                newName: "IX_Series_IdEmpresa");

            migrationBuilder.RenameIndex(
                name: "IX_Produto_IdEmpresa",
                table: "Produtos",
                newName: "IX_Produtos_IdEmpresa");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id_Usuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubConjuntos",
                table: "SubConjuntos",
                column: "Id_SubConjunto");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Series_Id_Serie",
                table: "Series",
                column: "Id_Serie");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Series",
                table: "Series",
                columns: new[] { "Id_Serie", "IdEmpresa" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos",
                columns: new[] { "Id_Produto", "IdEmpresa", "Id_Serie" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Imagens",
                table: "Imagens",
                column: "Id_Imagem");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Usuarios_Id_Usuario",
                table: "Cliente",
                column: "Id_Usuario",
                principalTable: "Usuarios",
                principalColumn: "Id_Usuario",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_EMPRESAS_IdEmpresa",
                table: "Produtos",
                column: "IdEmpresa",
                principalTable: "EMPRESAS",
                principalColumn: "ID_EMPRESA",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Series_EMPRESAS_IdEmpresa",
                table: "Series",
                column: "IdEmpresa",
                principalTable: "EMPRESAS",
                principalColumn: "ID_EMPRESA",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tecnico_Usuarios_Id_Usuario",
                table: "Tecnico",
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
    }
}
