using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Posto.Infrastructure.Migrations
{
    public partial class ProjetoTeste : Migration
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
                    Id_Tecnico = table.Column<int>(nullable: true),
                    Id_Empresa = table.Column<int>(nullable: false),
                    Id_Serie = table.Column<int>(nullable: false),
                    Data_Inicial = table.Column<DateTime>(nullable: false),
                    Data_Prazo = table.Column<DateTime>(nullable: true),
                    Data_Final = table.Column<DateTime>(nullable: true),
                    Descricao_Problema_Cliente = table.Column<string>(nullable: true),
                    Defeito_Encontrado_Tecnico = table.Column<string>(nullable: true),
                    Nota_Tempo = table.Column<byte>(nullable: true),
                    Nota_Tecnico = table.Column<byte>(nullable: true),
                    Nota_Eficacia = table.Column<byte>(nullable: true),
                    Status = table.Column<byte>(nullable: true),
                    Nome_Cliente = table.Column<string>(nullable: true),
                    Nome_Tecnico = table.Column<string>(nullable: true),
                    Corretiva = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chamado", x => x.Id_Chamado);
                });

            migrationBuilder.CreateTable(
                name: "ChamadoImagem",
                columns: table => new
                {
                    Id_Imagem = table.Column<int>(nullable: false),
                    Id_Chamado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChamadoImagem", x => new { x.Id_Chamado, x.Id_Imagem });
                });

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

            migrationBuilder.CreateTable(
                name: "ClienteSerie",
                columns: table => new
                {
                    Id_Cliente = table.Column<int>(nullable: false),
                    Id_Serie = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteSerie", x => new { x.Id_Cliente, x.Id_Serie });
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    ID_EMPRESA = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    CNPJ = table.Column<long>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Razao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_EMPRESA", x => x.ID_EMPRESA);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id_Endereco = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Endereco_Complemento = table.Column<string>(nullable: true),
                    LinkGoogleMaps = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id_Endereco);
                });

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
                name: "Imagem",
                columns: table => new
                {
                    Id_Imagem = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id_Usuario = table.Column<int>(nullable: false),
                    ImagemByte = table.Column<byte[]>(nullable: true),
                    Tipo = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagem", x => x.Id_Imagem);
                });

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

            migrationBuilder.CreateTable(
                name: "SubConjunto",
                columns: table => new
                {
                    Id_SubConjunto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubConjunto", x => x.Id_SubConjunto);
                });

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

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id_Produto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdEmpresa = table.Column<int>(nullable: false),
                    Id_Serie = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => new { x.Id_Produto, x.IdEmpresa, x.Id_Serie });
                    table.ForeignKey(
                        name: "FK_Produto_Empresa_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "ID_EMPRESA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id_Usuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 200, nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    Cpf = table.Column<string>(maxLength: 30, nullable: true),
                    IdentityUser = table.Column<string>(nullable: true),
                    Perfil = table.Column<byte>(nullable: false),
                    Id_Endereco = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id_Usuario);
                    table.ForeignKey(
                        name: "FK_Usuario_Endereco_Id_Endereco",
                        column: x => x.Id_Endereco,
                        principalTable: "Endereco",
                        principalColumn: "Id_Endereco",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id_Cliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id_Usuario = table.Column<int>(nullable: false),
                    Cnpj = table.Column<long>(nullable: false),
                    Data_Preventiva_Mes = table.Column<DateTime>(nullable: false),
                    Razao_Social = table.Column<string>(nullable: true),
                    Prazo_Cliente = table.Column<DateTime>(nullable: false),
                    Programacao_Preventiva = table.Column<int>(nullable: false),
                    Id_Tecnico = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id_Cliente);
                    table.ForeignKey(
                        name: "FK_Cliente_Usuario_Id_Usuario",
                        column: x => x.Id_Usuario,
                        principalTable: "Usuario",
                        principalColumn: "Id_Usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Distribuidora",
                columns: table => new
                {
                    Id_Distribuidora = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id_Usuario = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Cpf = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distribuidora", x => x.Id_Distribuidora);
                    table.ForeignKey(
                        name: "FK_Distribuidora_Usuario_Id_Usuario",
                        column: x => x.Id_Usuario,
                        principalTable: "Usuario",
                        principalColumn: "Id_Usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpresaUsuario",
                columns: table => new
                {
                    Id_Usuario = table.Column<int>(nullable: false),
                    IdEmpresa = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaUsuario", x => new { x.IdEmpresa, x.Id_Usuario });
                    table.ForeignKey(
                        name: "FK_EmpresaUsuario_Empresa_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "ID_EMPRESA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpresaUsuario_Usuario_Id_Usuario",
                        column: x => x.Id_Usuario,
                        principalTable: "Usuario",
                        principalColumn: "Id_Usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tecnico",
                columns: table => new
                {
                    Id_Tecnico = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id_Usuario = table.Column<int>(nullable: false),
                    Id_Empresa = table.Column<int>(nullable: false),
                    Cpf = table.Column<long>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Programacao_Preventiva = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tecnico", x => x.Id_Tecnico);
                    table.ForeignKey(
                        name: "FK_Tecnico_Usuario_Id_Usuario",
                        column: x => x.Id_Usuario,
                        principalTable: "Usuario",
                        principalColumn: "Id_Usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Id_Usuario",
                table: "Cliente",
                column: "Id_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Distribuidora_Id_Usuario",
                table: "Distribuidora",
                column: "Id_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaUsuario_Id_Usuario",
                table: "EmpresaUsuario",
                column: "Id_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_IdEmpresa",
                table: "Equipamento",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_EXEMPLOS_ITENS_ExemploId",
                table: "EXEMPLOS_ITENS",
                column: "ExemploId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_IdEmpresa",
                table: "Produto",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Tecnico_Id_Usuario",
                table: "Tecnico",
                column: "Id_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Id_Endereco",
                table: "Usuario",
                column: "Id_Endereco");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chamado");

            migrationBuilder.DropTable(
                name: "ChamadoImagem");

            migrationBuilder.DropTable(
                name: "ChamadoProduto");

            migrationBuilder.DropTable(
                name: "ChamadoSubConjunto");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "ClienteSerie");

            migrationBuilder.DropTable(
                name: "Distribuidora");

            migrationBuilder.DropTable(
                name: "EmpresaUsuario");

            migrationBuilder.DropTable(
                name: "Equipamento");

            migrationBuilder.DropTable(
                name: "EXEMPLOS_ITENS");

            migrationBuilder.DropTable(
                name: "Imagem");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "SerieSubConjunto");

            migrationBuilder.DropTable(
                name: "SubConjunto");

            migrationBuilder.DropTable(
                name: "Tecnico");

            migrationBuilder.DropTable(
                name: "EXEMPLOS");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Endereco");
        }
    }
}
