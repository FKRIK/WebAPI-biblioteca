using System;

namespace WebAPI_biblioteca
{
    public class Livro
    {
        public int Idivro { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public DateTime Publicacao { get; set; }
        public int Paginas { get; set; }
        public string ISBN { get; set; }
        public string Editora { get; set; }
        public Generos Genero { get; set; }
    }
}