using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebAPI_biblioteca.Models;

namespace WebAPI_biblioteca.Handlers
{
    public class PendenciaClienteHandler : IHandler<EmprestimoRequest, EmprestimoResult>
    {
        public PendenciaClienteHandler(IHandler<EmprestimoRequest, EmprestimoResult> next, DataContext context)
        {
            this.Next = next;
            this._context = context;
        }

        private readonly DataContext _context;

        public IHandler<EmprestimoRequest, EmprestimoResult> Next { get; set; }

        public EmprestimoResult Handle(EmprestimoRequest request)
        {
            //verifica no banco de dados se o cliente ainda tem emprestimos pendentes, a partir da data de devolução
            var temPendencias = _context.Emprestimos.AsNoTracking()
            .Where((e) => e.ClienteId == request.Emprestimo.ClienteId)
            .Any((e) => e.DataDevolucao < System.DateTime.Now && !e.Finalizado);

            if (temPendencias == false)
                return Next.Handle(request);
            else
                return EmprestimoResult.Fail("O cliente tem empréstimos pendentes");
        }
    }
}