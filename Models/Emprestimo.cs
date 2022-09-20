using System;

namespace WebAPI_biblioteca
{
    public class Emprestimo
    {
        public int id {get;set;}
        public DateTime dataEmprestimo {get;set;}
        public DateTime dataDevolucao {get;set;}
        public int codigoCliente {get;set;}
        public int codigoFuncionario {get;set;}
    }
}