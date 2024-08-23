using CursoEstudanteAPI.API.DTOs;
using CursoEstudanteAPI.Domain.Entities;

namespace CursoEstudanteAPI.Application.Services
{
    public interface ICursoService
    {
        Task<List<CursoDto>> GetAllCursosAsync();
        Task<CursoDto> GetCursoByIdAsync(int id);
        Task<int> CreateCursoAsync(CursoDto cursoDto);
        Task<CursoDto> UpdateCursoAsync(int id, CursoDto cursoDto);
        Task DeleteCursoAsync(int id);
    }
}
