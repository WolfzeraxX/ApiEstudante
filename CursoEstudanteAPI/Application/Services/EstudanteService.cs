using AutoMapper;
using CursoEstudanteAPI.API.DTOs;
using CursoEstudanteAPI.Domain.Entities;
using CursoEstudanteAPI.Domain.Repositories;
using CursoEstudanteAPI.Infrastructure.Persistence;

namespace CursoEstudanteAPI.Application.Services
{
    public class EstudanteService : IEstudanteService
    {
        private readonly IEstudanteRepository _estudanteRepository;
        private readonly IMapper _mapper;

        public EstudanteService(IEstudanteRepository estudanteRepository, IMapper mapper)
        {
            _estudanteRepository = estudanteRepository;
            _mapper = mapper;
        }

        public async Task<List<EstudanteDto>> GetAllEstudantesAsync()
        {
            var estudantes = await _estudanteRepository.GetAllAsync();
            return estudantes;
        }

        public async Task<EstudanteDto> GetEstudanteByIdAsync(int id)
        {
            var estudante = await _estudanteRepository.GetByIdAsync(id);
            return _mapper.Map<EstudanteDto>(estudante);
        }

        public async Task<EstudanteDto> CreateEstudanteAsync(EstudanteDto estudanteDto)
        {
            var estudante = new Estudante
            {
                Id = estudanteDto.Id,
                Nome = estudanteDto.Nome,
                
            };
            await _estudanteRepository.AddAsync(estudante);
            return _mapper.Map<EstudanteDto>(estudante);
        }

        public async Task<EstudanteDto> UpdateEstudanteAsync(int id, EstudanteDto estudanteDto)
        {
            var estudante = await _estudanteRepository.GetByIdAsync(id);
            if (estudante == null) throw new KeyNotFoundException($"Estudante com ID {id} não encontrado.");
            _mapper.Map(estudanteDto, estudante);
            await _estudanteRepository.UpdateAsync(estudante);
            return _mapper.Map<EstudanteDto>(estudante);
        }

        public async Task DeleteEstudanteAsync(int id)
        {
            var estudante = await _estudanteRepository.GetByIdAsync(id);
            if (estudante == null) throw new KeyNotFoundException($"Estudante com ID {id} não encontrado.");
            await _estudanteRepository.DeleteAsync(estudante);
        }
    }

}
