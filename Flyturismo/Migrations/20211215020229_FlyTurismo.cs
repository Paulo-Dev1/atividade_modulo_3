using Microsoft.EntityFrameworkCore.Migrations;

namespace Flyturismo.Migrations
{
    public partial class FlyTurismo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Destinos",
                columns: table => new
                {
                    Id_Destino = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinos", x => x.Id_Destino);
                });

            migrationBuilder.CreateTable(
                name: "Hospedagens",
                columns: table => new
                {
                    Id_Hospedagem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo_Hospedagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data_Entrada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data_Saida = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospedagens", x => x.Id_Hospedagem);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id_Cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    CPF = table.Column<int>(type: "int", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestinoId_destino = table.Column<int>(type: "int", nullable: false),
                    HospedagemId_hospedagem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id_Cliente);
                    table.ForeignKey(
                        name: "FK_Clientes_Destinos_DestinoId_destino",
                        column: x => x.DestinoId_destino,
                        principalTable: "Destinos",
                        principalColumn: "Id_Destino",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clientes_Hospedagens_HospedagemId_hospedagem",
                        column: x => x.HospedagemId_hospedagem,
                        principalTable: "Hospedagens",
                        principalColumn: "Id_Hospedagem",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_DestinoId_destino",
                table: "Clientes",
                column: "DestinoId_destino");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_HospedagemId_hospedagem",
                table: "Clientes",
                column: "HospedagemId_hospedagem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Destinos");

            migrationBuilder.DropTable(
                name: "Hospedagens");
        }
    }
}
