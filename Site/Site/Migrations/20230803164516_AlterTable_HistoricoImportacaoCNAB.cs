using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Site.Migrations
{
    /// <inheritdoc />
    public partial class AlterTable_HistoricoImportacaoCNAB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CNABImportado",
                table: "HistoricoImportacaoCNABs",
                newName: "NomeArquivoCNABImportado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NomeArquivoCNABImportado",
                table: "HistoricoImportacaoCNABs",
                newName: "CNABImportado");
        }
    }
}
