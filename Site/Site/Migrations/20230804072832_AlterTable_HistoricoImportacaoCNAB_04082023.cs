using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Site.Migrations
{
    /// <inheritdoc />
    public partial class AlterTable_HistoricoImportacaoCNAB_04082023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NomeArquivoCNABImportado",
                table: "HistoricoImportacaoCNABs",
                newName: "NomeArquivo");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "HistoricoImportacaoCNABs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "HistoricoImportacaoCNABs");

            migrationBuilder.RenameColumn(
                name: "NomeArquivo",
                table: "HistoricoImportacaoCNABs",
                newName: "NomeArquivoCNABImportado");
        }
    }
}
