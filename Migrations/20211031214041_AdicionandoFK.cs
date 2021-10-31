using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_Loja_Sapatos.Migrations
{
    public partial class AdicionandoFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Vendas_id_cliente",
                table: "Vendas",
                column: "id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_id_modelo",
                table: "Vendas",
                column: "id_modelo");

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_id_categoria",
                table: "Modelos",
                column: "id_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_id_fornecedor",
                table: "Modelos",
                column: "id_fornecedor");

            migrationBuilder.AddForeignKey(
                name: "FK_Modelos_Categorias_id_categoria",
                table: "Modelos",
                column: "id_categoria",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Modelos_Fornecedores_id_fornecedor",
                table: "Modelos",
                column: "id_fornecedor",
                principalTable: "Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Clientes_id_cliente",
                table: "Vendas",
                column: "id_cliente",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Modelos_id_modelo",
                table: "Vendas",
                column: "id_modelo",
                principalTable: "Modelos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modelos_Categorias_id_categoria",
                table: "Modelos");

            migrationBuilder.DropForeignKey(
                name: "FK_Modelos_Fornecedores_id_fornecedor",
                table: "Modelos");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Clientes_id_cliente",
                table: "Vendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Modelos_id_modelo",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_id_cliente",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_id_modelo",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Modelos_id_categoria",
                table: "Modelos");

            migrationBuilder.DropIndex(
                name: "IX_Modelos_id_fornecedor",
                table: "Modelos");
        }
    }
}
