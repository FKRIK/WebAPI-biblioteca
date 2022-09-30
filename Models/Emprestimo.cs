using System;
using System.Collections.Generic;

namespace WebAPI_biblioteca.Models
{
    public class Emprestimo
    {

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