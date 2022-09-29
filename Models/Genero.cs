using System;
using System.Collections.Generic;

namespace WebAPI_biblioteca.Models
{
    public class Genero
    {
        public Genero(){ }
        public Genero(int id, string generolivro)
        {
            this.Id = id;
            this.GeneroLivro = generolivro;
        }
        public int Id { get; set; }
        public string GeneroLivro { get; set; }
        public List<Livro> Livros { get; set; }
    }
}