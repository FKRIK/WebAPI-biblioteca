using System;
using System.Collections.Generic;

namespace WebAPI_biblioteca.Models
{
    public class Genero
    {
        public int Id { get; set; }
        public string GeneroLivro { get; set; }
        public List<Livro> Livros { get; set; }
    }
}