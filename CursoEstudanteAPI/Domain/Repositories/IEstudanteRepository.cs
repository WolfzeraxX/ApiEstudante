using CursoEstudanteAPI.API.DTOs;
using CursoEstudanteAPI.Domain.Entities;

namespace CursoEstudanteAPI.Domain.Repositories
{
    public interface IEstudanteRepository
    {
        Task<List<EstudanteDto>> GetAllAsync();
        Task<Estudante> GetByIdAsync(int id);
        Task AddAsync(Estudante estudante);
        Task UpdateAsync(Estudante estudante);
        Task DeleteAsync(Estudante estudante);
    }
}
