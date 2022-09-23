using System;
using System.Collections.Generic;

namespace WebAPI_biblioteca
{
    public class Generos
    {
        public int IdGenero { get; set; }
        public string Genero { get; set; }

        public List<Livros> Livro { get; set; }

    }
}