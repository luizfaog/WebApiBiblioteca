using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using WebApiBiblioteca.Models;
using WebApiBiblioteca.Services.Implementation;
using WebApiBiblioteca.Services.Interface;

namespace WebApiBiblioteca.Controllers
{
    public class LivroController : Controller
    {
        #region Construtor
        private readonly ILivroService _livroService;
        public LivroController(ILivroService livroService)
        {
            _livroService = livroService;
        }
        #endregion
       
        #region Get
        /// <summary>
        /// Lista todos os Livros
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [HttpGet("GetLivros")]
        [Produces("application/json")]
        public IActionResult ListarLivros()
        {
            try
            {
                var listaLivros = _livroService.ListarLivros();

                if (listaLivros.Count > 0)
                    return Ok(listaLivros);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Lista todos os Livros filtrando por id
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [HttpGet("GetLivro/{id}")]
        [Produces("application/json")]
        public IActionResult ListarLivrosPorID(int id)
        {
            try
            {
                var livro = _livroService.ListarLivroPorId(id);

                if (livro == null)
                   return NotFound();                
                else
                   return Ok(livro);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return new BadRequestObjectResult(ex.Message);
            }
        }
        #endregion
        #region Delete
        /// <summary>
        /// Apaga um Livro da lista
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [HttpDelete("DeleteLivro")]
        [Produces("application/json")]
        public IActionResult DeleteLivro(int Id)
        {
            try
            {
                _livroService.ExcluirLivro(Id);

                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return new BadRequestObjectResult(ex.Message);
            }
        }
        #endregion
        #region Post
        /// <summary>
        /// Atualiza um livro 
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [HttpPut("AtualizaLivro")]
        [Produces("application/json")]
        public IActionResult AtualizarLivro([FromBody]LivroModel livro)
        {
            try
            {
                _livroService.AtualizarLivro(livro);

                if(livro == null)
                    return NotFound();
                else
                    return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return new BadRequestObjectResult(ex.Message);
            }
        }
        #endregion
        #region Create
        /// <summary>
        /// Cria um livro 
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [HttpPost("CriaLivro")]
        [Produces("application/json")]
        public IActionResult CriarLivro([FromBody] LivroModel livro)
        {
            try
            {
                _livroService.CriarLivro(livro);

                if (livro == null)
                    return NotFound();
                else
                    return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return new BadRequestObjectResult(ex.Message);
            }
        }
        #endregion
    }
}

