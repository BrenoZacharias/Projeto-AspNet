using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_Loja_Sapatos.Migrations
{
    public partial class Migration_Add_ForeignKeyNoEstoquePeloAppDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estoques_Modelos_Id_Modelo",
                table: "Estoques");

            migrationBuilder.DropIndex(
                name: "IX_Estoques_Id_Modelo",
                table: "Estoques");

            migrationBuilder.AddColumn<int>(
                name: "Modeloid",
                table: "Estoques",
                type: "int",
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Categorias_Nome",
                table: "Categorias",
                column: "Nome");

            migrationBuilder.CreateIndex(
                name: "IX_Estoques_Modeloid",
                table: "Estoques",
                column: "Modeloid");

            migrationBuilder.AddForeignKey(
                name: "FK_Estoques_Modelos_Modeloid",
                table: "Estoques",
                column: "Modeloid",
                principalTable: "Modelos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estoques_Modelos_Modeloid",
                table: "Estoques");

            migrationBuilder.DropIndex(
                name: "IX_Estoques_Modeloid",
                table: "Estoques");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Categorias_Nome",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "Modeloid",
                table: "Estoques");

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
    }
}
