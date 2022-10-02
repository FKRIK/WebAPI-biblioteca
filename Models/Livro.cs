using System;

namespace WebAPI_biblioteca.Models
{
    public class Livro
    {
        public Livro(){ }

        public Livro(int id, string titulo, string autor, DateTime pub, int pag, string isbn, string editora, int generoId)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Autor = autor;
            this.Publicacao = pub;
            this.Paginas = pag;
            this.ISBN = isbn;
            this.Editora = editora;
            this.Disponivel = true;
            this.GeneroId = generoId;
        }

        public Livro(int id, string titulo, string autor, int generoId)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Autor = autor;
            this.GeneroId = generoId;
        }
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