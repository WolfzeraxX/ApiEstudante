using CursoEstudanteAPI.API.DTOs;
using CursoEstudanteAPI.Domain.Entities;

namespace CursoEstudanteAPI.Domain.Repositories
{
    public interface ICursoRepository
    {
        Task<List<CursoDto>> GetAllAsync();
        Task<Curso> GetByIdAsync(int id);
        Task<int> AddAsync(Curso curso);
        Task UpdateAsync(Curso curso);
        Task DeleteAsync(Curso curso);
    }




}
