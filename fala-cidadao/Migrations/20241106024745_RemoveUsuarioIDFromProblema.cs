using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fala_cidadao.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUsuarioIDFromProblema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioID",
                table: "Problemas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioID",
                table: "Problemas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
