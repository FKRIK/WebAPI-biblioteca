using System;

namespace WebAPI_biblioteca
{
    public class Emprestimo
    {
        public int IdEmprestimo { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }

        // public List<Funcionario> Funcionarios { get; set; }

        // public List<Cliente> Clientes { get; set; }
    }
}