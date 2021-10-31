using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_Loja_Sapatos.Migrations
{
    public partial class Migration_add_fullTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Fornecedores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Fornecedores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Modelos",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "nome",
                table: "Modelos");

            migrationBuilder.AlterColumn<string>(
                name: "cor",
                table: "Modelos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "codigoRef",
                table: "Modelos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "id_categoria",
                table: "Modelos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "valor",
                table: "Modelos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estoques",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Modelo = table.Column<int>(type: "int", nullable: false),
                    Qtd = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoques", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Estoques");

            migrationBuilder.DropColumn(
                name: "id_categoria",
                table: "Modelos");

            migrationBuilder.DropColumn(
                name: "valor",
                table: "Modelos");

            migrationBuilder.AlterColumn<string>(
                name: "cor",
                table: "Modelos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "codigoRef",
                table: "Modelos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "nome",
                table: "Modelos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Fornecedores",
                columns: new[] { "Id", "CNPJ", "Endereco", "Nome" },
                values: new object[] { 1, "00000000000100", "Rua da Tia Cotinha, 230", "Netflix" });

            migrationBuilder.InsertData(
                table: "Fornecedores",
                columns: new[] { "Id", "CNPJ", "Endereco", "Nome" },
                values: new object[] { 2, "11111111000111", "Rua da Tio Manuel, 222", "Amazon Prime Video" });

            migrationBuilder.InsertData(
                table: "Modelos",
                columns: new[] { "id", "codigoRef", "cor", "id_fornecedor", "nome", "tamanho" },
                values: new object[] { 1, "batatinha123", "Amarelo", 1, "Round6", 42 });
        }
    }
}
