using WebAPI_biblioteca.Models;

namespace WebAPI_biblioteca.Handlers
{
    public class EmprestimoRequest
    {
        public EmprestimoRequest(Emprestimo emprestimo)
        {
            this.Emprestimo = emprestimo;
        }

        public Emprestimo Emprestimo { get; set; }
    }
}