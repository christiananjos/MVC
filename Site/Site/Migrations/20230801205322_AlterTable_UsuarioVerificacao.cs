using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Site.Migrations
{
    /// <inheritdoc />
    public partial class AlterTable_UsuarioVerificacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UsuarioVerificacoes_UsuarioId",
                table: "UsuarioVerificacoes",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioVerificacoes_Usuarios_UsuarioId",
                table: "UsuarioVerificacoes",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioVerificacoes_Usuarios_UsuarioId",
                table: "UsuarioVerificacoes");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioVerificacoes_UsuarioId",
                table: "UsuarioVerificacoes");
        }
    }
}
