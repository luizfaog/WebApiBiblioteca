using WebApiBiblioteca.Models;
using System.Threading.Tasks;

namespace WebApiBiblioteca.Services.Interface
{
    public interface ILivroService
    {
        List<LivroModel> ListarLivros();
        LivroModel ListarLivroPorId(int id);
        void CriarLivro(LivroModel livro);
        void AtualizarLivro(LivroModel livro);
        void ExcluirLivro(int id);
    }
}
