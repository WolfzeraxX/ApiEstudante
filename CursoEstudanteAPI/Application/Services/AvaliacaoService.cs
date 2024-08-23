using AutoMapper;
using CursoEstudanteAPI.API.DTOs;
using CursoEstudanteAPI.Domain.Entities;
using CursoEstudanteAPI.Domain.Repositories;

namespace CursoEstudanteAPI.Application.Services
{
    public class AvaliacaoService : IAvaliacaoService
    {
        private readonly IAvaliacaoRepository _avaliacaoRepository;
        private readonly IMapper _mapper;

        public AvaliacaoService(IAvaliacaoRepository avaliacaoRepository, IMapper mapper)
        {
            _avaliacaoRepository = avaliacaoRepository;
            _mapper = mapper;
        }

        public async Task<List<AvaliacaoDto>> GetAllAvaliacoesAsync()
        {
            var avaliacoes = await _avaliacaoRepository.GetAllAsync();
            return _mapper.Map<List<AvaliacaoDto>>(avaliacoes);
        }

        public async Task<AvaliacaoDto> GetAvaliacaoByIdAsync(int id)
        {
            var avaliacao = await _avaliacaoRepository.GetByIdAsync(id);
            return _mapper.Map<AvaliacaoDto>(avaliacao);
        }

        public async Task<AvaliacaoDto> CreateAvaliacaoAsync(AvaliacaoDto avaliacaoDto)
        {
            var avaliacao = _mapper.Map<Avaliacao>(avaliacaoDto);
            await _avaliacaoRepository.AddAsync(avaliacao);
            return _mapper.Map<AvaliacaoDto>(avaliacao);
        }

        public async Task<AvaliacaoDto> UpdateAvaliacaoAsync(int id, AvaliacaoDto avaliacaoDto)
        {
            var avaliacao = await _avaliacaoRepository.GetByIdAsync(id);
            if (avaliacao == null) throw new KeyNotFoundException($"Avaliação com ID {id} não encontrada.");
            _mapper.Map(avaliacaoDto, avaliacao);
            await _avaliacaoRepository.UpdateAsync(avaliacao);
            return _mapper.Map<AvaliacaoDto>(avaliacao);
        }

        public async Task DeleteAvaliacaoAsync(int id)
        {
            var avaliacao = await _avaliacaoRepository.GetByIdAsync(id);
            if (avaliacao == null) throw new KeyNotFoundException($"Avaliação com ID {id} não encontrada.");
            await _avaliacaoRepository.DeleteAsync(avaliacao);
        }

        public async Task<List<AvaliacaoDto>> GetAvaliacoesByCursoAsync(int cursoId)
        {
            var avaliacoes = await _avaliacaoRepository.GetAvaliacoesByCursoAsync(cursoId);
            return _mapper.Map<List<AvaliacaoDto>>(avaliacoes);
        }
    }


}

