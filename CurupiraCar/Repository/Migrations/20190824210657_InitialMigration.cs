using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApoliceSeguro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    NumeroApolice = table.Column<double>(nullable: false),
                    IdentificacaoSegurado = table.Column<string>(nullable: false),
                    PlacaVeiculo = table.Column<string>(nullable: false),
                    ValorPremio = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApoliceSeguro_Id", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "UK_ApoliceSeguro_NumeroApolice",
                table: "ApoliceSeguro",
                column: "NumeroApolice");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApoliceSeguro");
        }
    }
}
