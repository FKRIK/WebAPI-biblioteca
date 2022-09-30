using System;

namespace WebAPI_biblioteca.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public DateTime Publicacao { get; set; }
        public int Paginas { get; set; }
        public string ISBN { get; set; }
        public string Editora { get; set; }
        public Boolean Disponivel { get; set; }
        public int GeneroId { get; set; }
        public Genero Generos { get; set; }
    }
}