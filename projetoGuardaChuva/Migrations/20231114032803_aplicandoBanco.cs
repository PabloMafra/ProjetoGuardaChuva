using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projetoGuardaChuva.Migrations
{
    public partial class aplicandoBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.AddColumn<int>(
                name: "IdEndereco",
                table: "Estoque",
                type: "int",
                maxLength: 255,
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdEndereco",
                table: "Estoque");

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cargo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                });
        }
    }
}
