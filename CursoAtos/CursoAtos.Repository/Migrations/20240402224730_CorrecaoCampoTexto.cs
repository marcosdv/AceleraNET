using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoAtos.Repository.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoCampoTexto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotTeste",
                table: "TbNoticia");

            migrationBuilder.AlterColumn<string>(
                name: "NotTexto",
                table: "TbNoticia",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NotTexto",
                table: "TbNoticia",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NotTeste",
                table: "TbNoticia",
                type: "varchar",
                nullable: true);
        }
    }
}
