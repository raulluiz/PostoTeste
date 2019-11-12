using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Posto.Infrastructure.Migrations
{
    public partial class ChamadoImagemNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Status",
                table: "Chamado",
                nullable: true,
                oldClrType: typeof(byte));

            migrationBuilder.AlterColumn<byte>(
                name: "Nota_Tempo",
                table: "Chamado",
                nullable: true,
                oldClrType: typeof(byte));

            migrationBuilder.AlterColumn<byte>(
                name: "Nota_Tecnico",
                table: "Chamado",
                nullable: true,
                oldClrType: typeof(byte));

            migrationBuilder.AlterColumn<byte>(
                name: "Nota_Eficacia",
                table: "Chamado",
                nullable: true,
                oldClrType: typeof(byte));

            migrationBuilder.AlterColumn<int>(
                name: "Id_Tecnico",
                table: "Chamado",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Data_Prazo",
                table: "Chamado",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Data_Final",
                table: "Chamado",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Status",
                table: "Chamado",
                nullable: false,
                oldClrType: typeof(byte),
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "Nota_Tempo",
                table: "Chamado",
                nullable: false,
                oldClrType: typeof(byte),
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "Nota_Tecnico",
                table: "Chamado",
                nullable: false,
                oldClrType: typeof(byte),
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "Nota_Eficacia",
                table: "Chamado",
                nullable: false,
                oldClrType: typeof(byte),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id_Tecnico",
                table: "Chamado",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Data_Prazo",
                table: "Chamado",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Data_Final",
                table: "Chamado",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
