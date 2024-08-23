
using CursoEstudanteAPI.API.DTOs;

namespace CursoEstudanteAPI.Application.Services
{
    public interface IEstudanteService
    {
        Task<List<EstudanteDto>> GetAllEstudantesAsync();
        Task<EstudanteDto> GetEstudanteByIdAsync(int id);
        Task<EstudanteDto> CreateEstudanteAsync(EstudanteDto estudanteDto);
        Task<EstudanteDto> UpdateEstudanteAsync(int id, EstudanteDto estudanteDto);
        Task DeleteEstudanteAsync(int id);
    }
}
