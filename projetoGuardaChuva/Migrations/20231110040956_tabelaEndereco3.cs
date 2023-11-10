using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projetoGuardaChuva.Migrations
{
    public partial class tabelaEndereco3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cep = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    Rua = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Numero = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IdSetor = table.Column<int>(type: "int", nullable: false),
                    Coordenadas = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Altura = table.Column<double>(type: "float", nullable: false),
                    Base = table.Column<double>(type: "float", nullable: false),
                    AnguloInclinacao = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endereco_Setor_IdSetor",
                        column: x => x.IdSetor,
                        principalTable: "Setor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_IdSetor",
                table: "Endereco",
                column: "IdSetor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Endereco");
        }
    }
}
