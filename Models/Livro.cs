using System;

namespace WebAPI_biblioteca
{
    public class Livro
    {
        public int id {get;set;}
        public string titulo {get;set;}
        public string autor {get;set;}
        public DateTime publicacao {get;set;}
        public int paginas {get;set;}
        public string ISBN {get;set;}
        public string editora {get;set;}
        public string genero {get;set;}        
    }
}