namespace CursoEstudanteAPI.API.DTOs
{
    public class AvaliacaoDto
    {
        public int Id { get; set; }
        public int Estrelas { get; set; }
        public string Comentario { get; set; }
        public int CursoId { get; set; }
        public int EstudanteId { get; set; }
    }


}
