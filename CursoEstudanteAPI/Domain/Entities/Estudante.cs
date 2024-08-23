using System.ComponentModel.DataAnnotations;

namespace CursoEstudanteAPI.Domain.Entities
{
    public class Estudante
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public string? Email { get; set; }

        public ICollection<Avaliacao> Avaliacoes { get; set; } = new List<Avaliacao>();
    }
}
