using Microsoft.EntityFrameworkCore.Migrations;

namespace Posto.Infrastructure.Migrations
{
    public partial class ClienteSemEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Endereco_Id_Endereco",
                table: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_Id_Endereco",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Id_Endereco",
                table: "Cliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_Endereco",
                table: "Cliente",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Id_Endereco",
                table: "Cliente",
                column: "Id_Endereco");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Endereco_Id_Endereco",
                table: "Cliente",
                column: "Id_Endereco",
                principalTable: "Endereco",
                principalColumn: "Id_Endereco",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
