using System;

namespace WebAPI_biblioteca.Models
{
    public class Livro
    {
        public Livro() { }

        public Livro(int id, string titulo, string autor, string pub, int pag, string editora, int generoId, Genero generos)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Autor = autor;
            this.Publicacao = pub;
            this.Paginas = pag;
            this.Editora = editora;
            this.Disponivel = true;
            this.GeneroId = generoId;
            this.Generos = generos;
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Publicacao { get; set; }
        public int Paginas { get; set; }
        public string Editora { get; set; }
        public Boolean Disponivel { get; set; }
        public int GeneroId { get; set; }
        public Genero Generos { get; set; }
    }
}
