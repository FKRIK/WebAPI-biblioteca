using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebAPI_biblioteca.Models;

namespace WebAPI_biblioteca.Handlers
{
    //declara que os membros do handler utilizarão os tipos emprestimo request (trequest) e emprestimoesult (tresult)
    public class DisponibilidadeHandler : IHandler<EmprestimoRequest, EmprestimoResult>
    {
        public DisponibilidadeHandler(IHandler<EmprestimoRequest, EmprestimoResult> next, DataContext context)
        {
            this.Next = next;
            this._context = context;
        }

        private readonly DataContext _context;

        public IHandler<EmprestimoRequest, EmprestimoResult> Next { get; set; }

        public EmprestimoResult Handle(EmprestimoRequest request)
        {
            //verifica se o livro não está emprestado
            var book = _context.Livros.AsNoTracking().FirstOrDefault(a => a.Id == request.Emprestimo.LivroId);
            if (book.Disponivel)
                return Next.Handle(request);
            else
                return EmprestimoResult.Fail("O livro não está disponível");
        }
    }
}