using AutoMapper;
using CursoEstudanteAPI.API.DTOs;
using CursoEstudanteAPI.Application.Services;
using CursoEstudanteAPI.Domain.Entities;
using CursoEstudanteAPI.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CursoEstudanteAPI.API.Controller
{
    [ApiController]
    [Route("api/avaliacao")]
    public class AvaliacaoController : ControllerBase
    {
        private readonly IAvaliacaoService _avaliacaoService;

        public AvaliacaoController(IAvaliacaoService avaliacaoService)
        {
            _avaliacaoService = avaliacaoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var avaliacoes = await _avaliacaoService.GetAllAvaliacoesAsync();
            return Ok(avaliacoes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var avaliacao = await _avaliacaoService.GetAvaliacaoByIdAsync(id);
            if (avaliacao == null) return NotFound();
            return Ok(avaliacao);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AvaliacaoDto avaliacaoDto)
        {
            var avaliacao = await _avaliacaoService.CreateAvaliacaoAsync(avaliacaoDto);
            return CreatedAtAction(nameof(GetById), new { id = avaliacao.Id }, avaliacao);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AvaliacaoDto avaliacaoDto)
        {
            var updatedAvaliacao = await _avaliacaoService.UpdateAvaliacaoAsync(id, avaliacaoDto);
            if (updatedAvaliacao == null) return NotFound();
            return Ok(updatedAvaliacao);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _avaliacaoService.DeleteAvaliacaoAsync(id);
            return NoContent();
        }

        [HttpGet("curso/{cursoId}")]
        public async Task<IActionResult> GetAvaliacoesByCurso(int cursoId)
        {
            var avaliacoes = await _avaliacaoService.GetAvaliacoesByCursoAsync(cursoId);
            return Ok(avaliacoes);
        }
    }

}
