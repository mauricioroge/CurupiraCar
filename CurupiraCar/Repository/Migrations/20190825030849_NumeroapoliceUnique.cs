using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class NumeroapoliceUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UK_ApoliceSeguro_NumeroApolice",
                table: "ApoliceSeguro");

            migrationBuilder.CreateIndex(
                name: "UK_ApoliceSeguro_NumeroApolice",
                table: "ApoliceSeguro",
                column: "NumeroApolice",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UK_ApoliceSeguro_NumeroApolice",
                table: "ApoliceSeguro");

            migrationBuilder.CreateIndex(
                name: "UK_ApoliceSeguro_NumeroApolice",
                table: "ApoliceSeguro",
                column: "NumeroApolice");
        }
    }
}
