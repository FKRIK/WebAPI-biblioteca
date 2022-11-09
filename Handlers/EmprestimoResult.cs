using WebAPI_biblioteca.Models;

namespace WebAPI_biblioteca.Handlers
{
    public class EmprestimoResult
    {
        private EmprestimoResult(bool success, string message)
        {
            this.Success = success;
            this.Message = message;
        }
        private EmprestimoResult(bool success, Emprestimo emprestimo)
        {
            this.Success = success;
            this.Emprestimo = emprestimo;
        }

        public bool Success { get; set; }
        public Emprestimo Emprestimo { get; set; }
        public string Message { get; set; }

        //possui dois estados (sucesso ou falha)
        // em caso de sucesso, é gerado o emprestimo, senão retorna mensagem de erro
        // foram criados duas factories para evitar que seja criado um new EmprestimResult sempre
        public static EmprestimoResult Ok(Emprestimo emprestimo)
        {
            return new EmprestimoResult(true, emprestimo);
        }

        public static EmprestimoResult Fail(string message)
        {
            return new EmprestimoResult(false, message);
        }
    }
}