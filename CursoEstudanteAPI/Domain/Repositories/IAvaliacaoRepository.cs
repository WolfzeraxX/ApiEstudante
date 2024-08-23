using CursoEstudanteAPI.Domain.Entities;

namespace CursoEstudanteAPI.Domain.Repositories
{
    public interface IAvaliacaoRepository
    {
        Task<List<Avaliacao>> GetAllAsync();
        Task<Avaliacao> GetByIdAsync(int id);
        Task AddAsync(Avaliacao avaliacao);
        Task UpdateAsync(Avaliacao avaliacao);
        Task DeleteAsync(Avaliacao avaliacao);
        Task<List<Avaliacao>> GetAvaliacoesByCursoAsync(int cursoId);
    }
}
