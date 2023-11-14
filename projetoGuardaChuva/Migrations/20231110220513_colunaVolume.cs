using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projetoGuardaChuva.Migrations
{
    public partial class colunaVolume : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "VolumeBacia",
                table: "Endereco",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VolumeBacia",
                table: "Endereco");
        }
    }
}
