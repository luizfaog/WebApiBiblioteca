using System;
using System.Collections.Generic;
using System.Linq;
using WebApiBiblioteca.Models;
using WebApiBiblioteca.Services.Interface;
using System.Threading.Tasks;

namespace WebApiBiblioteca.Services.Implementation
{
    public class LivroService : ILivroService
    {
        #region Construtor
        public LivroService()
        {
            
        }
        #endregion

        #region ListaDeLivros
        private List<LivroModel> livros = new List<LivroModel>
    {
        new LivroModel { Id = 1, Titulo = "Frankenstein", Autor = "Mary Shelley", AnoPublicacao = "1818" },
        new LivroModel { Id = 2, Titulo = "Kindred laços de sangue", Autor = "Octavia Butler", AnoPublicacao = "1979" },
        new LivroModel { Id = 3, Titulo = "Farenheit 451", Autor = "Ray Bradbury", AnoPublicacao = "1953" },
        new LivroModel { Id = 4, Titulo = "Admirável mundo novo", Autor = "Aldous Huxley", AnoPublicacao = "1932" }
    };
        #endregion

        #region Get
        // Listar todos os livros
        public List<LivroModel> ListarLivros()
        {
            return livros.ToList();
        }

        // Obter detalhes de um livro por ID
        public LivroModel ListarLivroPorId(int id)
        {
            return livros.FirstOrDefault(l => l.Id == id);
        }
        #endregion
        
        #region Create
        // Criar um novo livro
        public void CriarLivro(LivroModel livro)
        {
            livro.Id = livros.Count + 1;
            livros.Add(livro);
        }
        #endregion

        #region Upload
        // Atualizar um livro existente
        public void AtualizarLivro(LivroModel livro)
        {
            LivroModel livroExistente = livros.FirstOrDefault(l => l.Id == livro.Id);
            if (livroExistente != null)
            {
                livroExistente.Titulo = livro.Titulo;
                livroExistente.Autor = livro.Autor;
                livroExistente.AnoPublicacao = livro.AnoPublicacao;
            }
        }
        #endregion

        #region Delete
        // Excluir um livro por ID
        public void ExcluirLivro(int id)
        {
            LivroModel livro = livros.FirstOrDefault(l => l.Id == id);
            if (livro != null)
            {
                livros.Remove(livro);
            }
        }
        #endregion
    }
}
