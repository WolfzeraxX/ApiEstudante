using System.ComponentModel.DataAnnotations;

namespace CursoEstudanteAPI.Domain.Entities
{
    public class Curso
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public string? Descricao { get; set; }

        public ICollection<Avaliacao> Avaliacoes { get; set; } = new List<Avaliacao>();
    }

}
