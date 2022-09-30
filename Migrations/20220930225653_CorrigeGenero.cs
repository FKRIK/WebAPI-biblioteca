using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI_biblioteca.Migrations
{
    public partial class CorrigeGenero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Emprestimos_EmprestimoId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Emprestimos_EmprestimoId",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Generos_GenerosId",
                table: "Livros");

            migrationBuilder.DropIndex(
                name: "IX_Livros_GenerosId",
                table: "Livros");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_EmprestimoId",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_EmprestimoId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "GenerosId",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "EmprestimoId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "EmprestimoId",
                table: "Clientes");

            migrationBuilder.AddColumn<bool>(
                name: "Disponivel",
                table: "Livros",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "GeneroId",
                table: "Livros",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Emprestimos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Finalizado",
                table: "Emprestimos",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "FuncionarioId",
                table: "Emprestimos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LivroId",
                table: "Emprestimos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Livros_GeneroId",
                table: "Livros",
                column: "GeneroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Generos_GeneroId",
                table: "Livros",
                column: "GeneroId",
                principalTable: "Generos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Generos_GeneroId",
                table: "Livros");

            migrationBuilder.DropIndex(
                name: "IX_Livros_GeneroId",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "Disponivel",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "GeneroId",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Emprestimos");

            migrationBuilder.DropColumn(
                name: "Finalizado",
                table: "Emprestimos");

            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "Emprestimos");

            migrationBuilder.DropColumn(
                name: "LivroId",
                table: "Emprestimos");

            migrationBuilder.AddColumn<int>(
                name: "GenerosId",
                table: "Livros",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmprestimoId",
                table: "Funcionarios",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmprestimoId",
                table: "Clientes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Livros_GenerosId",
                table: "Livros",
                column: "GenerosId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_EmprestimoId",
                table: "Funcionarios",
                column: "EmprestimoId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_EmprestimoId",
                table: "Clientes",
                column: "EmprestimoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Emprestimos_EmprestimoId",
                table: "Clientes",
                column: "EmprestimoId",
                principalTable: "Emprestimos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Emprestimos_EmprestimoId",
                table: "Funcionarios",
                column: "EmprestimoId",
                principalTable: "Emprestimos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Generos_GenerosId",
                table: "Livros",
                column: "GenerosId",
                principalTable: "Generos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
