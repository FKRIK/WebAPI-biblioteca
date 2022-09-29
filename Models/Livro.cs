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
                this.GeneroId = generoId;
        }
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public DateTime Publicacao { get; set; }
        public int Paginas { get; set; }
        public string ISBN { get; set; }
        public string Editora { get; set; }
        // Cria referência para a classe genero
        // GeneroId = o EF entende que está sendo referenciado a chave primária da classe Genero
        public int GeneroId { get; set;}
        // Propriedade Genero é do tipo da classe Genero
        public Genero Genero { get; set; }
    }
}