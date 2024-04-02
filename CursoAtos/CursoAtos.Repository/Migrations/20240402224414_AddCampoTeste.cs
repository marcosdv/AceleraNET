using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoAtos.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddCampoTeste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NotTeste",
                table: "TbNoticia",
                type: "varchar",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotTeste",
                table: "TbNoticia");
        }
    }
}
