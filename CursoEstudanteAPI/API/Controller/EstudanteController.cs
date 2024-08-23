using CursoEstudanteAPI.API.DTOs;
using CursoEstudanteAPI.Application.Services;
using CursoEstudanteAPI.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CursoEstudanteAPI.API.Controller
{
    [ApiController]
    [Route("api/estudante")]
    public class EstudanteController : ControllerBase
    {
        private readonly IEstudanteService _estudanteService;

        public EstudanteController(IEstudanteService estudanteService)
        {
            _estudanteService = estudanteService;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAll()
        {
            var estudantes = await _estudanteService.GetAllEstudantesAsync();
            return Ok(estudantes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var estudante = await _estudanteService.GetEstudanteByIdAsync(id);
            if (estudante == null) return NotFound();
            return Ok(estudante);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EstudanteDto estudanteDto)
        {
            var estudante = await _estudanteService.CreateEstudanteAsync(estudanteDto);
            return Ok(estudante);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EstudanteDto estudanteDto)
        {
            var updatedEstudante = await _estudanteService.UpdateEstudanteAsync(id, estudanteDto);
            if (updatedEstudante == null) return NotFound();
            return Ok(updatedEstudante);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _estudanteService.DeleteEstudanteAsync(id);
            return NoContent();
        }
    }
}
