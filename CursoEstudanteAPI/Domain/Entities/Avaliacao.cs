using System.ComponentModel.DataAnnotations;

namespace CursoEstudanteAPI.Domain.Entities
{
    public class Avaliacao
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Estrelas { get; set; }

        public string? Comentario { get; set; }

        [Required]
        public int CursoId { get; set; }
        public Curso? Curso { get; set; }

        [Required]
        public int EstudanteId { get; set; }
        public Estudante? Estudante { get; set; }
    }
}
