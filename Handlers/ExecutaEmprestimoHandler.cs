using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebAPI_biblioteca.Models;

namespace WebAPI_biblioteca.Handlers
{
    public class ExecutaEmprestimoHandler : IHandler<EmprestimoRequest, EmprestimoResult>
    {
        public ExecutaEmprestimoHandler(IHandler<EmprestimoRequest, EmprestimoResult> next, DataContext context)
        {
            this.Next = next;
            this._context = context;
        }

        private readonly DataContext _context;

        public IHandler<EmprestimoRequest, EmprestimoResult> Next { get; set; }


        public EmprestimoResult Handle(EmprestimoRequest request)
        {
            try
            {
                //cria um novo empréstimo no banco de dados
                //muda o status do livro no banco de dados
                var book = _context.Livros.AsNoTracking().FirstOrDefault(a => a.Id == request.Emprestimo.LivroId);
                book.Disponivel = false;

                _context.Add(request.Emprestimo);
                _context.Update(book);
                _context.SaveChanges();

                //retorna o emprestimo criado
                if (Next != null)
                    return Next.Handle(request);
                else
                    return EmprestimoResult.Ok(new Models.Emprestimo());
            }
            catch (System.Exception ex)
            {
                return EmprestimoResult.Fail($"Falha ao criar empréstimo.\nEx: {ex.Message}");
            }
        }
    }
}