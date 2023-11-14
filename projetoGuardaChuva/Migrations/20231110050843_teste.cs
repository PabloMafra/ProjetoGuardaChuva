using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projetoGuardaChuva.Migrations
{
    public partial class teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Setor_IdSetor",
                table: "Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Endereco_IdSetor",
                table: "Endereco");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Endereco_IdSetor",
                table: "Endereco",
                column: "IdSetor");

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Setor_IdSetor",
                table: "Endereco",
                column: "IdSetor",
                principalTable: "Setor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
