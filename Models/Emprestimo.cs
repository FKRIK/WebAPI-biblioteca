using System;
using System.Collections.Generic;

namespace WebAPI_biblioteca.Models
{
    public class Emprestimo
    {
        public Emprestimo(){ }
        public Emprestimo(int id, DateTime emp, DateTime dev)
        {
            this.Id = id;
            this.DataEmprestimo = emp;
            this.DataDevolucao = dev;
        }
        public int Id { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }

        // public List<Funcionario> Funcionarios { get; set; }

        // public List<Cliente> Clientes { get; set; }
    }
}