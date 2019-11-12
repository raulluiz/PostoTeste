using Microsoft.EntityFrameworkCore.Migrations;

namespace Posto.Infrastructure.Migrations
{
    public partial class tecnicoupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tecnico_Endereco_Id_Endereco",
                table: "Tecnico");

            migrationBuilder.DropIndex(
                name: "IX_Tecnico_Id_Endereco",
                table: "Tecnico");

            migrationBuilder.DropColumn(
                name: "Id_Endereco",
                table: "Tecnico");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_Endereco",
                table: "Tecnico",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tecnico_Id_Endereco",
                table: "Tecnico",
                column: "Id_Endereco");

            migrationBuilder.AddForeignKey(
                name: "FK_Tecnico_Endereco_Id_Endereco",
                table: "Tecnico",
                column: "Id_Endereco",
                principalTable: "Endereco",
                principalColumn: "Id_Endereco",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
