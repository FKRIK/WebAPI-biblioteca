using System;

namespace WebAPI_biblioteca.Models
{
    public class Funcionario
    {
        public Funcionario(){ }
        public Funcionario(int id, string nome, string cpf)
        {
            this.Id = id;
            this.Nome = nome;
            this.Cpf = cpf;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
    }
}