using AutoMapper;
using CursoEstudanteAPI.API.DTOs;
using CursoEstudanteAPI.Domain.Entities;
using CursoEstudanteAPI.Domain.Repositories;
using CursoEstudanteAPI.Infrastructure.Persistence;

namespace CursoEstudanteAPI.Application.Services
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly IMapper _mapper;

        public CursoService(ICursoRepository cursoRepository, IMapper mapper)
        {
            _cursoRepository = cursoRepository;
            _mapper = mapper;
        }

        public async Task<List<CursoDto>> GetAllCursosAsync()
        {
            return await _cursoRepository.GetAllAsync();
        }

        public async Task<CursoDto> GetCursoByIdAsync(int id)
        {
            var curso = await _cursoRepository.GetByIdAsync(id);
            return _mapper.Map<CursoDto>(curso);
        }

        public async Task<int> CreateCursoAsync(CursoDto cursoDto)
        {
            var curso = new Curso
            {
                Nome = cursoDto.Nome,
                Descricao = cursoDto.Descricao

            };
            
            return await _cursoRepository.AddAsync(curso);
            
        }

        public async Task<CursoDto> UpdateCursoAsync(int id, CursoDto cursoDto)
        {
            var curso = await _cursoRepository.GetByIdAsync(id);
            if (curso == null) throw new KeyNotFoundException($"Curso com ID {id} não encontrado.");
            _mapper.Map(cursoDto, curso);
            await _cursoRepository.UpdateAsync(curso);
            return _mapper.Map<CursoDto>(curso);
        }

        public async Task DeleteCursoAsync(int id)
        {
            var curso = await _cursoRepository.GetByIdAsync(id);
            if (curso == null) throw new KeyNotFoundException($"Curso com ID {id} não encontrado.");
            await _cursoRepository.DeleteAsync(curso);
        }
    }

}
