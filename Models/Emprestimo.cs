using System;
using System.Collections.Generic;

namespace WebAPI_biblioteca.Models
{
    public class Emprestimo
    {
        public Emprestimo() { }
        public Emprestimo(int id, DateTime emp, DateTime dev, int funcionario, int clienteId, int livroid, Cliente cliente, Livro livro)
        {
            this.Id = id;
            this.DataEmprestimo = emp;
            this.DataDevolucao = dev;
            this.FuncionarioId = funcionario;
            this.ClienteId = clienteId;
            this.LivroId = livroid;
            this.Finalizado = false;
            this.Cliente = cliente;
            this.Livro = livro;
        }

        public int Id { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }

        public int FuncionarioId { get; set; }

        public int ClienteId { get; set; }

        public int LivroId { get; set; }

        public Boolean Finalizado { get; set; }
        public Cliente Cliente { get; set; }
        public Funcionario Funcionario { get; set; }
        public Livro Livro { get; set; }
    }
}
