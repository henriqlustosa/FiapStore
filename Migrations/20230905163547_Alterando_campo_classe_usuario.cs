using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiapStoreBackup.Migrations
{
    /// <inheritdoc />
    public partial class Alterandocampoclasseusuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Usuarios",
                newName: "Senha");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "Usuarios",
                newName: "Password");
        }
    }
}
