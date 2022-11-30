using System;
using System.Collections.Generic;

namespace WebAPI_biblioteca.Models
{
    public class Emprestimo
    {
        public Emprestimo(){ }
        public Emprestimo(int id, DateTime emp, DateTime dev, int funcionario, int cliente ,int livro)
        {
            this.Id = id;
            this.DataEmprestimo = emp;
            this.DataDevolucao = dev;
            this.FuncionarioId = funcionario;
            this.ClienteId = cliente;
            this.LivroId = livro;
            this.Finalizado = false;
        }

        public int Id { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }

        public int FuncionarioId { get; set; }

        public int ClienteId { get; set; }

        public int LivroId { get; set; }

        public Boolean Finalizado { get; set; }

        public Cliente Cliente;
        public Funcionario Funcionario;
        public Livro Livro;
    }
}
