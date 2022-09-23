using System;
using System.Collections.Generic;

namespace WebAPI_biblioteca
{
    public class Emprestimos
    {
        public int IdEmprestimo { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }

        public List<Funcionarios> Funcionario { get; set; }

        public List<Clientes> Cliente { get; set; }
    }
}