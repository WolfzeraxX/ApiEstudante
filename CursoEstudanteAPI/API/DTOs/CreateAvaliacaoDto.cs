namespace CursoEstudanteAPI.API.DTOs
{
    public class CreateAvaliacaoDto
    {
        public int Estrela { get; set; }
        public string Comentario { get; set; }
        public int CursoId { get; set; }
        public int EstudanteId { get; set; }
    }
}
