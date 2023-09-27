using System.ComponentModel.DataAnnotations;

namespace WebApiBiblioteca.Models
{
    public class LivroModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Titulo { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Autor { get; set; }
        public string? AnoPublicacao { get; set; }
    }
}
