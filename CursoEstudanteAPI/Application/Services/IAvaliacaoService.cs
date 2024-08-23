using CursoEstudanteAPI.API.DTOs;

namespace CursoEstudanteAPI.Application.Services
{
    public interface IAvaliacaoService
    {
        Task<List<AvaliacaoDto>> GetAllAvaliacoesAsync();
        Task<AvaliacaoDto> GetAvaliacaoByIdAsync(int id);
        Task<AvaliacaoDto> CreateAvaliacaoAsync(AvaliacaoDto avaliacaoDto);
        Task<AvaliacaoDto> UpdateAvaliacaoAsync(int id, AvaliacaoDto avaliacaoDto);
        Task DeleteAvaliacaoAsync(int id);
        Task<List<AvaliacaoDto>> GetAvaliacoesByCursoAsync(int cursoId);
    }
}
