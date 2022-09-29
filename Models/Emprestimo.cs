using System;
using System.Collections.Generic;

namespace WebAPI_biblioteca.Models
{
    public class Emprestimo
    {
        public int IdEmprestimo { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }

        public List<Funcionario> Funcionarios { get; set; }

        public List<Cliente> Clientes { get; set; }
    }
}