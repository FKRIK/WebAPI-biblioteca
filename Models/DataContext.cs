using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_biblioteca.Models
{
    public class DataContext : DbContext
    {
        // Estabelece conexão com o banco de dados
        // A options passado como base faz a parte de herança de atributos para o filho

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        // Métodos que permitem que a classe se torne uma tabela no sqlite
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder){ }
    }
}