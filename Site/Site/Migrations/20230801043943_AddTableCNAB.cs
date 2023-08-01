using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Site.Migrations
{
    /// <inheritdoc />
    public partial class AddTableCNAB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistoricoImportacaoCNABs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CNABImportado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RemovedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoImportacaoCNABs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoTransacao = table.Column<int>(type: "int", nullable: false),
                    DtOcorrencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    CpfBeneficiario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroCartao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoraTransacao = table.Column<TimeSpan>(type: "time", nullable: false),
                    DonoLoja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeLoja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RemovedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacoes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoImportacaoCNABs");

            migrationBuilder.DropTable(
                name: "Transacoes");
        }
    }
}
