using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoAtos.Repository.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbNoticia",
                columns: table => new
                {
                    NotCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotTitulo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    NotTexto = table.Column<string>(type: "text", nullable: false),
                    NotUltimaAtualizacao = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbNoticia", x => x.NotCodigo);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbNoticia");
        }
    }
}
