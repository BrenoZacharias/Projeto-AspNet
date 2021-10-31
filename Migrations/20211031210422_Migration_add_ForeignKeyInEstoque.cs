using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_Loja_Sapatos.Migrations
{
    public partial class Migration_add_ForeignKeyInEstoque : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Estoques_Id_Modelo",
                table: "Estoques",
                column: "Id_Modelo");

            migrationBuilder.AddForeignKey(
                name: "FK_Estoques_Modelos_Id_Modelo",
                table: "Estoques",
                column: "Id_Modelo",
                principalTable: "Modelos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estoques_Modelos_Id_Modelo",
                table: "Estoques");

            migrationBuilder.DropIndex(
                name: "IX_Estoques_Id_Modelo",
                table: "Estoques");
        }
    }
}
