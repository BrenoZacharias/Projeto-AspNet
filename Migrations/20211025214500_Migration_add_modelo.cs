using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_Loja_Sapatos.Migrations
{
    public partial class Migration_add_modelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Modelos",
                columns: new[] { "id", "codigoRef", "cor", "id_fornecedor", "nome", "tamanho" },
                values: new object[] { 1, "batatinha123", "Amarelo", 1, "Round6", 42 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Modelos",
                keyColumn: "id",
                keyValue: 1);
        }
    }
}
